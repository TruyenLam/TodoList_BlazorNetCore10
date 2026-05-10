using Microsoft.EntityFrameworkCore;
using TodoListBlazor.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// EF Core
builder.Services.AddDbContext<TodoListDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Register seed service before Build() so it is available in the DI container.
builder.Services.AddScoped<TodoListDBContextSeed>();

var app = builder.Build();

// Seed database
// Apply pending migrations and seed initial data at application startup.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<TodoListDBContextSeed>>();

    try
    {
        var context = services.GetRequiredService<TodoListDBContext>();

        await context.Database.MigrateAsync();

        var seeder = services.GetRequiredService<TodoListDBContextSeed>();
        await seeder.SeedAsync(context, logger);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // Tạo giao diện Swagger UI: /swagger
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "TodoListBlazor API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
