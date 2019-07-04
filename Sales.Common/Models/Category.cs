namespace Sales.Common.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        [Display(Name = "Imagen")]
        public string ImagePath { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }

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
    }
}