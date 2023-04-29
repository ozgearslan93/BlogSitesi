using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class Visitor : IEntityBase
    {
        public Visitor() { }

        public Visitor( string ipAddress, string userAgent)
        {
            
            IpAddress = ipAddress;
            UserAgent = userAgent;
        }

        public int Id { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; } //kullanıcılar bizim sitemize nasıl girmiş (mobilden mi tarayıcıdanmı vs)
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual ICollection<ArticleVisitor> ArticleVisitors { get; set; }
    }
}
