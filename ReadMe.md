Run the script "Database_Publish" on your empty MMTShop database (Currently set to use LocalDB/MMTShop)
Set the Connection string in the appsettings.json
Ensure the API__HostUrl variable in MMTShopClient appSettings.json matches the SSL hosting port in the MMTShopApi project
This will be set by Visual Studio when you open it, and can be found in Project Properties -> Debug
Start the "MMTShopApi" and "MMTShopClient" projects.
Follow on-screen instructions.