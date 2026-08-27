using Microsoft.EntityFrameworkCore;
using OrdersList.Common;
using OrdersList.Data;
using OrdersList.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Config database.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite( builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<IOrderRepository, SQLiteOrderRepository>();

// Config business logic.
builder.Services.AddScoped<OrderService>();

// Config Exception Handler.
builder.Services.AddExceptionHandler<OrderExceptionHandler>();
builder.Services.AddProblemDetails();

// Allow requests from frontend
var frontendUrl = builder.Configuration["FrontendUrl"];
var allowFrontend = "_allowFrontend";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowFrontend,
        policy =>
        {
            policy.WithOrigins(frontendUrl ?? "")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// ----- BUILD ----- //

var app = builder.Build();

app.UseCors(allowFrontend);
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
