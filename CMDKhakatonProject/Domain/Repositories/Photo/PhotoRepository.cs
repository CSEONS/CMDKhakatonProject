using CMDKhakatonProject.Domain.Interfaces;

namespace CMDKhakatonProject.Domain.Repositories.Photo
{
    public class PhotoRepository : IPhotoRepository
    {
        private string _uploadDirectory = "photos";

        public string Upload(IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
            {
                throw new ArgumentException("Photo is required");
            }

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
            string uploadPath = Path.Combine(_uploadDirectory, uniqueFileName);

            using (var fileStream = new FileStream(uploadPath, FileMode.Create))
            {
                photo.CopyTo(fileStream);
            }

            return uploadPath;
        }

        public void Delete(string photoPath)
        {
            if (File.Exists(photoPath))
            {
                File.Delete(photoPath);
            }
        }

        public string[] Upload(IFormFile[] files)
        {
            string[] urls = new string[files.Length];

            for (int i = 0; i < files.Length; i++)
            {
                urls[i] = Upload(files[i]);
            }

            return urls;
        }
    }
}
