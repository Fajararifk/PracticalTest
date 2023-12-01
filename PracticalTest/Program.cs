using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PracticalTest;
using PracticalTest.BLL;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.Contracts.BLL;
using PracticalTest.DAL;
using PracticalTest.DTO;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddFluentValidation(opt =>
    {
        opt.ImplicitlyValidateChildProperties = true;
        opt.ImplicitlyValidateRootCollectionElements = true;
    });
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Practical Test Fajar Arif Kurniawan",
        Description = "Hello My Name is Fajar Arif Kurniawan",
        Contact = new OpenApiContact
        {
            Name = "Fajar Arif Kurniawan",
            Email = "fajar.ariev@gmail.com",
            Url = new Uri("https://id.linkedin.com/in/fajararifkurniawan")
        },
        Version = "v1"
    });

});
builder.Services.Configure<MyAPIClient>(
    builder.Configuration.GetSection("MyAPIClient")
);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
    opt => builder.Configuration.Bind("JWTSettings", opt));
builder.Services.AddScoped<ILoggerManager, LoggerManager>();
var logger = new LoggerConfiguration()
.ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .MinimumLevel.Debug()
    .WriteTo.File("logs/rumble-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext());
builder.Services.RegisterModules();
builder.Services.AddHttpClient();
builder.Services.AddLogging(opt =>
{
    opt.AddSerilog();
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var mapping = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PracticalTest_DBContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration
        .GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(opt =>
    {
        opt.SerializeAsV2=true;
    });
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
