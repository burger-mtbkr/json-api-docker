using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Product.Json.Api.Infrastructure;
using Product.Json.Api.Middleware;
using Product.Json.Api.Repositories;
using Product.Json.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Product Json Api",
                    Description = "Demo Api with JSON db and docker hosting",
                    Version = "v1"
                });
            });
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);		
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{  
    app.UseDeveloperExceptionPage();			
}

  app.UseSwagger();
  app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Json Api v1"));

   app.UseMiddleware<ErrorMiddleware>();

			app.UseRouting();

            app.UseCors(x => x
             .AllowAnyMethod()
             .AllowAnyHeader()
             .SetIsOriginAllowed(origin => true) // allow any origin
             .AllowCredentials()); // allow credentials

app.UseAuthorization();

// To use this: Enable SSL in launchSettings.json and
// expose port 443 in Dockerfile
// app.UseHttpsRedirection();

app.MapControllers();

app.Run();
