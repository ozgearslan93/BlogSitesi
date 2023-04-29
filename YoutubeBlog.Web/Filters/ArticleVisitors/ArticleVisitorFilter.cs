using Microsoft.AspNetCore.Mvc.Filters;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Web.Filters.ArticleVisitors
{
    public class ArticleVisitorFilter : IAsyncActionFilter  //sitemize giren kişilerin bilgilerini kaydedebilecegimiz bi yapı. middleware gibi 
    {
        private readonly IUnitOfWork unitOfWork;

        public ArticleVisitorFilter(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        //public bool Disable { get;set; }

        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {


            List<Visitor> visitors = unitOfWork.GetRepository<Visitor>().GetAllAsync().Result;


            string getIp = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            string getUserAgent = context.HttpContext.Request.Headers["User-Agent"];

            Visitor visitor = new(getIp, getUserAgent);

            //1-Önce tüm visitorlarımızı alıyoruz.
            //2-Ulastıgımız visitorlardan veritabanımızda var ise bir daha kayıt olusturmamıza gerek kalmayacak.
            //Siteye giris yapan user eger daha oncekı visitor de var ıse next diyerek o kişiyi kaydetmıyoruz

            if (visitors.Any(x => x.IpAddress == visitor.IpAddress)) 
                return next(); //efer visitor var ise kaydetmeden devam et diyoruz
            else
            {
                unitOfWork.GetRepository<Visitor>().AddAsync(visitor);
                unitOfWork.Save();
            }
            return next();

        }
    }
}

