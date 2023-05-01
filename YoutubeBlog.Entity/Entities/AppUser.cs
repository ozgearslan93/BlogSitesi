using Blogosphere.Entity.Abstract.Entities;
using Microsoft.AspNetCore.Identity;

namespace YoutubeBlog.Entity.Entities
{
    public class AppUser : IdentityUser<Guid>, IEntityBase
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid? ImageId { get; set; } = Guid.Parse("10b81d81-712d-4021-9470-316452508d2a");

        // her yeni kullanıcı eklendiginde otomatık olarak user-images e eklemiş oldugumuz profile avatar resmi ekleniyor olacak. bu resmin ıd sine veritabanından ulaşıp buraya eklemiş olduk.
        public Image Image { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
