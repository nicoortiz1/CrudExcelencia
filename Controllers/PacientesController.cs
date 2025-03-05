using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using CrudExcelencia.Models;

namespace CrudExcelencia.Controllers
{
    public class PacientesController : Controller
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // LISTAR PACIENTES
        public ActionResult Inicio()
        {
            var pacientes = new List<Paciente>();
            string sql = "SELECT Id, Nombre, Apellido, DNI, FechaNacimiento, Telefono, Email, Direccion FROM Paciente";

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pacientes.Add(new Paciente
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            DNI = reader["DNI"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                            Telefono = reader["Telefono"].ToString(),
                            Email = reader["Email"]?.ToString(),
                            Direccion = reader["Direccion"]?.ToString()
                        });
                    }
                }
            }
            return View(pacientes);
        }

        // DETALLES DE UN PACIENTE
        public ActionResult Details(int id)
        {
            Paciente paciente = ObtenerPacientePorId(id);
            if (paciente == null) return HttpNotFound();
            return View(paciente);
        }

        // CREAR - GET
        public ActionResult Create()
        {
            return View();
        }

        // CREAR - POST
        [HttpPost]
        public ActionResult Create(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                string sql = "INSERT INTO Paciente (Nombre, Apellido, DNI, FechaNacimiento, Telefono, Email, Direccion) VALUES (@Nombre, @Apellido, @DNI, @FechaNacimiento, @Telefono, @Email, @Direccion)";
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                    command.Parameters.AddWithValue("@Apellido", paciente.Apellido);
                    command.Parameters.AddWithValue("@DNI", paciente.DNI);
                    command.Parameters.AddWithValue("@FechaNacimiento", paciente.FechaNacimiento);
                    command.Parameters.AddWithValue("@Telefono", paciente.Telefono);
                    command.Parameters.AddWithValue("@Email", paciente.Email);
                    command.Parameters.AddWithValue("@Direccion", paciente.Direccion);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        // EDITAR - GET
        public ActionResult Edit(int id)
        {
            Paciente paciente = ObtenerPacientePorId(id);
            if (paciente == null) return HttpNotFound();
            return View(paciente);
        }

        // EDITAR - POST
        [HttpPost]
        public ActionResult Edit(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                string sql = "UPDATE Paciente SET Nombre=@Nombre, Apellido=@Apellido, DNI=@DNI, FechaNacimiento=@FechaNacimiento, Telefono=@Telefono, Email=@Email, Direccion=@Direccion WHERE Id=@Id";
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", paciente.Id);
                    command.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                    command.Parameters.AddWithValue("@Apellido", paciente.Apellido);
                    command.Parameters.AddWithValue("@DNI", paciente.DNI);
                    command.Parameters.AddWithValue("@FechaNacimiento", paciente.FechaNacimiento);
                    command.Parameters.AddWithValue("@Telefono", paciente.Telefono);
                    command.Parameters.AddWithValue("@Email", paciente.Email);
                    command.Parameters.AddWithValue("@Direccion", paciente.Direccion);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        // ELIMINAR - GET
        public ActionResult Delete(int id)
        {
            Paciente paciente = ObtenerPacientePorId(id);
            if (paciente == null) return HttpNotFound();
            return View(paciente);
        }

        // ELIMINAR - POST
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            string sql = "DELETE FROM Pacientes WHERE Id = @Id";
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    TempData["MensajeExito"] = "Paciente eliminado correctamente.";
                }
                else
                {
                    TempData["MensajeError"] = "Paciente no encontrado.";
                }
            }
            return RedirectToAction("Index");
        }

        // MÉTODO AUXILIAR PARA OBTENER UN PACIENTE POR ID
        private Paciente ObtenerPacientePorId(int id)
        {
            Paciente paciente = null;
            string sql = "SELECT Id, Nombre, Apellido, DNI, FechaNacimiento, Telefono, Email, Direccion FROM Paciente WHERE Id=@Id";

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        paciente = new Paciente
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            DNI = reader["DNI"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                            Telefono = reader["Telefono"].ToString(),
                            Email = reader["Email"]?.ToString(),
                            Direccion = reader["Direccion"]?.ToString()
                        };
                    }
                }
            }
            return paciente;
        }
    }
}
