﻿using Microsoft.EntityFrameworkCore;
using OSA.DomainEntities.Users;

namespace OSA.Database.DBContext
{
    public class OSADbContext : DbContext
    {
        public OSADbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
    }
}