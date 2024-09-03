using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppLibreria_CaruajulcaTiglla.Data;
using AppLibreria_CaruajulcaTiglla.Models;

namespace AppLibreria_CaruajulcaTiglla.Pages.MaterialEscritorios
{
    public class CreateModel : PageModel
    {
        private readonly AppLibreria_CaruajulcaTiglla.Data.AppLibreria_CaruajulcaTigllaContext _context;

        public CreateModel(AppLibreria_CaruajulcaTiglla.Data.AppLibreria_CaruajulcaTigllaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProveedorId"] = new SelectList(_context.Proveedor, "Id", "RazonSocial");
            return Page();
        }

        [BindProperty]
        public MaterialEscritorio MaterialEscritorio { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MaterialEscritorio.Add(MaterialEscritorio);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
