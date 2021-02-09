$webappname = "mytodoappwebappname";
$location = "West Europe";
$resourceGroupName = "my_todo_app_resource_group";

New-AzAppServicePlan `
-Name $webappname `
-Location $location `
-ResourceGroupName $resourceGroupName `
-Tier Free;

New-AzWebApp `
-Name $webappname `
-Location $location `
-AppServicePlan $webappname `
-ResourceGroupName $resourceGroupName;