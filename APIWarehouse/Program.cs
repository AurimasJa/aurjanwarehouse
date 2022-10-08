using APIWarehouse.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<WarehouseDbContext>();



var app = builder.Build();

app.UseRouting();
app.MapControllers();
app.Run();
