using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Procurement.Infrastructure.Data
{

    public class ProcurementContextFactory : IDesignTimeDbContextFactory<ProcurementContext>
    {
        public ProcurementContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProcurementContext>();
            optionsBuilder.UseSqlServer("Data Source=***;Initial Catalog = ProcurementDb;User Id=***;Password=***;TrustServerCertificate=True;");
            return new ProcurementContext(optionsBuilder.Options);
        }
    }
}
