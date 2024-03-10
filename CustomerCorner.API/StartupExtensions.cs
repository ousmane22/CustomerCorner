using CustomerCorner.Application;
using CustomerCorner.Persistence;

namespace CustomerCorner.API
{
    public static class StartupExtensions
    {
        public static  WebApplication ConfigureServices
            (this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);

            builder.Services.AddControllers();

            builder.Services.AddCors(
                options => options.AddPolicy(
                    "open",
                    policy => policy.WithOrigins(builder.Configuration["ApiUrl"] ??
                    "http://localhost:6219")

                    .AllowAnyMethod()
                    .SetIsOriginAllowed(pol => true)
                    .AllowAnyHeader()
                    .AllowCredentials()));

            builder.Services.AddSwaggerGen();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline
            (this WebApplication app)
        {
            app.UseCors("open");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapControllers();

            return app;
        }
    } 
}
