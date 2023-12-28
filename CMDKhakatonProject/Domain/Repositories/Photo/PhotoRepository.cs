using CMDKhakatonProject.Domain.Interfaces;

namespace CMDKhakatonProject.Domain.Repositories.Photo
{
    public class PhotoRepository : IPhotoRepository
    {
        private string _uploadDirectory = "photos";

        public string UploadAsBase64(IFormFile photo)
        {
            {
                if (photo == null)
                {
                    throw new ArgumentNullException(nameof(photo));
                }

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    photo.CopyTo(memoryStream);
                    byte[] fileBytes = memoryStream.ToArray();
                    return Convert.ToBase64String(fileBytes);
                }
            }
        }

        public string[] UploadAsBase64(IFormFile[] file)
        {
            string[] photos = new string[file.Length];

            for (int i = 0; i < file.Length; i++)
            {
                photos[i] = UploadAsBase64(file[i]);
            }

            return photos;
        }
    }
}
