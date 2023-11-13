using System;
using libreria_JSVE.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace libreria_JSVE.Data
{
    public class AppDebContext : DbContext
    {
        public AppDebContext(DbContextOptions<AppDebContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
