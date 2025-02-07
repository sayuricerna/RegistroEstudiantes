using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroEstudiantes.Config;
using RegistroEstudiantes.Models;

namespace RegistroEstudiantes.Controllers
{
    class estudiante_controller
    {
        //estudiante_model IdEstudiante Nombre Apellido Edad Direccion

        private readonly connection cn = new connection();

        public string Insertar(estudiante_model estudiante)
        {
            using (var connection = cn.GetConnection())
            {
                string query = "INSERT INTO estudiante (NombreEstudiante, ApellidoEstudiante, Edad, Direccion) VALUES (@NombreEstudiante, @ApellidoEstudiante, @Edad, @Direccion)";
                using (var comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.AddWithValue("@NombreEstudiante", estudiante.NombreEstudiante);
                    comando.Parameters.AddWithValue("@ApellidoEstudiante", estudiante.ApellidoEstudiante);
                    comando.Parameters.AddWithValue("@Edad", estudiante.Edad);
                    comando.Parameters.AddWithValue("@Direccion", estudiante.Direccion);
                    return EjecutarComando(comando, connection);
                }
            }
        }

        public List<estudiante_model> obtenerTodos()
        {
            var listaEstudiantes = new List<estudiante_model>();
            using (var connection = cn.GetConnection())
            {
                string query = "SELECT * FROM estudiante";
                using (var comando = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            listaEstudiantes.Add(new estudiante_model
                            {
                                IdEstudiante = (int)lector["IdEstudiante"],
                                NombreEstudiante = lector["NombreEstudiante"].ToString(),
                                ApellidoEstudiante = lector["ApellidoEstudiante"].ToString(),
                                Edad = (int)lector["Edad"],
                                Direccion = lector["Direccion"].ToString(),
                            });
                        }
                    }
                }
            }
            return listaEstudiantes;
        }

        public estudiante_model obtenerPorId(int id)
        {
            using (var connection = cn.GetConnection())
            {
                string query = "SELECT * FROM Estudiante WHERE IdEstudiante = @IdEstudiante";
                using (var comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.AddWithValue("@IdEstudiante", id);
                    connection.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            return new estudiante_model
                            {
                                IdEstudiante = (int)lector["IdEstudiante"],
                                NombreEstudiante = lector["NombreEstudiante"].ToString(),
                                ApellidoEstudiante = lector["ApellidoEstudiante"].ToString(),
                                Edad = (int)lector["Edad"],
                                Direccion = lector["Direccion"].ToString(),
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public string Actualizar(estudiante_model estudiante)
        {
            using (var connection = cn.GetConnection())
            {
                string query = "UPDATE Estudiante SET NombreEstudiante = @NombreEstudiante, ApellidoEstudiante = @ApellidoEstudiante, Edad = @Edad, Direccion = @Direccion WHERE IdEstudiante = @IdEstudiante";
                using (var comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.AddWithValue("@IdEstudiante", estudiante.IdEstudiante);
                    comando.Parameters.AddWithValue("@NombreEstudiante", estudiante.NombreEstudiante);
                    comando.Parameters.AddWithValue("@ApellidoEstudiante", estudiante.ApellidoEstudiante);
                    comando.Parameters.AddWithValue("@Edad", estudiante.Edad);
                    comando.Parameters.AddWithValue("@Direccion", estudiante.Direccion);
                    return EjecutarComando(comando, connection);
                }
            }
        }

        public bool Eliminar(int id)
        {
            using (var conexion = cn.GetConnection())
            {
                string query = "DELETE FROM Estudiante WHERE IdEstudiante = @IdEstudiante";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdEstudiante", id);
                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        public List<estudiante_model> Buscar(string texto)
        {
            var listaEstudiantes = new List<estudiante_model>();
            using (var conexion = cn.GetConnection())
            {
                string query = "SELECT * FROM estudiante WHERE NombreEstudiante LIKE @Texto";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Texto", "%" + texto + "%");
                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            listaEstudiantes.Add(new estudiante_model
                            {
                                IdEstudiante = (int)lector["IdEstudiante"],
                                NombreEstudiante = lector["NombreEstudiante"].ToString(),
                                ApellidoEstudiante = lector["ApellidoEstudiante"].ToString(),
                                Edad = (int)lector["Edad"],
                                Direccion = lector["Direccion"].ToString(),
                            });
                        }
                    }
                }
            }
            return listaEstudiantes;
        }
        private string EjecutarComando(SqlCommand comando, SqlConnection conexion)
        {
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
