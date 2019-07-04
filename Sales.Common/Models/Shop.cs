namespace Sales.Common.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Shop
    {
        [Key]
        public int ShopId { get; set; }

        public int SellerId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre de tienda")]
        public string ShopName { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Dirección de tienda")]
        public string ShopAddres { get; set; }

        [Display(Name = "Latitud")]
        public string Latitude { get; set; }

        [Display(Name = "Longitud")]
        public string Longitude { get; set; }

        [Display(Name = "N° Tel. tienda")]
        public string ShopPhone { get; set; }

        [NotMapped]
        public byte[] ImageArray { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImagePath))
                {
                    return "noproduct";
                }

                return $"https://salesbackend20190613034347.azurewebsites.net{this.ImagePath.Substring(1)}";
            }
        }

        [JsonIgnore]
        public virtual Seller Seller { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Gallery> Galleries { get; set; }
    }
}
