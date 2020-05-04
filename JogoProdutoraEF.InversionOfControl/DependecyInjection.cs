using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoProdutoraEF.Data;
using JogoProdutoraEF.Data.Repositories;
using JogoProdutoraEF.Domain.Model.Interfaces.Repositories;
using JogoProdutoraEF.Domain.Model.Interfaces.Services;
using JogoProdutoraEF.Domain.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JogoProdutoraEF.InversionOfControl
{
    public static class DependecyInjection
    {
        public static void Register(
            IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<JogoProdutoraContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("JogoProdutoraContext")));

            services.AddScoped<IJogoService, JogoService>();
            services.AddScoped<IJogoRepository, JogoRepository>();
        }
    }
}
