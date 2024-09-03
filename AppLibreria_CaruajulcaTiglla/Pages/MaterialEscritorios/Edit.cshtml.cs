using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppLibreria_CaruajulcaTiglla.Data;
using AppLibreria_CaruajulcaTiglla.Models;

namespace AppLibreria_CaruajulcaTiglla.Pages.MaterialEscritorios
{
    public class EditModel : PageModel
    {
        private readonly AppLibreria_CaruajulcaTiglla.Data.AppLibreria_CaruajulcaTigllaContext _context;

        public EditModel(AppLibreria_CaruajulcaTiglla.Data.AppLibreria_CaruajulcaTigllaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MaterialEscritorio MaterialEscritorio { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialescritorio =  await _context.MaterialEscritorio.FirstOrDefaultAsync(m => m.Id == id);
            if (materialescritorio == null)
            {
                return NotFound();
            }
            MaterialEscritorio = materialescritorio;
           ViewData["ProveedorId"] = new SelectList(_context.Proveedor, "Id", "RazonSocial");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MaterialEscritorio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialEscritorioExists(MaterialEscritorio.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MaterialEscritorioExists(int id)
        {
            return _context.MaterialEscritorio.Any(e => e.Id == id);
        }
    }
}
