using APIWarehouse.Data;
using APIWarehouse.Data.Repositories;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<WarehouseDbContext>();

builder.Services.AddTransient<IWarehousesRepository, WarehousesRepository>();
builder.Services.AddTransient<IZonesRepository, ZonesRepository>();
builder.Services.AddTransient<IItemsRepository, ItemsRepository>();

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new WarehouseProfiles());
});

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);


var app = builder.Build();

app.UseRouting();
app.MapControllers();
app.Run();
