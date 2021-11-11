using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore;
using Swagger.Services;

namespace _NetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "_NetCore", Version = "v1" });
            });
            services.AddScoped<UserService>();
            services.AddScoped<AdjustmentDetailsService>();
            services.AddScoped<AdjustmentService>();
            services.AddScoped<BrandService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<ClientService>();
            services.AddScoped<CurrencieService>();
            services.AddScoped<ExpenseCategorieService>();
            services.AddScoped<ExpenseService>();
            services.AddScoped<MigrationService>();
            services.AddScoped<oAuthAccessCodeService>();
            services.AddScoped<oAuthAccessTokenService>();
            services.AddScoped<oAuthClientService>();
            services.AddScoped<oAuthPersonalAccessClientService>();
            services.AddScoped<oAuthRefreshTokenService>();
            services.AddScoped<PasswordResetService>();
            services.AddScoped<PaymentPurchaseReturnService>();
            services.AddScoped<PaymentPurchaseService>();
            services.AddScoped<PaymentSaleReturnService>();
            services.AddScoped<PaymentSaleService>();
            services.AddScoped<PaymentWithCreditCardService>();
            services.AddScoped<PermissionRoleService>();
            services.AddScoped<PermissionService>();
            services.AddScoped<PermissionRoleService>();
            services.AddScoped<PosSettingService>();
            services.AddScoped<ProductService>();
            services.AddScoped<ProductVariantService>();
            services.AddScoped<ProductWareHouseService>();
            services.AddScoped<ProvidersService>();
            services.AddScoped<PurchaseDetailService>();
            services.AddScoped<PurchaseReturnDetailService>();
            services.AddScoped<PurchaseReturnService>();
            services.AddScoped<PurchaseService>();
            services.AddScoped<QuotationDetailService>();
            services.AddScoped<QuotationService>();
            services.AddScoped<RelationalSchemaService>();
            services.AddScoped<RoleService>();
            services.AddScoped<RoleUserService>();
            services.AddScoped<SaleDetailService>();
            services.AddScoped<SaleReturnDetailService>();
            services.AddScoped<SaleReturnService>();
            services.AddScoped<SaleService>();
            services.AddScoped<ServerService>();
            services.AddScoped<TransferDetailService>();
            services.AddScoped<TransferService>();
            services.AddScoped<UnitService>();
            services.AddScoped<WareHouseService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "_NetCore v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
