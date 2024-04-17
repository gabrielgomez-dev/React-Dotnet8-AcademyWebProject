using AcademyWebProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademyWebProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
    }
}