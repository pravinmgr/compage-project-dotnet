using Procurement.Core.Entities;
using Procurement.Core.Repositories;
using Procurement.Infrastructure.Data;

namespace Procurement.Infrastructure.Repositories
{

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(ProcurementContext dbContext) : base(dbContext)
        {
        }    
    }
}
