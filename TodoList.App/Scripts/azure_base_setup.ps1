if ($PSVersionTable.PSEdition -eq 'Desktop' -and (Get-Module -Name AzureRM -ListAvailable)) {
    Write-Warning -Message ('Error');
} else {
    Install-Module -Name Az -AllowClobber -Scope CurrentUser;
}

$location = "West Europe";

Connect-AzAccount;
New-AzResourceGroup -Name my_todo_app_resource_group -Location $location;