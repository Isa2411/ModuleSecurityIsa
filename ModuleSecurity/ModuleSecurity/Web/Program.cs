using Business.Implements;
using Business.Interface;
using Data.Implements;
using Data.Interfaces;
using Entity.Context;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//Configurar DBContext con My Sql
builder.Services.AddDbContext<ApplicationDBContext>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection")));

builder.Services.AddScoped<IModuleBusiness, ModuleBusiness>();
builder.Services.AddScoped<IModuleData, ModuleData>();
builder.Services.AddScoped<IPersonBusiness, PersonBusiness>();
builder.Services.AddScoped<IPersonData, PersonData>();
builder.Services.AddScoped<IRoleBusiness, RoleBusiness>();
builder.Services.AddScoped<IRoleData, RoleData>();
builder.Services.AddScoped<IRoleViewBusiness, RoleViewBusiness>();
builder.Services.AddScoped<IRoleViewData, RoleViewData>();
builder.Services.AddScoped<IUserBusiness, UserBusiness>();
builder.Services.AddScoped<IUserData, UserData>();
builder.Services.AddScoped<IUserRoleBusiness, UserRoleBusiness>();
builder.Services.AddScoped<IUserRoleData, UserRoleData>();
builder.Services.AddScoped<IViewBusiness, ViewBusiness>();
builder.Services.AddScoped<IViewData, ViewData>();
builder.Services.AddScoped<ICityBusiness, CityBusiness>();
builder.Services.AddScoped<ICityData, CityData>();
builder.Services.AddScoped<ICountryBusiness, CountryBusiness>();
builder.Services.AddScoped<ICountryData, CountryData>();
builder.Services.AddScoped<IStateBusiness, StateBusiness>();
builder.Services.AddScoped<IStateData, StateData>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseExceptionHandler("/error");


app.Run();

