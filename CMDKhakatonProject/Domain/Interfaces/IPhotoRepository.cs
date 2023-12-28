namespace CMDKhakatonProject.Domain.Interfaces
{
    public interface IPhotoRepository
    {
        string UploadAsBase64(IFormFile file);
        string[] UploadAsBase64(IFormFile[] file);
    }
}
