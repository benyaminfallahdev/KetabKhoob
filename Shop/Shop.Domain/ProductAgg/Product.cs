using Common.Domain;
using Common.Domain.Execptions;
using Common.Domain.Untils;
using Common.Domain.ValueObjects;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Domain.ProductAgg
{
    public class Product : AggregateRoot
    {

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ImageName { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SecondarySubCategoryId { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }

        public List<ProductImage> Images { get; set; }
        public List<ProductSpecification> Specifications { get; set; }

        public Product(string title, string description, string imageName, long categoryId, long subCategoryId,
    long secondarySubCategoryId, string slug, SeoData seoData, IProductDomainService domainService)
        {
            Guard(title, description, slug, imageName, domainService);
            Title = title;
            Description = description;
            ImageName = imageName;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }

        public void Edit(string title, string description, string imageName, long categoryId, long subCategoryId,
    long secondarySubCategoryId, string slug, SeoData seoData, IProductDomainService domainService)
        {
            Guard(title, description, slug, imageName, domainService);
            Title = title;
            Description = description;
            ImageName = imageName;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }

        public void AddImage(ProductImage productImage)
        {
            productImage.ProductId = this.Id;
            Images.Add(productImage);
        }
        public void RemoveImage(long imageid)
        {
            var image = Images.FirstOrDefault(x => x.Id == imageid);
            if (image != null)
                Images.Remove(image);
        }
        public void SetSpercification(List<ProductSpecification> specifications)
        {
            specifications.ForEach(s => s.ProductId = this.Id);
            Specifications = specifications;
        }

        public void Guard(string title, string description, string slug, string imageName,
            IProductDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(description, nameof(description));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

            if (slug != this.Slug)
                if (domainService.SlugIsExists(slug.ToSlug()))
                    throw new SlugIsDuplicateExecption();




        }
    }
    public class ProductImage : BaseEntity
    {
        public long ProductId { get; set; }
        public string ImageName { get; set; }
        public int Squence { get; set; }
    }
    public class ProductSpecification : BaseEntity
    {
        public ProductSpecification(string key, string value)
        {
            NullOrEmptyDomainDataException.CheckString(key, nameof(key));
            NullOrEmptyDomainDataException.CheckString(value, nameof(value));
            Key = key;
            Value = value;
        }

        public long ProductId { get; set; }
        public string Key { get; set; }
        public string Value { get; private set; }
    }



}
