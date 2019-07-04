
namespace Sales.Common.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "Nombre Vendedor")]
        public string SellerName { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "Apellido Paterno")]
        public string SellerFatherLastName { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "Apellido Materno")]
        public string SellerMomLastName { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "N° DNI")]
        public string SellerDni { get; set; }


        [JsonIgnore]
        public virtual ICollection<Shop> Shops { get; set; }

    }
}
