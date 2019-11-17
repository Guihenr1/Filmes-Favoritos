using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain._Base;
using Api.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Ioc {
    public static class StartupIoc {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration["ConnextionString"]));
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped<UserStore>();
        }
    }
}
