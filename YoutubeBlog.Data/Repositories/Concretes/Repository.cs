using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Core.Entities;
using YoutubeBlog.Data.Context;
using YoutubeBlog.Data.Repositories.Abstractions;

namespace YoutubeBlog.Data.Repositories.Concretes
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext dbContext;

        public Repository(AppDbContext dbContext)  //burada veritbanı ile ilişkilerimiz kontol edilecek
        {
            this.dbContext = dbContext;
        }
        private DbSet<T> Table { get => dbContext.Set<T>(); }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            return await query.ToListAsync();
        }
        //fonksiyona entity deger verip geriye bool deger donmesini istiyoruz
        //liste olarak entity i döncez.örn: liste olarak articlenin dönmesini isticez.

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = query.Where(predicate);
            
            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);
            return await query.SingleAsync(); // bir tane nesne dönecek

        }

        public async Task<T> GetByGuidAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity) //normalde update işlemleri asenkron olmaz listeleme yaparken aynanda guncelleme islemlerinde karmasa meydana gelebilir
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
            
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate is not null)
                 return await Table.CountAsync(predicate);
            return await Table.CountAsync();
        }


        // T nesnesi her bir entity mizi(Article,Category ve Image) kapsıyor. 
        // where T : class demekte T tipini bunsuz anlamıyor. o yüzden bu sekilde T nin klas oldugunu belirtiyoruz
        // IEntityBase , new() daha önceden belirlediğimiz interface i cagırıp new lenebileceğini belirtiyoruz
        // Task= void ile aynı şey asenkron programlamadaki void in karsılıgı gibidir. yani geriye değer döndürmez
    }

}
