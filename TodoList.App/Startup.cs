using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoList.App.Constants;
using TodoList.BusinessLogic.Interfaces;
using TodoList.BusinessLogic.Repositories;

namespace TodoList.App
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      ConfigureCosmosDbRepository(services);

      services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApp(Configuration.GetSection("AzureAdB2C"));
      services.AddControllersWithViews();
      services.AddRazorPages()
        .AddMicrosoftIdentityUI();
    }

    private void ConfigureCosmosDbRepository(IServiceCollection services)
    {
      IConfigurationSection cosmosDbSection = Configuration.GetSection(SectionConstants.CosmosDbSectionName);
      ItemCosmosDbRepository itemCosmosDbRepository =
        InitializeCosmosClientInstanceAsync(cosmosDbSection).GetAwaiter().GetResult();

      services.AddSingleton<IItemRepository>(itemCosmosDbRepository);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller=Item}/{action=Index}/{id?}");
        endpoints.MapRazorPages();
      });
    }

    private static async Task<ItemCosmosDbRepository> InitializeCosmosClientInstanceAsync(
      IConfigurationSection configurationSection)
    {
      string databaseName = configurationSection.GetSection(SectionConstants.DatabaseNameSectionName).Value;
      string containerName = configurationSection.GetSection(SectionConstants.ContainerNameSectionName).Value;
      string account = configurationSection.GetSection(SectionConstants.AccountSectionName).Value;
      string key = configurationSection.GetSection(SectionConstants.KeySectionName).Value;
      CosmosClient client = new(account, key);
      ItemCosmosDbRepository itemRepository = new(client, databaseName, containerName);
      DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
      await database.Database.CreateContainerIfNotExistsAsync(containerName, "/id");

      return itemRepository;
    }
  }
}