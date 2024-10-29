using Microsoft.AspNetCore.Mvc;
using Suppliers.Domain.Interfaces.Services;
using Suppliers.Domain.ViewModels;

namespace Suppliers.Api.Controllers;

[Route("[controller]")]
public class SuppliersController : BaseController
{
    private readonly ISupplierService supplierService;

    public SuppliersController(ISupplierService supplierService)
    {
        this.supplierService = supplierService;
    }

    [HttpGet]
    [ActionName("ListSuppliers")]
    public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10) => 
            Ok(await supplierService.GetAsync(page, pageSize));

    [HttpGet("{id}")]
    [ActionName("GetSupplier")]
    public async Task<IActionResult> Get(ulong id) => 
            Ok(await supplierService.GetAsync(id));

    [HttpGet("search")]
    [ActionName("SearchSuppliers")]
    public async Task<IActionResult> Search([FromQuery] string query, CancellationToken ct, [FromQuery] int page = 1, [FromQuery] int pageSize = 10) => 
            Ok(await supplierService.SearchAsync(query, ct, page, pageSize));

    [HttpPost]
    [ActionName("AddSupplier")]
    public async Task<IActionResult> Post([FromBody] SupplierViewModel supplier)
    {
        var addedSupplier = await supplierService.AddAsync(supplier);

        return CreatedAtAction("GetSupplier", new { id = addedSupplier.Id }, addedSupplier);
    }

    [HttpPut("{id}")]
    [ActionName("UpdateSupplier")]
    public async Task<IActionResult> Put(ulong id, [FromBody] SupplierViewModel supplier)
    {
        await supplierService.UpdateAsync(supplier, id);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ActionName("DeleteSupplier")]
    public async Task<IActionResult> Delete(ulong id, [FromBody] SupplierViewModel supplier)
    {
        await supplierService.DeleteAsync(supplier, id);
        return NoContent();
    }
}
