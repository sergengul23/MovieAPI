using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Store.BUSINESS.DTOs.RequestDTOs;
using Store.BUSINESS.Validators.ActorValidators;
using Store.BUSINESS.Validators.DirectorValidators;
using Store.BUSINESS.Validators.GenreValidators;
using Store.BUSINESS.Validators.MovieValidators;
using Store.DATA.Abstract.UOW;
using Store.DATA.Concrete.UOW;
using System.Reflection;

namespace Store.BUSINESS.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static void RegisterHandlers(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<CreateMovieDTO>, CreateMovieDTOValidator>();
            services.AddSingleton<IValidator<UpdateMovieDTO>, UpdateMovieDTOValidator>();

            services.AddSingleton<IValidator<CreateActorDTO>, CreateActorDTOValidator>();
            services.AddSingleton<IValidator<UpdateActorDTO>, UpdateActorDTOValidator>();

            services.AddSingleton<IValidator<CreateGenreDTO>, CreateGenreDTOValidator>();
            services.AddSingleton<IValidator<UpdateGenreDTO>, UpdateGenreDTOValidator>();

            services.AddSingleton<IValidator<CreateDirectorDTO>, CreateDirectorDTOValidator>();
            services.AddSingleton<IValidator<UpdateDirectorDTO>, UpdateDirectorDTOValidator>();
        }

        public static IServiceCollection LoadMyService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            return serviceCollection;
        }
    }
}
