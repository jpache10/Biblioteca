using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;

    public class sDatabaseContext : DbContext
    {
        public sDatabaseContext (DbContextOptions<sDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Biblioteca.Models.Autore> Autore { get; set; } = default!;
    }
