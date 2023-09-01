using Microsoft.EntityFrameworkCore;
using SportsComplex.Repository;
using SportsComplex.Services;
using SportsComplex.Services.Exceptions;
using SportsComplex.Services.Validators.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRepositories(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddServices();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpLogging();

app.Use(async (context, next) =>
{
    var logger = LoggerFactory.Create(config =>
    {
        config.AddConsole();
    }).CreateLogger("Exception handler");

    try
    {
        await next(context);
    }
    catch (ValidationException ex)
    {
        logger.LogError(ex, ex.Message);
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync(ex.Message);
    }
    catch (EntityNotFoundException ex)
    {
        logger.LogError(ex, ex.Message);
        context.Response.StatusCode = 404;
    }
    catch (Exception ex)
    {
        logger.LogError(ex, ex.Message);
        context.Response.StatusCode = 500;
    }
});

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SportsComplexDbContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
