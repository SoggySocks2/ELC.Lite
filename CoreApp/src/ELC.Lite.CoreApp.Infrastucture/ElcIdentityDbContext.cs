﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ELC.Lite.CoreApp.Infrastucture
{
    public class ElcIdentityDbContext : IdentityDbContext
    {

        public ElcIdentityDbContext(DbContextOptions<ElcIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
