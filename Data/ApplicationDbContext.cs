using CrudExcelencia.Models;
using MySql.Data.EntityFramework;
using System.Data.Entity;

namespace CrudExcelencia.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))] // Configuración para MySQL
    public class ApplicationDbContext : DbContext
    {
        // Constructor recomendado para ASP.NET Core
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }

    }
}
