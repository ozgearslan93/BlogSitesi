using Blogosphere.Entity.Abstract.Entities;
using System.Linq.Expressions;

namespace YoutubeBlog.Data.Repositories.Abstractions
{
    public interface IRepository<T> where T : class, IEntityBase, new()
    {
        Task AddAsync(T entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        //işlem yaparken işlemde sadece 1 veri geri dönsün istiyor isek kullanıcaz.örn: id si 2 olan veriyi silmek istiyoruz
        Task<T> GetByGuidAsync(Guid id); // bir tane id yollayıp buna karsılık gelen ıd yi bulabilecez
        Task<T> UpdateAsync(T entity);  //bir tane id yollayıp buna karsılık gelen ıd deki nesneyi güncelleyeceğiz 
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null); //entity içinde kac deger var tablodaki toplam degeri bize gosterecek
    }

}