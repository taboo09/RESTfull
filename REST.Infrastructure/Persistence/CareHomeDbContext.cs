using REST.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace REST.Infrastructure.Persistence
{
    public class CareHomeDbContext : DbContext
    {
        public CareHomeDbContext(DbContextOptions<CareHomeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CareHome> Homes { get; set; }
        public virtual DbSet<Qualification> Qualifications { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
    }
}