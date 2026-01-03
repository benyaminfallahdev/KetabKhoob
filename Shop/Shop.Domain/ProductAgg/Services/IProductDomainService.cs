namespace Shop.Domain.ProductAgg.Services
{
    public interface IProductDomainService
    {
        public bool SlugIsExists(string slug);
    }
}
