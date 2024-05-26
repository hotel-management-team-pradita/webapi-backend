namespace hotel_management_backend.Utilities;

class UploadUtils
{
    public static async Task<string> UploadImage(IFormFile image, HttpRequest request)
    {
        var uploads = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
        if (!Directory.Exists(uploads))
        {
            Directory.CreateDirectory(uploads);
        }

        var fileName = Path.GetFileNameWithoutExtension(image.FileName)
                      + "_" + Guid.NewGuid().ToString()
                      + Path.GetExtension(image.FileName);

        var filePath = Path.Combine(uploads, fileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await image.CopyToAsync(fileStream);
        }

        var baseUrl = $"{request.Scheme}://{request.Host}{request.PathBase}";
        var fileUrl = $"{baseUrl}/uploads/{fileName}";

        return fileUrl;
    }
}