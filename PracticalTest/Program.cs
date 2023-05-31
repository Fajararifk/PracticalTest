using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using PracticalTest.BLL;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.Contracts.BLL;
using PracticalTest.DAL;
using PracticalTest.DTO;
using Serilog;

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
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
