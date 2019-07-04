namespace Sales.Common.Models
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class Gallery
    {
        [Key]
        public int GalleryId { get; set; }

        [Display(Name = "Nombre de galería")]
        public string GalleryName { get; set; }

       public int ShopId { get; set; }

        //public int ProductId { get; set; }

        /*[JsonIgnore]
        public virtual Product Product { get; set; }*/
        [JsonIgnore]
        public virtual Shop Shop { get; set; }
    }
}
