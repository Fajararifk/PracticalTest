﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.BusinessObjects
{
    public partial class PracticalTest_DBContext : IdentityDbContext<User>
    {
        public PracticalTest_DBContext(DbContextOptions<PracticalTest_DBContext> options)
            : base(options) 
        {
        }
        public virtual DbSet<Organizers> Organizers { get; set; }
        public virtual DbSet<SportEvents> SportsEvents { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}