using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    //En la interface solo se definen los métodos
    //Esto nos puede ayudar si posteriormente se realiza un cambio de motor de base de datos, pero se sigue usando la misma logica, ya solo se modifica la clase que implementa
    public interface IAsyncRepository<T>
    {
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<List<T>> Search(Expression <Func<T, bool>> expr); //Expresión como parametro, el cual va a ser una función que va a evaluar el tipo, donde esa evaluación sea True //Busca y regresa un listado
        Task<T> Find(Expression<Func<T, bool>> expr); //Regresa un solo registro
        Task<T> SearchById(int id);
        Task<List<T>> List();
        Task<bool> Any(Expression<Func<T, bool>> expr);//Regresa un bool si existe el registro
    }
}
