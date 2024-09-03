using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppLibreria_CaruajulcaTiglla.Data;
using AppLibreria_CaruajulcaTiglla.Models;

namespace AppLibreria_CaruajulcaTiglla.Pages.Proveedores
{
    public class IndexModel : PageModel
    {
        private readonly AppLibreria_CaruajulcaTiglla.Data.AppLibreria_CaruajulcaTigllaContext _context;

        public IndexModel(AppLibreria_CaruajulcaTiglla.Data.AppLibreria_CaruajulcaTigllaContext context)
        {
            _context = context;
        }

        public IList<Proveedor> Proveedor { get;set; } = default!;

        public int TotalRegistros { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateOnly? FechaInicio { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateOnly? FechaFin { get; set; }

        public Valoracion? Valoracion { get; set; }

        public async Task OnGetAsync()
        {
            Proveedor = await _context.Proveedor.ToListAsync();

            var query = _context.Proveedor.AsQueryable();

            if (FechaInicio.HasValue && FechaFin.HasValue)
            {
                query = query.Where(p => p.FechaContrato >= FechaInicio.Value && p.FechaContrato <= FechaFin.Value);
            }

            

            if (Valoracion.HasValue)
            {
                query = query.Where(p => p.Valoracion == Valoracion.Value);
            }

            

            Proveedor = await query.ToListAsync();
            TotalRegistros = Proveedor.Count();
        }
    }
}
