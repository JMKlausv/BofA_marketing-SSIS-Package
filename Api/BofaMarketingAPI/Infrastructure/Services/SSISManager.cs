

using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;
public class SSISManager  : ISSISManager
{
    private readonly IAppDbContext _context;

    public SSISManager(IAppDbContext context)
    {
        _context = context;
    }
    public void ExecuteSSISPackage()
    {
        try
        {
         _context.database.ExecuteSqlRaw("EXEC RunSSISPackage");
            
        }
        catch (System.Exception e)
        {
            Console.WriteLine("error Excecuting ssis package , ",e);
            
            throw;
        }
        // Connection string to the Integration Services catalog
        // string integrationServicesConnectionString = "Data Source=YourServer;Initial Catalog=SSISDB;Integrated Security=SSPI;";

        // // Instantiate SSIS Server
        // IntegrationServices ssisServer = new IntegrationServices(new SqlConnection(integrationServicesConnectionString));

        // // Load SSIS Package
        // PackageInfo package = ssisServer.Catalogs["SSISDB"].Folders["YourFolder"].Projects["YourProject"].Packages[packageName];

        // // Execute SSIS Package
        // package.Execute();
    }
}
