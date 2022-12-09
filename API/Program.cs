using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICustomerService, CustomerManager>();
builder.Services.AddSingleton<ICustomerDal, EfCustomerDal>();

builder.Services.AddSingleton<IAccountService, AccountManager>();
builder.Services.AddSingleton<IAccountDal, EfAccountDal>();

builder.Services.AddSingleton<IAddressService, AddressManager>();
builder.Services.AddSingleton<IAddressDal, EfAddressDal>();

builder.Services.AddSingleton<ILoginInfoService, LoginInfoManager>();
builder.Services.AddSingleton<ILoginInfoDal, EfLoginInfoDal>();


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
