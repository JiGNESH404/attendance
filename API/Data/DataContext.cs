using API.Entity;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
       public DataContext(DbContextOptions options) : base(options)
        { }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppAdmin> Admin { get; set; }
        public DbSet<studentClass> studentClass{get; set;}
        public DbSet<Attendance> Attendances { get; set; }
    }
}
