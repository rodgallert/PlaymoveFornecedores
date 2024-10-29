using AutoMapper;
using Suppliers.Domain.Entities;
using Suppliers.Domain.Interfaces.Repositories;
using Suppliers.Domain.Interfaces.Services;
using Suppliers.Domain.ViewModels;

namespace Suppliers.Services.ApiServices;
public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;

    public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
    {
        this._supplierRepository = supplierRepository;
        _mapper = mapper;
    }

    public async Task<SupplierViewModel> AddAsync(SupplierViewModel supplier)
    {
        if (await _supplierRepository.IsTaxIdentificationNumberRegisteredAsync(supplier.TaxIdentificationNumber))
            throw new ArgumentException("Tax identification number is already registered");

        var supplierDto = _mapper.Map<Supplier>(supplier);
        supplierDto = await _supplierRepository.AddAsync(supplierDto);

        return _mapper.Map<SupplierViewModel>(supplierDto);
    }

    public async Task DeleteAsync(SupplierViewModel supplier, ulong id)
    {
        if (supplier.Id != id)
            throw new ArgumentException("Id does not match");

        var supplierDto = _mapper.Map<Supplier>(supplier);
        await _supplierRepository.DeleteAsync(supplierDto);
    }

    public async Task<SupplierViewModel> GetAsync(ulong id)
    {
        var supplier = await _supplierRepository.GetAsync(id);

        return _mapper.Map<SupplierViewModel>(supplier);
    }

    public async Task<PaginatedList<SupplierViewModel>> GetAsync(int page = 1, int size = 10)
    {
        int skip = (page - 1) * size;
        var suppliers = await _supplierRepository.GetAsync();

        var viewModel = _mapper.Map<ICollection<SupplierViewModel>>(suppliers.Skip(skip).Take(size));

        return new PaginatedList<SupplierViewModel>(suppliers.Count, viewModel);
    }

    public async Task<PaginatedList<SupplierViewModel>> SearchAsync(string query, CancellationToken ct, int page = 1, int size = 10)
    {
        int skip = (page - 1) * size;

        var suppliers = await _supplierRepository.SearchSuppliersAsync(query, ct);
        
        var viewModel = _mapper.Map<ICollection<SupplierViewModel>>(suppliers.Skip(skip).Take(size));

        return new PaginatedList<SupplierViewModel>(suppliers.Count, viewModel);
    }

    public async Task UpdateAsync(SupplierViewModel supplier, ulong id)
    {
        if (supplier.Id != id)
            throw new ArgumentException("Id does not match");

        var supplierDto = await _supplierRepository.GetAsync(id);

        if (supplierDto == null)
            throw new ArgumentException("Supplier not found");

        supplierDto.Name = supplier.Name;
        supplierDto.Address = supplier.Address;
        supplierDto.Phone = supplier.Phone;
        supplierDto.Email = supplier.Email;

        await _supplierRepository.UpdateAsync(supplierDto);
    }
}
