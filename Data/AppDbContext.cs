﻿using LearnAspCoreBest.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnAspCoreBest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}