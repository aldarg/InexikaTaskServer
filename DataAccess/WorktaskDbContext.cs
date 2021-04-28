using Microsoft.EntityFrameworkCore;
using InexikaTaskServer.Models;
using System;

namespace InexikaTaskServer.DataAccess
{
    public class WorktaskDbContext: DbContext
    {
        public WorktaskDbContext(DbContextOptions options): base(options)
        {
        }
        public DbSet<Worktask> Worktasks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> WorktaskStatuses { get; set; }
        public DbSet<StatusAccess> WorktaskAccesses { get; set; }
        public DbSet<StatusRoute> StatusRoutes { get; set; }
        public DbSet<AccessType> AccessTypes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<StatusRouteAccess> StatusRouteAccesses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worktask>().HasOne(w => w.Author).WithMany(a => a.AuthoredWorktasks).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Worktask>().HasOne(w => w.Editor).WithMany(a => a.EditedWorktasks).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StatusRoute>().HasOne(r => r.FromStatus).WithMany(s => s.FromStatusRoutes);
            modelBuilder.Entity<StatusRoute>().HasOne(r => r.ToStatus).WithMany(s => s.ToStatusRoutes);
        }
    }
}
