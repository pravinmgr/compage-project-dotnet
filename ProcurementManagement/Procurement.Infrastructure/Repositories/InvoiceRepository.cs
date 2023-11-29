using Procurement.Core.Entities;
using Procurement.Core.Repositories;
using Procurement.Infrastructure.Data;

namespace Procurement.Infrastructure.Repositories
{

    public class InvoiceRepository : RepositoryBase<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ProcurementContext dbContext) : base(dbContext)
        {
        }
        //public async Task<Invoice> GetByIdAsync(Guid id)
        //{
        //    return await _dbContext.Set<Invoice>().FindAsync(id);
        //}
    }


}
