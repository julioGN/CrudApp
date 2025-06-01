using System;
using CRUDApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDApp1.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
    }

}

