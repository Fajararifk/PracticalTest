using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PracticalTest.BLL;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using PracticalTest.Contracts.BLL;
using PracticalTest.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*builder.Services.AddCors(opt =>
opt.AddPolicy("CorsPolicy", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
));*/
builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrganizerRepository, OrganizerRepository>();
builder.Services.AddScoped<ISportEventsRepository, SportEventRepository>();
builder.Services.AddScoped<IUserBLL, UserBLL>();
builder.Services.AddScoped<IOrganizersBLL, OrganizersBLL>();
builder.Services.AddScoped<ISportEventsBLL, SportEventsBLL>();
builder.Services.AddScoped<ILoggerManager, LoggerManager>();
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
