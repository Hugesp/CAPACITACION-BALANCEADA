using BussinesLogic.Interfaces;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Servicios
{
    public class Service<T> : IService<T> where T : class
    {
        protected readonly IAsyncRepository<T> repository;

        public Service(IAsyncRepository<T> repository)
        {
            this.repository = repository;
        }

        public async Task<T> Add(T entity)
        {
            return await repository.Add(entity);
        }

        public async Task<bool> Any(Expression<Func<T, bool>> expr)
        {
            return await repository.Any(expr);
        }

        public async Task Delete(T entity)
        {
            await repository.Delete(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await repository.SearchById(id);
            await repository.Delete(entity);
        }

        public async Task<T> Find(Expression<Func<T, bool>> expr)
        {
            return await repository.Find(expr);
        }

        public async Task<List<T>> List()
        {
            return await repository.List();
        }

        public async Task<List<T>> Search(Expression<Func<T, bool>> expr)
        {
            return await repository.Search(expr);
        }

        public async Task<T> SearchById(int id)
        {
            return await repository.SearchById(id);
        }

        public async Task Update(T entity)
        {
            await repository.Update(entity);
        }
    }
}
