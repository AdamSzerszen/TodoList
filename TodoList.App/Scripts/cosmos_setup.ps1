$resourceGroupName = "my_todo_app_resource_group";  # your resource group name where your want to deploy cosmos account
                                                    # it should exists before running this script

$accountName = "mytodoappscosmosaccount";            # your cosmos account name 
$apiKind = "Sql";
$consistencyLevel = "BoundedStaleness";
$maxStalenessInterval = 300;
$maxStalenessPrefix = 100000;
$location = "West Europe";

New-AzCosmosDBAccount `
    -ResourceGroupName $resourceGroupName `
    -Location $location `
    -Name $accountName `
    -ApiKind $apiKind `
    -EnableAutomaticFailover:$true `
    -DefaultConsistencyLevel $consistencyLevel `
    -MaxStalenessIntervalInSeconds $maxStalenessInterval `
    -MaxStalenessPrefix $maxStalenessPrefix;