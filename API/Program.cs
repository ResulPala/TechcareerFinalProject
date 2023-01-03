using Business.Abstract;
using Business.Concrete;
using Business.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICustomerService, CustomerManager>();
builder.Services.AddSingleton<ICustomerDal, EfCustomerDal>();

builder.Services.AddSingleton<ICustomerAccountService, CustomerAccountManager>();
builder.Services.AddSingleton<ICustomerAccountDal, EfCustomerAccountDal>();

builder.Services.AddSingleton<ICustomerContactInformationService, CustomerContactInformationManager>();
builder.Services.AddSingleton<ICustomerContactInformationDal, EfCustomerContactInformationDal>();

builder.Services.AddSingleton<ICustomerRegistryInformationService, CustomerRegistryInformationManager>();
builder.Services.AddSingleton<ICustomerRegistryInformationDal, EfCustomerRegistryInformationDal>();

builder.Services.AddSingleton<IAuthService, AuthManager>();
builder.Services.AddSingleton<ITokenHelper, JwtHelper>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
