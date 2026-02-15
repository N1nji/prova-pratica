using Claps.ProductCatalog.Application.Services;
using Claps.ProductCatalog.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Claps.ProductCatalog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _service;

    public ProductsController(ProductService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        string name,
        string description,
        decimal price,
        string category)
    {
        var product = await _service.CreateAsync(name, description, price, category);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        string? category,
        decimal? minPrice,
        decimal? maxPrice,
        ProductStatus? status)
    {
        var products = await _service.GetAllAsync(category, minPrice, maxPrice, status);
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _service.GetByIdAsync(id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        string name,
        string description,
        decimal price,
        string category)
    {
        await _service.UpdateAsync(id, name, description, price, category);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
