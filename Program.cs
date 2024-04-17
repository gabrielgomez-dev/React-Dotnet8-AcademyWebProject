using AcademyWebProject.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers();

// CORS policy
builder.Services.AddCors(options =>
    options.AddPolicy("AllowClientPolicy", policy =>
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Initialize the database and seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();
    var logger = services.GetRequiredService<ILogger<Program>>();

    try
    {
        // Verify if the database exists
        if (!context.Database.CanConnect())
        {
            // If not exists, create it
            context.Database.EnsureCreated();

            // Ejecute seed 
            await DataContextSeeder.SeedDataAsync(context, logger);
        }
        else
        {
            // If database exists, check if there are any courses.
            // If not, seed the database
            if (!context.Courses.Any())
            {
                await DataContextSeeder.SeedDataAsync(context, logger);
            }
        }
    }
    catch (Exception ex) // If an error occurs, log it
    {
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

app.UseRouting();

app.UseCors("AllowClientPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();