using EFCore.EntityFramework;
using EFCore.EntityFramework.Interfaces;
using EFCore.Services;
using EFCore.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EFCore
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
			services.AddMvc();
			services.AddDbContextPool<ApplicationDbContext>((options) => { options.UseSqlServer(Configuration.GetValue<string>("ConString"));});
			services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
			services.AddTransient(typeof(IEFRepository<>), typeof(EFRepository<>));
			services.AddTransient(typeof(IEFService<>), typeof(EFService<>));
			services.AddTransient<IOrderService, OrderService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				//endpoints.MapControllerRoute("default", "{controller=Order}/{action=Get}/{orderId?}");
			});
		}
	}
}