using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Interfaces
{
    public interface IService<T>
    {
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task Delete(int id);
        Task<List<T>> Search(Expression<Func<T, bool>> expr); //Expresión como parametro, el cual va a ser una función que va a evaluar el tipo, donde esa evaluación sea True //Busca y regresa un listado
        Task<T> Find(Expression<Func<T, bool>> expr); //Regresa un solo registro
        Task<T> SearchById(int id);
        Task<List<T>> List();
        Task<bool> Any(Expression<Func<T, bool>> expr);//Regresa un bool si existe el registro
    }
}
