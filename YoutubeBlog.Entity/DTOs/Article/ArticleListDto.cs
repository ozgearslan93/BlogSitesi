using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YoutubeBlog.Entity.DTOs.Articles
{
    public class ArticleListDto
    {

        public IList<YoutubeBlog.Entity.Entities.Article> Articles { get; set; }
        public Guid? CategoryId { get; set; }
        public virtual int CurrentPage { get; set; } = 1; //program basladıgında 1. sayfadan baslayacagımızı belirtiyoruz burda.
        public virtual int PageSize { get; set; } = 3; // sayfamızda 3 tane makale listelemek istedigimizi belirliyoruz 
        public virtual int TotalCount { get; set; } // kactane sayfa yapımız olacagını belirliyoruz 1-2-3-4 gibi
        public virtual int TotalPages => (int)Math.Ceiling(decimal.Divide(TotalCount, PageSize)); // Ceiling ondalık sayı cıkarsa karsısına 1,1 bile olsa sayıyı bir üst sayıya yıvarlar sayı 2 olmus olur
        public virtual bool ShowPrevious => CurrentPage > 1;  //ShowPrevious 1. sayfaada ise daha kucuk sayfa yoktur
        public virtual bool ShowNext => CurrentPage < TotalPages; // 10 tane sayfa varsa daha fazlasına gidememek adına isaret koyuyoruz
        public virtual bool IsAscending { get; set; } = false;
    }
}
