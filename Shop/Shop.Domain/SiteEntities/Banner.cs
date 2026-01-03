using Common.Domain;

namespace Shop.Domain.SiteEntities
{
    public class Banner : BaseEntity
    {
        public Banner(string link, string imageName, BannerPosition position)
        {
            Link = link;
            ImageName = imageName;
            Position = position;
        }

        public void Edit(string link, string imageName, BannerPosition position)
        {
            Link = link;
            ImageName = imageName;
            Position = position;
        }

        public string Link { get; set; }
        public string ImageName { get; set; }
        public BannerPosition Position { get; set; }
    }

    public enum BannerPosition
    {
        زیر_اسلایدر,
        سمت_راست_اسلایدر
    }
}
