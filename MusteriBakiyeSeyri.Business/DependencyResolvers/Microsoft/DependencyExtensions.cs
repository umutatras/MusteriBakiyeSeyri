using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusteriBakiyeSeyri.Business.Interfaces;
using MusteriBakiyeSeyri.Business.Services;
using MusteriBakiyeSeyri.DataAccess.Context;
using MusteriBakiyeSeyri.DataAccess.UnitOfWork;

namespace MusteriBakiyeSeyri.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MusteriBakiyeSeyriDb>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMusteriTanimService, MusteriTanimService>();
            services.AddScoped<IMusteriFaturaService, MusteriFaturaService>();
        }
    }

}
