using Businees.Services;
using DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProductDao, ProductDao>();
builder.Services.AddScoped<ProductService, ProductService>();

builder.Services.AddDbContext<SalesDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("dbSales")
                     ?? throw new Exception("missing connectionstring")));
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

using (var scope = app.Services.CreateScope())
{
    SalesDbContext context = scope.ServiceProvider.GetRequiredService<SalesDbContext>();
    context.Database.Migrate();
}

app.Run();
