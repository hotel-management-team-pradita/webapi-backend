namespace hotel_management_backend.Utilities;

class UploadUtils
{
    public static async Task<string> UploadImage(IFormFile image)
    {
        var uploads = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
        if (!Directory.Exists(uploads))
        {
            Directory.CreateDirectory(uploads);
        }

        var filePath = Path.Combine(uploads, image.FileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await image.CopyToAsync(fileStream);
        }

        return filePath;
    }
}