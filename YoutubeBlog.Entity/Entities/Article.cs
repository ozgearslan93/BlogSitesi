using Blogosphere.Entity.Abstract.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class Article : EntityBase
    //katmanlar arasında kalıtım almak istersek örn burda oldugu gibi youtubeblog.entity e gelip sag tık yaptıktan sonra add diyip project referance diyerek kalıtım almak istedigimiz katmanı ekliyoruz .Burda youtubeblog.core u secerek ilerliyoruz.
    //ctrl+r+g üzerideki fazla using satırlarını gizler
    {
        public Article()
        {

        }
        public Article(string title, string content, Guid userId, string createdBy, Guid categoryId, Guid imageId)
        {
            Title = title;
            Content = content;
            UserId = userId;
            CreatedBy = createdBy;
            CategoryId = categoryId;
            ImageId = imageId;
        }

        //kod okunabilirliği acısından article new'lendiginde ne içine ne yazılması gerektıgını bu uygulamayı yazan dısında da birinin bu kod bloklarına bakmadan anlayabilmesi acısından bu sekilde constructors metot olusturuyoruz.

       
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; } = 0;

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid? ImageId { get; set; }
        public Image Image { get; set; }

        public Guid UserId { get; set; }
        public  AppUser User { get; set; }


        public  ICollection<ArticleVisitor> ArticleVisitors { get; set; }
    }
}
