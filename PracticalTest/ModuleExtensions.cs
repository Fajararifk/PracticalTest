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
            services.AddScoped<ISportEventsRepository, SportEventRepository>();
            services.AddScoped<IUserBLL, UserBLL>();
            services.AddScoped<IOrganizersBLL, OrganizersBLL>();
            services.AddScoped<ISportEventsBLL, SportEventsBLL>();
            services.AddScoped<ILoginToAPI, LoginToAPI>();
            services.AddScoped<IMethodFromAPI, MethodFromAPI>();
            return services;
        }
    }
}
