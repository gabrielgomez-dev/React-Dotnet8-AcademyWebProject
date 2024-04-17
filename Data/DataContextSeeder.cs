using System.Text.Json;
using AcademyWebProject.Models;

namespace AcademyWebProject.Data
{
    public class DataContextSeeder
    {
        public static async Task SeedDataAsync(DataContext context, ILogger logger)
        {
            try
            {
                if (!context.Courses.Any())
                {
                    var coursesData = File.ReadAllText("courses.json");
                    var courses = JsonSerializer.Deserialize<List<Course>>(coursesData);

                    foreach (var course in courses)
                    {
                        context.Courses.Add(course);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while seeding the database.");
            }
        }
    }
}