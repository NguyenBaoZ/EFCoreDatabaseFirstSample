//the entry point to our application
// configure the embedded or custom services that our application needs.

using Autofac;
using EFCoreDatabaseFirstSample.DTOs;
using EFCoreDatabaseFirstSample.Models;
using EFCoreDatabaseFirstSample.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;

// The CreateDefaultBuilder(args) method encapsulates the UseKestrel() or the UseIISIntegration() and makes this code more readable,
// Sets the default files and variables for the project and logger configuration
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//This method registers only the
//controllers in IServiceCollection
//builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(gen =>
{
    gen.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Book Store Database First First API Testing"
    });

});

IConfiguration config = new ConfigurationBuilder().
                        SetBasePath(Directory.GetCurrentDirectory()).
                        AddJsonFile("appsettings.json").
                        Build();

builder.Services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(config.GetConnectionString(("sqlConnection"))));
//builder.Services.AddDbContext<BookStoreContext>(options => options.UseSqlServer("Data Source=.;Initial Catalog=BookStore;Integrated Security=True;"));

// Fix bug: A possible object cycle was detected
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler =  ReferenceHandler.IgnoreCycles);

//var containerBuilder = new ContainerBuilder();

//containerBuilder.RegisterType<AuthorRepository>().As<IAuthorRepository>();
builder.Services.AddScoped<IRepositoryManager,RepositoryManager>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHsts();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
 