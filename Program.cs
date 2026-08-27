using Microsoft.EntityFrameworkCore;
using OrdersList.Common;
using OrdersList.Data;
using OrdersList.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite( builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<IOrderRepository, SQLiteOrderRepository>();

builder.Services.AddScoped<OrderService>();

builder.Services.AddExceptionHandler<OrderExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseExceptionHandler();
app.MapControllers();

app.Run();
