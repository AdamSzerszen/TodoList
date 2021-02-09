using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.BusinessLogic.Models;

namespace TodoList.BusinessLogic.Interfaces
{
  public interface IItemRepository
  {
    Task UpdateItemAsync(string itemId, Item item);
    Task<Item> GetItemAsync(string id);
    Task DeleteItemAsync(string id);
    Task AddItemAsync(Item item);
    Task<IEnumerable<Item>> GetItemsAsync(string query);
  }
}