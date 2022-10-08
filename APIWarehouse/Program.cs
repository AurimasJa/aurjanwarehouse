using APIWarehouse.Data;
using APIWarehouse.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<WarehouseDbContext>();

builder.Services.AddTransient<IWarehousesRepository, WarehousesRepository>();



var app = builder.Build();

app.UseRouting();
app.MapControllers();
app.Run();
