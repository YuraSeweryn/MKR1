using MKR1.Models;
using System.Data.Entity;

namespace Test.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection") { }

        public DbSet<Student> Students { get; set; }
    }
}