﻿using Microsoft.Extensions.DependencyInjection;
using School.Application;
using School.Domain.Repositories;

namespace School.Infra.CrossCutting;

public static class NativeInjectionExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IStudentServices, StudentServices>();
    }
}