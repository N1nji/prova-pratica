using Claps.ProductCatalog.Domain.Entities;
using Claps.ProductCatalog.Domain.Enums;

namespace Claps.ProductCatalog.Application.Interfaces;

public interface IProductRepository
{
    Task<Product> AddAsync(Product product);
    Task<Product> GetByIdAsync(Guid id);
    Task<IEnumerable<Product>> GetAllAsync(
        string? category,
        decimal? minPrice,
        decimal? maxPrice,
        ProductStatus? status);

    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);
}