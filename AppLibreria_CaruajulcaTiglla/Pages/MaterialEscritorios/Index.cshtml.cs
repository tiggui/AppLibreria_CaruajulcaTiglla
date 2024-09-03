using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppLibreria_CaruajulcaTiglla.Data;
using AppLibreria_CaruajulcaTiglla.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppLibreria_CaruajulcaTiglla.Pages.MaterialEscritorios
{
    public class IndexModel : PageModel
    {
        private readonly AppLibreria_CaruajulcaTiglla.Data.AppLibreria_CaruajulcaTigllaContext _context;

        public IndexModel(AppLibreria_CaruajulcaTiglla.Data.AppLibreria_CaruajulcaTigllaContext context)
        {
            _context = context;
        }

        public int TotalRegistros { get; set; }
        public decimal MontoTotalExistencias { get; set; }
        public IList<MaterialEscritorio> MaterialEscritorio { get;set; } = default!;

        public async Task OnGetAsync()
        {
            MaterialEscritorio = await _context.MaterialEscritorio
                .Include(m => m.Proveedor).ToListAsync();

            TotalRegistros = await _context.MaterialEscritorio.CountAsync();


            ViewData["ProveedorId"] = new SelectList(_context.Proveedor, "Id", "RazonSocial");

           
            MontoTotalExistencias = await _context.MaterialEscritorio
                .SumAsync(m => m.Precio * m.Stock);

            ViewData["ProveedorId"] = new SelectList(_context.Proveedor, "Id", "RazonSocial");

        }



        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MaterialEscritorio.Add((MaterialEscritorio)MaterialEscritorio);
            await _context.SaveChangesAsync();

            
            TotalRegistros = await _context.MaterialEscritorio.CountAsync();

            TotalRegistros = await _context.MaterialEscritorio.CountAsync();
            MontoTotalExistencias = await _context.MaterialEscritorio
                .SumAsync(m => m.Precio * m.Stock);

            return RedirectToPage("./Index");
        }
    }
}
