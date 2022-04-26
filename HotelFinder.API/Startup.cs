using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.API
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //SINGLETON DESIGN PATTERN
            //Constructorda IHotelService'a ihtiyaç duyuyorsa ona HotelManager üret
            services.AddSingleton<IHotelService, HotelManager>();

            //Constructorda IHotelRepository'a ihtiyaç duyuyorsa ona HotelRepository üret
            services.AddSingleton<IHotelRepository, HotelRepository>();

            //swagger servisi
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = (doc =>
                  {
                      doc.Info.Title = "All Hotels API";
                      doc.Info.Version = "1.1.1";
                      doc.Info.Contact=new NSwag.OpenApiContact()
                      {
                          Name="Oðuzhan Öztekin",
                          Url="ogzhnoztkn.com",
                          Email="ogzhnoztkn46@gmail.com"
                        };
                  });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseOpenApi();//swagger
            app.UseSwaggerUi3();//swagger
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
