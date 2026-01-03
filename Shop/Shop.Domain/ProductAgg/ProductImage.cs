using Common.Domain;

namespace Shop.Domain.ProductAgg
{
    public class ProductImage : BaseEntity
    {
        public long ProductId { get; set; }
        public string ImageName { get; set; }
        public int Squence { get; set; }
    }



}
