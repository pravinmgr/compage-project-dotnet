using Microsoft.EntityFrameworkCore;
using Procurement.Core.Common;
using Procurement.Core.Entities;


namespace Procurement.Infrastructure.Data
{

    public class ProcurementContext : DbContext
    {
        public ProcurementContext(DbContextOptions<ProcurementContext> options) : base(options)
        {
        }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Order> Order { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {           
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
