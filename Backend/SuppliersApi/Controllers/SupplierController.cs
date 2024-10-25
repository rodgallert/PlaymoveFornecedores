using Microsoft.AspNetCore.Mvc;
using Suppliers.Domain.Interfaces.Services;
using Suppliers.Domain.ViewModels;

namespace Suppliers.Api.Controllers;

[Route("[controller]")]
public class SupplierController : BaseController
{
    private readonly ISupplierService supplierService;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await supplierService.GetAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(ulong id) => Ok(await supplierService.GetAsync(id));

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SupplierViewModel supplier) => Ok(await supplierService.AddAsync(supplier));

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(ulong id, [FromBody] SupplierViewModel supplier)
    {
        await supplierService.UpdateAsync(supplier, id);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ulong id, [FromBody] SupplierViewModel supplier)
    {
        await supplierService.DeleteAsync(supplier, id);
        return Ok();
    }
}
