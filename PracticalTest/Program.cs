using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PracticalTest.BLL;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.Contracts.BLL;
using PracticalTest.DAL;
using PracticalTest.DTO;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*builder.Services.AddCors(opt =>
opt.AddPolicy("CorsPolicy", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
));*/
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
        Description = "This test for PT. Indo Online Mitra Usaha",
        Contact = new OpenApiContact
        {
            Name = "Fajar Arif Kurniawan",
            Email = "far@voxteneo.com",
            Url = new Uri("https://id.linkedin.com/in/fajararifkurniawan")
        },
        Version = "v1"
    });
   /* var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine("C:\\Users\\FajarArifKurniawan\\Documents", xmlFile);
    opt.IncludeXmlComments(xmlPath);*/

});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
    opt => builder.Configuration.Bind("JWTSettings", opt));
builder.Services.AddTransient<IValidator<SportEvents>, SportEventsValidator>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrganizerRepository, OrganizerRepository>();
builder.Services.AddScoped<ISportEventsRepository, SportEventRepository>();
builder.Services.AddScoped<IUserBLL, UserBLL>();
builder.Services.AddScoped<IOrganizersBLL, OrganizersBLL>();
builder.Services.AddScoped<ISportEventsBLL, SportEventsBLL>();
builder.Services.AddScoped<ILoggerManager, LoggerManager>();
var logger = new LoggerConfiguration()
.ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .MinimumLevel.Debug()
    .WriteTo.File("logs/rumble-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Host.UseSerilog();
builder.Services.AddLogging(opt =>
{
    opt.AddSerilog();
});
//builder.Services.AddScoped<IMapper, Mapper>();
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
