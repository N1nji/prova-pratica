using Claps.ProductCatalog.Application.Interfaces;

namespace Claps.ProductCatalog.Infrastructure.Services;

public class FileService : IFileService
{
    private readonly string _uploadPath;

public FileService()
    {
        _uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

        if (!Directory.Exists(_uploadPath))
            Directory.CreateDirectory(_uploadPath);
    }

    public async Task<string> SaveFileAsync(Stream fileStream, string fileName)
    {
        var uniqueFileName = $"{Guid.NewGuid()}_{fileName}";
        var filePath = Path.Combine(_uploadPath, uniqueFileName);

        using var stream = new FileStream(filePath, FileMode.Create);
        await fileStream.CopyToAsync(stream);

        return $"/uploads/{uniqueFileName}";
    }
}

