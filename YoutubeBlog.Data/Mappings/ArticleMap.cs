using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    internal class ArticleMap : IEntityTypeConfiguration<Article>
    {
        void IEntityTypeConfiguration<Article>.Configure(EntityTypeBuilder<Article> builder)
        {

            builder.HasData(new Article
            {
                Id = Guid.NewGuid(),
                Title = "Asp.net Core Deneme Makalesi 1",
                Content = "Asp.net Core Lorem ipsum dolor sit amet consectetur adipiscing elit posuere vivamus, potenti habitant bibendum luctus lacus mus non risus. Dis habitant est suscipit nunc iaculis non mollis mi nibh rhoncus dignissim facilisi, laoreet per id pretium vivamus bibendum sociis ultricies facilisis auctor. Etiam at eleifend montes lacinia orci molestie pellentesque ultrices, nam nec maecenas varius facilisis duis non, fusce hendrerit habitasse dictum himenaeos cras nulla. Sem primis curabitur diam pretium vel etiam laoreet, sociis scelerisque mattis nascetur dis ullamcorper magna, velit ultricies auctor potenti molestie gravida. Tempus cursus augue lectus purus porta massa blandit arcu, hac ac rutrum nostra cum sagittis tristique venenatis, porttitor dictumst egestas euismod ligula aenean suscipit.",
                ViewCount = 15,
               
                CategoryId= Guid.Parse("18C390E3-807F-4890-B74D-A3B0BD6B2364"),
                ImageId= Guid.Parse("4B7E17F3-1096-443D-A24F-CA83DE5B740B"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                UserId= Guid.Parse("28235D4C-8428-47B8-96C3-7AE23EBAFCA9"),


            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Visual studio Deneme Makalesi 1",
                Content = "Visual studio Lorem ipsum dolor sit amet consectetur adipiscing elit posuere vivamus, potenti habitant bibendum luctus lacus mus non risus. Dis habitant est suscipit nunc iaculis non mollis mi nibh rhoncus dignissim facilisi, laoreet per id pretium vivamus bibendum sociis ultricies facilisis auctor. Etiam at eleifend montes lacinia orci molestie pellentesque ultrices, nam nec maecenas varius facilisis duis non, fusce hendrerit habitasse dictum himenaeos cras nulla. Sem primis curabitur diam pretium vel etiam laoreet, sociis scelerisque mattis nascetur dis ullamcorper magna, velit ultricies auctor potenti molestie gravida. Tempus cursus augue lectus purus porta massa blandit arcu, hac ac rutrum nostra cum sagittis tristique venenatis, porttitor dictumst egestas euismod ligula aenean suscipit.",
                ViewCount = 15,
                CategoryId= Guid.Parse("E4D869D1-37A8-4B5D-9712-E9DA0A2B193C"),
                ImageId= Guid.Parse("DF826779-4901-4E2F-AB80-4F1CE6033ED1"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                UserId= Guid.Parse("62A1399A-9802-41EA-9B25-68C523AF5783")

            }

            );
            
            //builder.Property(x => x.Title).HasMaxLength(150);
            //builder.Property(x => x.Title).IsRequired(false);       //null olarak gecilebilmesine izin veriyoruz.default degeri true geliyor
        }
    }
}
