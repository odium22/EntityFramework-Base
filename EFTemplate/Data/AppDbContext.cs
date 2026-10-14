using EFTemplate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFTemplate.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Group> Groups => Set<Group>();
        public DbSet<StudentCard> StudentCards => Set<StudentCard>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite("Data Source=ef_university.db")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
        }
    }
}
