namespace Sales.Common.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Mark
    {
        [Key]
        public int MarkId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre Marca")]
        public string MarkName { get; set; }

        /*[JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }*/

    }
}
