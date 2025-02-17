﻿using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using System.Diagnostics.CodeAnalysis;
using Z.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interfaces;
using Persistence.Repositories.Implementations;
using AutoMapper;
using Persistence.DbInitializer;

namespace Persistence;

public static class PersistenceModule
{
    public static void AddPersistenceModule([NotNull] this IServiceCollection services,
        [NotNull] IConfiguration configuration)
    {
        EntityFrameworkManager.IsCommunity = true;

        string connectionString = configuration.GetConnectionString("DefaultConnection")!;

        services.AddDbContext<HospitalContext>(options =>
        {
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
            options.UseLazyLoadingProxies();
            options.UseNpgsql(connectionString, x =>
            {
                x.EnableRetryOnFailure(2);
                x.CommandTimeout(5);
            });
            options.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.BoolWithDefaultWarning));
        });


        services.AddTransient<INameRepository, NameRepository>();
        services.AddTransient<IPatientRepository, PatientRepository>();
        services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();


        AddAutomapper(services);
    }

    private static void AddAutomapper(IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc => mc.AddMaps(typeof(PersistenceModule).Assembly));

        var mapper = mapperConfig.CreateMapper();

        mapperConfig.AssertConfigurationIsValid();

        services.AddSingleton(mapper);
    }
}
