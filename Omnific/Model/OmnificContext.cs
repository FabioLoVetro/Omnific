using System.Collections.Generic;
using System;
using Omnific.Model;
using Microsoft.EntityFrameworkCore;

namespace Omnific.Model
{
    public class OmnificContext : DbContext
    {
        public OmnificContext(DbContextOptions<OmnificContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}