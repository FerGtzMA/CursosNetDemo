using AplicacionNetRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace AplicacionNetRazor.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
                        
        }

        // Modelos
        public DbSet<Curso> Curso { get; set; }
    }
}
