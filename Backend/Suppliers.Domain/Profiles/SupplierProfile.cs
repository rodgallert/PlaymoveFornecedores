using AutoMapper;
using Suppliers.Domain.Entities;
using Suppliers.Domain.ViewModels;

namespace Suppliers.Domain.Profiles;
public class SupplierProfile : Profile
{
    public SupplierProfile()
    {
        CreateMap<Supplier, SupplierViewModel>();
        CreateMap<SupplierViewModel, Supplier>();
    }
}
