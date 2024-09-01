using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database
{
    public class CustomDatabaseContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<DefaultDataType> DefaultDataTable { get; set; }
    }
}