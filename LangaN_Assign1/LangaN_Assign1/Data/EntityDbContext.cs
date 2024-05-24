﻿using LangaN_Assign1.Models;
using Microsoft.EntityFrameworkCore;

namespace LangaN_Assign1.Data
{
    public class EntityDbContext : DbContext
    {
        public EntityDbContext(DbContextOptions<EntityDbContext> options)
            : base(options)
        {
        }

        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
