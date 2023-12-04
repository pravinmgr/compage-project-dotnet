using AutoMapper;
using Procurement.Application.Commands.InvoiceService;
using Procurement.Application.Commands.OrderService;
using Procurement.Application.Responses;
using Procurement.Core.Entities;

namespace Procurement.Application.Mappers
{

    public class ProcurementMappingProfile : Profile
    {
        public ProcurementMappingProfile()
        {
            //Invoice
            CreateMap<Invoice, InvoiceResponse>().ReverseMap();
            CreateMap<Invoice, CreateInvoiceCommand>().ReverseMap();
            CreateMap<Invoice, UpdateInvoiceCommand>().ReverseMap();

            //Order
            CreateMap<Order, OrderResponse>().ReverseMap();
            CreateMap<Order, CreateOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }

}
