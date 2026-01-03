using Common.Domain;

namespace Shop.Domain.SiteEntities
{
    public class Slider : BaseEntity
    {
        public Slider(string link, string title, string imageName)
        {
            Link = link;
            Title = title;
            ImageName = imageName;
        }
        public void Edit(string link, string title, string imageName)
        {
            Link = link;
            Title = title;
            ImageName = imageName;
        }

        public string Link { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }

    }



}
