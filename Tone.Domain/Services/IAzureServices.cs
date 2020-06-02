namespace Tone.Domain.Services
{
    public interface IAzureServices
    {
        bool UploadFile(string fileName, object file, string directory);
        bool DeleteFile(string fileName, string directory);
    }
}