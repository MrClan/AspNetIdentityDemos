3 Nuget Packages requried:

1. Microsoft.AspNet.Identity.Core
2. Microsoft.AspNet.Identity.EntityFramework
3. EntityFramework



In the app.config, a connection string named **DefaultConnection** is required, since EntityFramework uses it as the default to initialize the DbContext or IdentityDbContext.
Details here: https://stackoverflow.com/questions/44474465/asp-net-identity-fails-to-connect-to-the-database-even-when-ef-can-successfully



