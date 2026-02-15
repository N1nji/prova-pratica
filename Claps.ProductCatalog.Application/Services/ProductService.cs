using Claps.ProductCatalog.Application.Interfaces;
using Claps.ProductCatalog.Domain.Entities;
using Claps.ProductCatalog.Domain.Enums;


namespace Claps.ProductCatalog.Application.Services;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {

        _repository = repository;
    }

    public async Task<Product> CreateAsync(string name, string description, decimal price, string category)
    {
        var product = new Product(name, description, price, category);

        return await _repository.AddAsync(product);
    }

    public async Task<IEnumerable<Product>> GetAllAsync(
        string? category,
        decimal? minPrice,
        decimal? maxPrice,
        ProductStatus? status)

    {
        return await _repository.GetAllAsync(category, minPrice, maxPrice, status);
    }

    public async Task<Product> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Guid id, string name, string description, decimal price, string category)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product == null)
            throw new Exception("Product not found");

        product.Update(name, description, price, category);

        await _repository.UpdateAsync(product);
    }

    public async Task UpdateImageAsync(Guid id, string imageUrl)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product == null)
            throw new Exception("Product not found");

        product.SetImage(imageUrl);
        
        await _repository.UpdateAsync(product);
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product == null)
            throw new Exception("Product not found");

        await _repository.DeleteAsync(product);
    }
}
