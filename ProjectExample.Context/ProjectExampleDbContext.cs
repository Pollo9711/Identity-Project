using Microsoft.EntityFrameworkCore;
using ProjectExample.Context.Entities;

namespace ProjectExample.Context
{
    public class ProjectExampleDbContext : DbContext
    {
        public ProjectExampleDbContext()
        {
            
        }

        public ProjectExampleDbContext(DbContextOptions<ProjectExampleDbContext> options) : base(options)
        {
            
        }


        public virtual DbSet<EmployeeEntity> Employee { get; set; }
        public virtual DbSet<HrEntity> HrUsers { get; set; }
        
        
    }
}