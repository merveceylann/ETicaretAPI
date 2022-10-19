using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ETicaretAPI.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;
        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>(); //burada contexteki butun tablolara ulasmamiz gerektigi icin (DbSet generic oldugu icin) Set<T> parametresi ile kolayca ulasmis olduk

        public IQueryable<T> GetAll(bool tracking = true)
        //=> Table;
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        //=> Table.Where(method);
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        //=> await Table.FirstOrDefaultAsync(method);
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        //  => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        //burada marker pattern mantigi ile degisiklik yapılmasaydi
        //hata verecekti ve reflection ile daha uzun sürede duzeltilecekti.
        //bu cozum de gecerli fakat bunun yerine entity framaworkun find metodunu da kullanacagiz
        //=> await Table.FindAsync(Guid.Parse(id));
        {
            var query = Table.AsQueryable();   //şurda aslında querye ilk tracking mekanizmasını attın aslında 
            if (!tracking)
                query = query.AsNoTracking();  //burada da o değeri no tracking olarak feğiştiriceksin 
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }
    }
}
