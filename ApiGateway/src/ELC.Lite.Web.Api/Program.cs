using ELC.Lite.SharedKernel.ConfigurationSettings;
using ELC.Lite.Web.Api.Setup;

namespace ELC.Lite.Web.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            builder.Configuration.Bind(IdentitySettings.CONFIG_NAME, IdentitySettings.Instance);
            builder.Configuration.Bind(CoreAppSettings.CONFIG_NAME, CoreAppSettings.Instance);


            builder.Services.AddControllers();
            builder.Services.AddSwaggerConfiguration();

            //builder.Services.AddAuthentication();

            builder.AddIdentityServices(IdentitySettings.Instance);
            builder.AddCoreAppServices(CoreAppSettings.Instance);
            builder.AddWebApiServices();

            var app = builder.Build();

            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI(options =>
            //    {
            //        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            //        options.RoutePrefix = string.Empty;
            //    });
            //    app.UseDeveloperExceptionPage();
            //}
            app.UseCustomSwagger();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors("AllowAll");
            app.UseAuthorization();
            app.UseAuthentication();



            app.MapControllers();

            app.Run();
        }
    }
}
