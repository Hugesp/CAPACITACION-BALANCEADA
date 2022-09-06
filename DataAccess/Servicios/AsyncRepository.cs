using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Servicios
{
    //Esta clase implementa todos los métodos
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class //Se le asigna un tipo de tipo clase
    {
        protected readonly DemoContext context;

        public AsyncRepository(DemoContext context)
        {
            this.context = context;
            //context.Configuration.ProxyCreationEnabled = false;
        }

        protected DbSet<T> EntitySet
        {
            get { 
                return context.Set<T>(); 
            }
        }
        //Este no es necesario
        public void Dispose()
        {
            if(context != null)
            {
                context.Dispose();
            }
        }

        public async Task<T> Add(T entity)
        {
            EntitySet.Add(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Any(Expression<Func<T, bool>> expr)
        {
            return await EntitySet.AnyAsync(expr);
        }

        public async Task Delete(T entity)
        {
            EntitySet.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<T> Find(Expression<Func<T, bool>> expr)
        {
            return await EntitySet.FirstOrDefaultAsync(expr); 
        }

        public async Task<List<T>> List()
        {
            return await EntitySet.ToListAsync();
        }

        public async Task<List<T>> Search(Expression<Func<T, bool>> expr)
        {
            return await EntitySet.Where(expr).ToListAsync();
        }

        public async Task<T> SearchById(int id)
        {
            return await EntitySet.FindAsync(id);
        }

        public async Task Update(T entity)
        {
            context.Entry(entity).State= EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
