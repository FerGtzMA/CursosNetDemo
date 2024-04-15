using AplicacionNetRazor.Datos;
using AplicacionNetRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AplicacionNetRazor.Pages.Cursos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Curso> Cursos { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet()
        {
            Cursos = await _context.Curso.ToListAsync();
        }

        public async Task<IActionResult> OnPostBorrar(int id)
        {
            var curso = await _context.Curso.FindAsync(id);
                if (curso == null)
                {
                    return NotFound();
                }

                _context.Curso.Remove(curso);
                await _context.SaveChangesAsync();
            Mensaje = "Curso eliminado correctamente";
                return RedirectToPage("Index");
        }
    }
}
