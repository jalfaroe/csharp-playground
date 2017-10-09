namespace IMS.Infrastructure.Crosscutting.Core
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public string GetConnectionString()
        {
            // Todo: get this data from a config file
            var connString =
                "Data Source=DESKTOP-S7QIE5O;Initial Catalog=InventoryManagementSystem;persist security info=True;Integrated Security=SSPI;MultipleActiveResultSets=True;App=EntityFramework";

            return connString;
        }
    }
}