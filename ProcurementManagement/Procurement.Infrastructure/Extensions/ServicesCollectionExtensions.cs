using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Procurement.Core.Repositories;
using Procurement.Infrastructure.Data;
using Procurement.Infrastructure.Repositories;


namespace Procurement.Infrastructure.Extensions
{

    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ProcurementContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("ProcurementConnectionString")));
            serviceCollection.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            serviceCollection.AddScoped<IInvoiceRepository, InvoiceRepository>();
            serviceCollection.AddScoped<IOrderRepository,OrderRepository>();

            return serviceCollection;
        }
    }
}
