﻿
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace ApiConcepts {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}
		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services) {
			services.AddSingleton<Data.MongoDB>();
			services.AddControllers();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});
		}
	}
}