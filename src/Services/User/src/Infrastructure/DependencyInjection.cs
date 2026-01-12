using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Common.Interfaces;
using User.Infrastructure.Data;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Infrastructure 层的服务注册
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            string connectionString)
        {
            // 注册 DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // 注册接口实现
            services.AddScoped<IApplicationDbContext>(sp =>
                sp.GetRequiredService<ApplicationDbContext>());

            // 添加这一行：注册 Initialiser
            services.AddScoped<ApplicationDbContextInitialiser>();

            return services;
        }
    }
}
