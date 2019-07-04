
namespace Sales.Domain.Models
{
    using System.Data.Entity.ModelConfiguration;
    using Common.Models;

    internal class GalleriesMap : EntityTypeConfiguration<Gallery>
    {
        public GalleriesMap()
        {
        }
    }
}