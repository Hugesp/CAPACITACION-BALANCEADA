using DataAccess.Interfaces;
using DataAccess.Servicios;
using Microsoft.Extensions.DependencyInjection;

namespace BussinesLogic
{
    public static class DependencyInjectionExtension
    {
        //Clase static disponible para todo el proyecto, no necesita ser instanciada
        public static void AddDaServices(this IServiceCollection services)//this métodos extensores deja agregar comportamiento sin necesidad de heredar
        {
            services.AddScoped(typeof(IAsyncRepository<>) , typeof(AsyncRepository<>));
        }
    }
}
