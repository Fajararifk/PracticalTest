using FluentValidation;
using PracticalTest.BLL;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts.BLL;
using PracticalTest.Contracts;
using PracticalTest.DAL;
using PracticalTest.DAL.Implement;

namespace PracticalTest
{
    public static partial class ModuleExtensions
    {
        public static IServiceCollection RegisterModules(this IServiceCollection services)
        {
            services.AddTransient<IValidator<SportEvents>, SportEventsValidator>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrganizerRepository, OrganizerRepository>();
            services.AddScoped<IUserBLL, UserBLL>();
            services.AddScoped<IOrganizersBLL, OrganizersBLL>();
            services.AddScoped<IAuthenticationGenerate, AuthenticationGenerates>();
            services.AddScoped<IMethodFromAPI, MethodFromAPI>();
            services.AddScoped<IRepositoryCallAPI, RepositoryCallAPI>();
            return services;
        }
        public static IServiceCollection SportEventsModules(this IServiceCollection services)
        {
            services.AddScoped<ISportEventsRepository, SportEventRepository>();
            services.AddScoped<ISportEventsBLL, SportEventsBLL>();
            return services;
        }
    }
}
