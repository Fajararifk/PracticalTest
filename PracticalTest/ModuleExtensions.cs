﻿using FluentValidation;
using PracticalTest.BLL;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts.BLL;
using PracticalTest.Contracts;
using PracticalTest.DAL;
using PracticalTest.DAL.Implement;
using PracticalTest.DTO;

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
            services.AddScoped<IAuthenticationGenerate, AuthenticationGenerates>();
            services.AddScoped<IMethodFromAPI, MethodFromAPI>();
            services.AddScoped<IRepositoryCallAPI, RepositoryCallAPI>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUsersBLL, UsersBLL>();
            services.AddScoped<IAuthenticationGenerate, AuthenticationGenerates>();
            services.AddScoped<MyAPIClient, MyAPIClient>();
            services.AddScoped<URLBase, URLBase>();
            return services;
        }
    }
}
