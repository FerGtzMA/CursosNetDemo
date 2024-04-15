using AplicacionNetRazor.Datos;
using AplicacionNetRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicacionNetRazor.Pages.Cursos
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Curso Curso { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet(int id)
        {
            Curso = await _context.Curso.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var cursoDesdeBD = await _context.Curso.FindAsync(Curso.Id);

                cursoDesdeBD.NombreCurso = Curso.NombreCurso;
                cursoDesdeBD.CantidadClase = Curso.CantidadClase;
                cursoDesdeBD.Precio = Curso.Precio;

                await _context.SaveChangesAsync();
                Mensaje = "Curso editado correctamente";
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
