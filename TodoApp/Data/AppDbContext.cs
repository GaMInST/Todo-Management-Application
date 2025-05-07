using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Todo> Todos { get; set; }
    }
}