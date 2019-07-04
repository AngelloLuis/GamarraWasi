namespace Sales.Backend.Models
{
    using Sales.Common.Models;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class ShopView: Shop
    {
        [Display(Name = "Image")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}