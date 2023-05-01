using Blogosphere.Entity.Abstract.Entities;
using YoutubeBlog.Data.Repositories.Abstractions;

namespace YoutubeBlog.Data.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T :class,IEntityBase ,new();
        Task<int> SaveAsync();
        int Save(); //asenkron olarak kullanamayacagımız bir durum olursa diye ayrıca bu metotu da olusturduk
    }
}
