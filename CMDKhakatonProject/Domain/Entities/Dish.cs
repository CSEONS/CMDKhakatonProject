using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CMDKhakatonProject.Domain.Entities
{
    public class Dish
    {
        public string Id { get; set; }
        public string? RestourantId { get; set; }
        public Restaurant? Restourant { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double CookinTime { get; set; } 
        public double Rating { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public string PreviewPhoto { get; set; }
        /*#region Attribute
        [NotMapped]
        #endregion
        public string PhotosJSON
        {
            get { return JsonConvert.SerializeObject(PreviewPhoto); }
            set { PhotosBase64 = JsonConvert.DeserializeObject<string[]>(value); }
        }
        public string[] PhotosBase64 { get; set; }*/
    }
}
