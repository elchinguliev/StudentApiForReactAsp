using Microsoft.EntityFrameworkCore;

namespace ApiForReactAsp.Models
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }

        public DbSet<Student> Students { get; set; }

    }
}
