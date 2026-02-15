using System.Net.Http.Headers;
using Claps.ProductCatalog.Domain.Enums;

namespace Claps.ProductCatalog.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public string Category { get; private set; }
    public ProductStatus Status { get; private set; }
    public String? ImageUrl { get; private set; }
    public DateTime createdAt { get; private set; }

    public Product(string name, string description, decimal price, string category)
    {
        Validate(name, price);

        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        Category = category;
        Status = ProductStatus.Active;
        createdAt = DateTime.UtcNow;
    }

    public void Update(string name, string description, decimal price, string category)
    {
        Validate(name, price);

        Name = name;
        Description = description;
        Price = price;
        Category = category;
    }

    public void ChangeStatus(ProductStatus status)
    {
        Status = status;
    }

    public void SetImage(string imageUrl)
    {
        ImageUrl = imageUrl;
    }

    public void Validate(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name cannot be empty.");

        if (price < 0)
            throw new ArgumentException("Price cannot be negative.");
    }
}