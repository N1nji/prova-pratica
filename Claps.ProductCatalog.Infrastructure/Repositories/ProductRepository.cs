using Claps.ProductCatalog.Application.Interfaces;
using Claps.ProductCatalog.Domain.Entities;
using Claps.ProductCatalog.Domain.Enums;
using Claps.ProductCatalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Claps.ProductCatalog.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product> AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> GetByIdAsync(Guid id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> GetAllAsync(
        string? category,
        decimal? minPrice,
        decimal? maxPrice,
        ProductStatus? status)
    {
        var query = _context.Products.AsQueryable();

        if (!string.IsNullOrWhiteSpace(category))
            query = query.Where(p => p.Category == category);

        if (minPrice.HasValue)
            query = query.Where(p => p.Price >= minPrice.Value);

        if (maxPrice.HasValue)
            query = query.Where(p => p.Price <= maxPrice.Value);

        if (status.HasValue)
            query = query.Where(p => p.Status == status.Value);

        return await query.ToListAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}