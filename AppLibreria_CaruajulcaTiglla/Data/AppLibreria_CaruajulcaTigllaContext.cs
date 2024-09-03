using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppLibreria_CaruajulcaTiglla.Models;

namespace AppLibreria_CaruajulcaTiglla.Data
{
    public class AppLibreria_CaruajulcaTigllaContext : DbContext
    {
        public AppLibreria_CaruajulcaTigllaContext (DbContextOptions<AppLibreria_CaruajulcaTigllaContext> options)
            : base(options)
        {
        }

        public DbSet<AppLibreria_CaruajulcaTiglla.Models.Proveedor> Proveedor { get; set; } = default!;
        public DbSet<AppLibreria_CaruajulcaTiglla.Models.MaterialEscritorio> MaterialEscritorio { get; set; }
    }
}
