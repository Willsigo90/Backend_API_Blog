using LibreriaBlog.Implementaciones;
using LibreriaBlog.Interfaces;
using Microsoft.Extensions.DependencyInjection;

using ServicioBlog.Implementaciones;
using ServicioBlog.Interfaces;

namespace JwtApp
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            //Inyectar acceso a datos
            services.AddTransient<IAccesoDatos, AccesoDatos>();

            // Inyectar servicios
            services.AddTransient<IPostServicio, PostServicio>();

            services.AddTransient<ICommentServicio, CommentServicio>();
            services.AddTransient<ILoginServicio, LoginServicio>();

            return services;
        }
    }
}
