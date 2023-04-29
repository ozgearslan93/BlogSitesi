using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;
using YoutubeBlog.Entity.Entities;



namespace YoutubeBlog.Data.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<ArticleVisitor> ArticleVisitor { get; set; }

     
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); //bir migration olusturdugumuzda bu identity yapısından dolayı bazı hataları almamak için yapıldı

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //tüm mapping sınıflarının burda tanımlanmıs olmasını beklıyoruz

         //ApplyConfiguration metodu, veritabanı nesneleri için oluşturulan Fluent API yapılandırma sınıflarının (EntityTypeConfiguration sınıfları) nesnelerine uygulanır. Bu yöntem, örneğin, bir varlık nesnesinin belirli bir özelliğinin sütun adını veya veri tipini değiştirme, ilişkiyi yapılandırma, tablo adını veya başka bir tablo oluşturma ayarını değiştirme vb. gibi yapılandırmaları ayarlamak için kullanılabilir.

            //*protected override void* model olusturulmadan once yapabılecegımız bir konfigürasyon(uygulamaların çalışması sırasında belirli ayarları veya yapılandırmaları tutmak için konfigürasyon dosyaları kullanır) saglayacak. 
        }
    }
}
