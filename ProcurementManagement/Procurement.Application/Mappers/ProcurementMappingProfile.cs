using AutoMapper;
using Procurement.Application.Commands.InvoiceService;
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


        }
    }

}
