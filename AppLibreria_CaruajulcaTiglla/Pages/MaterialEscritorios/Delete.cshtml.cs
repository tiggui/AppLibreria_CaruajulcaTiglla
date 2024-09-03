using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppLibreria_CaruajulcaTiglla.Data;
using AppLibreria_CaruajulcaTiglla.Models;

namespace AppLibreria_CaruajulcaTiglla.Pages.MaterialEscritorios
{
    public class DeleteModel : PageModel
    {
        private readonly AppLibreria_CaruajulcaTiglla.Data.AppLibreria_CaruajulcaTigllaContext _context;

        public DeleteModel(AppLibreria_CaruajulcaTiglla.Data.AppLibreria_CaruajulcaTigllaContext context)
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

            var materialescritorio = await _context.MaterialEscritorio.FirstOrDefaultAsync(m => m.Id == id);

            if (materialescritorio == null)
            {
                return NotFound();
            }
            else
            {
                MaterialEscritorio = materialescritorio;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialescritorio = await _context.MaterialEscritorio.FindAsync(id);
            if (materialescritorio != null)
            {
                MaterialEscritorio = materialescritorio;
                _context.MaterialEscritorio.Remove(MaterialEscritorio);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
