# Shopping

## Migrations :
- dotnet ef migrations add InitialMigration -p .\Shopping.Data.csproj --startup-project ..\Shopping.API\Shopping.API.csproj -c DataContext
- dotnet ef database update -p .\Shopping.Data.csproj --startup-project ..\Shopping.API\Shopping.API.csproj -c DataContext 