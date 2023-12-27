namespace CMDKhakatonProject.Domain.Interfaces
{
    public interface IPhotoRepository
    {
        string Upload(IFormFile file);
        string[] Upload(IFormFile[] files);
        void Delete(string url);
    }
}
