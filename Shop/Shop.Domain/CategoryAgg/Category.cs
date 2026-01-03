using Common.Domain;
using Common.Domain.Execptions;
using Common.Domain.Untils;
using Common.Domain.ValueObjects;

namespace Shop.Domain.CategoryAgg
{
    public class Category : AggregateRoot
    {
        public Category(string title, string slug, SeoData seoData, ICategoryDomainService service)
        {
            Title = title;
            Slug = slug;
            SeoData = seoData;
        }

        public string Title { get; private set; }
        public string? Slug { get; private set; }
        public SeoData SeoData { get; private set; }

        public List<Category> Childs { get; private set; }

        public long? ParentId { get; private set; }

        public void Edit(string title, string slug, SeoData seoData, ICategoryDomainService service)
        {
            Guard(title, slug, service);
            Title = title;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }

        public void Guard(string title, string slug, ICategoryDomainService service)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));


            if (slug != this.Slug)
                if (service.SlugIsExist(slug.ToSlug()))
                    throw new SlugIsDuplicateExecption();

        }

        public void AddChild(string title, string slug, SeoData seoData, ICategoryDomainService service)
        {
            Childs.Add(new Category(title, slug, seoData, service)
            {
                ParentId = this.Id
            });
        }


    }
}
