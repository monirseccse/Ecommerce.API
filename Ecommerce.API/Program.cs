using Domain.Repositories;
using Ecommerce.API.Helper;
using Infrastructure.DbContexts;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;

try
{
    var builder = WebApplication.CreateBuilder(args);

    var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
    var assemblyName = typeof(ApplicationDbContext).Assembly.FullName;
    // Add services to the container.

    builder.Services.AddControllers();

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(connectionstring, m => m.MigrationsAssembly(assemblyName));
    });

    builder.Services.AddScoped<IProductRepository, ProductRepository>();
    builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
    builder.Services.AddAutoMapper(typeof(MappingProfile));
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

    app.UseStatusCodePagesWithReExecute("/error/{0}");

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseAuthorization();

    app.MapControllers();

    SeedDefaultDataAsync(app).GetAwaiter().GetResult();

    app.Run();

}
catch (Exception ex)
{

	throw;
}

async Task SeedDefaultDataAsync(IHost app)
{
    using (var scope = app.Services.CreateAsyncScope())
    {
        var loggerfactory = scope.ServiceProvider.GetService<ILoggerFactory>();

        try
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await context.Database.MigrateAsync();
            await ApplicationDbContextSeedData.SeedAsync(context, loggerfactory);
        }
        catch (Exception ex)
        {

            var logger = loggerfactory.CreateLogger<Program>();
            logger.LogError(ex.Message);
        }
    }
}