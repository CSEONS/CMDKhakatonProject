using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CMDKhakatonProject.Domain.Entities
{
    public class Dish
    {
        public Guid Id { get; set; }
        public Guid? RestourantId { get; set; }
        public Restaurant? Restourant { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double CookinTime { get; set; } 
        public virtual ICollection<Tag> Tags { get; set; }
        public string PreviewPhoto { get; set; }
        #region Attribute
        [NotMapped]
        #endregion
        public string PhotosJSON
        {
            get { return JsonConvert.SerializeObject(PreviewPhoto); }
            set { PhotosUrls = JsonConvert.DeserializeObject<string[]>(value); }
        }
        public string[] PhotosUrls { get; set; }
    }
}
