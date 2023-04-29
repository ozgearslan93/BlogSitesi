using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Data.Context;
using YoutubeBlog.Data.Repositories.Abstractions;
using YoutubeBlog.Data.Repositories.Concretes;
using YoutubeBlog.Data.UnitOfWorks;

namespace YoutubeBlog.Data.Extensions
{
    public static class DataLayerExtensions
    {
        public static  IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));

            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>(); //her IUnitOfWork istendiğinde bana UnitOfWork örnegı olustursun

            //AddScoped bağımlılık enjeksiyonu yapısında, servislerin hayat döngüsünü belirlemek için kullanılır.ırepostory cagırdımızda bize repository döndurucek

            return services;
        }
    }

    //IServiceCollection, .NET Core ve ASP.NET Core uygulamalarında, bağımlılık enjeksiyonunu sağlamak için kullanılan bir arayüzdür. Bu arayüz, uygulamanın tüm servislerinin (örneğin, veritabanı bağlantısı, e-posta gönderimi, vb.) yapılandırmasına olanak tanır ve bu servislerin hangi sınıflardan oluşturulacağı, ne kadar süreyle yaşayacağı, vb. gibi detayları belirler.
}
//program.cs dosyasını olabildigince temiz tutabilmek için bu katmanı oluşturuyoruz
