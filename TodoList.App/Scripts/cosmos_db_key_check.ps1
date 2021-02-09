$resourceGroupName = "my_todo_app_resource_group";
$accountName = "mytodoappscosmosaccount";

$keys = Get-AzCosmosDBAccountKey `
    -ResourceGroupName $resourceGroupName `
    -Name $accountName `
    -Type "Keys";

$account =  Get-AzCosmosDBAccount -ResourceGroupName $resourceGroupName -Name $accountName;

$primaryMasterKey = $keys.PrimaryMasterKey;
$endPointUri = $account.DocumentEndpoint;
$appsettingsPath = "..\appsettings.json";
$endPointUriPlaceholder = "COSMOS_DB_ACCOUNT_URI";
$primaryMasterKeyPlaceholder = "COSMOS_DB_KEY";

(Get-Content -path $appsettingsPath -Raw) -replace $endPointUriPlaceholder, $endPointUri `
 | Set-Content -Path $appsettingsPath;

(Get-Content -path $appsettingsPath -Raw) -replace $primaryMasterKeyPlaceholder, $primaryMasterKey `
 | Set-Content -Path $appsettingsPath;
