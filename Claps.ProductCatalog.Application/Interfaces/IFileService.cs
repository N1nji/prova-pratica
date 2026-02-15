namespace Claps.ProductCatalog.Application.Interfaces;

public interface  IFileService
{
    Task<string> SaveFileAsync(Stream fileStream, string fileName);
}
