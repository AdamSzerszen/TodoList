$PSScriptRoot;

$azureBaseSetupScript = $PSScriptRoot+"\app_service_setup.ps1";
$appServiceSetupScript = $PSScriptRoot+"\azure_base_setup.ps1";
$cosmosDbSetupScript = $PSScriptRoot+"\cosmos_setup.ps1";
$cosmosDbKeyCheckScript = $PSScriptRoot+"\cosmos_db_key_check.ps1";

&$azureBaseSetupScript;
&$appServiceSetupScript;
&$cosmosDbSetupScript;
&$cosmosDbKeyCheckScript;