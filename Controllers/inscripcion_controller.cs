using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroEstudiantes.Config;
using RegistroEstudiantes.Models;
using RegistroEstudiantes.Views;

namespace RegistroEstudiantes.Controllers
{
    class inscripcion_controller
    {
        //curso_model IdCurso Nombre Creditos Profesor
        //estudiante_model IdEstudiante Nombre Apellido Edad Direccion
        //inscripion_model IdInscripcion IdCurso IdEstudiante Fecha
        private readonly connection cn = new connection();

        public string Insertar(inscripcion_model inscripcion)
        {
            using (var connection = cn.GetConnection())
            {
                string query = "INSERT INTO inscripcion (IdCurso, IdEstudiante) VALUES (@IdCurso, @IdEstudiante)";
                using (var comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.AddWithValue("@IdCurso", inscripcion.IdCurso);
                    comando.Parameters.AddWithValue("@IdEstudiante", inscripcion.IdEstudiante);
                    return EjecutarComando(comando, connection);
                }
            }
        }

        public List<inscripcion_model> ObtenerTodos()
        {
            var listaInscripciones = new List<inscripcion_model>();
            using (var conexion = cn.GetConnection())
            {
                string query = "SELECT * FROM vistaInscripciones";

                using (var comando = new SqlCommand(query, conexion))
                {
                    conexion.Open();
                    using (var lector = comando.ExecuteReader()) /**********/
                    {
                        while (lector.Read())
                        {
                            var inscripcion = new inscripcion_model
                            {
                                IdInscripcion = (int)lector["IdInscripcion"],
                                IdCurso = (int)lector["IdCurso"],
                                IdEstudiante = (int)lector["IdEstudiante"],
                                NombreEstudiante = lector["NombreEstudiante"].ToString(),
                                ApellidoEstudiante = lector["ApellidoEstudiante"].ToString(),
                                NombreCurso = lector["NombreCurso"].ToString(),
                                Fecha = (DateTime)lector["Fecha"]
                            };
                            listaInscripciones.Add(inscripcion);
                        }
                    }
                }
            }
            return listaInscripciones;
        }

        public inscripcion_model obtenerPorId(int id)
        {
            using (var connection = cn.GetConnection())
            {
                string query = "SELECT * FROM vistaInscripciones WHERE IdInscripcion = @IdInscripcion";
                using (var comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.AddWithValue("@IdInscripcion", id);
                    connection.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            return new inscripcion_model
                            { 
                                IdInscripcion = (int)lector["IdInscripcion"],
                                IdEstudiante = (int)lector["IdEstudiante"],
                                IdCurso = (int)lector["IdCurso"],
                                NombreEstudiante = lector["NombreEstudiante"].ToString(),
                                NombreCurso = lector["NombreCurso"].ToString(),
                                Fecha = (DateTime)lector["Fecha"]
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public string Actualizar(inscripcion_model inscripcion)
        {
            using (var connection = cn.GetConnection())
            {
                string query = "UPDATE Inscripcion SET IdCurso = @IdCurso, IdEstudiante = @IdEstudiante"  +
                                " WHERE IdInscripcion = @IdInscripcion"; 
                using (var comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.AddWithValue("@IdCurso", inscripcion.IdCurso);
                    comando.Parameters.AddWithValue("@IdEstudiante", inscripcion.IdEstudiante);
                    comando.Parameters.AddWithValue("@Fecha", inscripcion.Fecha);
                    return EjecutarComando(comando, connection);
                }
            }
        }

        public bool Eliminar(int id)
        {
            using (var conexion = cn.GetConnection())
            {
                string query = "DELETE FROM Inscripcion WHERE IdInscripcion = @IdInscripcion";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdInscripcion", id);
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

        public List<inscripcion_model> Buscar(string texto)
        {
            var listaInscripciones = new List<inscripcion_model>();
            using (var conexion = cn.GetConnection())
            {
                string query = "SELECT * FROM vistaInscripciones WHERE NombreEstudiante LIKE LOWER(@Texto)";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Texto", "%" + texto + "%");
                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            listaInscripciones.Add(new inscripcion_model
                            {
                                IdInscripcion = (int)lector["IdInscripcion"],
                                IdEstudiante = (int)lector["IdEstudiante"],
                                IdCurso = (int)lector["IdCurso"],
                                NombreEstudiante = lector["NombreEstudiante"].ToString(),
                                ApellidoEstudiante = lector["ApellidoEstudiante"].ToString(),
                                NombreCurso = lector["NombreCurso"].ToString(),
                                Fecha = (DateTime)lector["Fecha"]
                            });
                        }
                    }
                }
            }
            return listaInscripciones;
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
        public bool verificarInscripcion(int idEstudiante, int idCurso)
        {
            using (var conexion = cn.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Inscripcion WHERE IdEstudiante = @IdEstudiante AND IdCurso = @IdCurso";

                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                    comando.Parameters.AddWithValue("@IdCurso", idCurso);

                    try
                    {
                        conexion.Open();
                        int count = (int)comando.ExecuteScalar();
                        return count > 0;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        /*
            SELECT 
                i.IdInscripcion,
                i.IdEstudiante,  
                c.IdCurso,     
                e.Nombre AS Nombres,
	            e.Apellido AS Apellidos,
                c.Nombre AS Curso,
                i.Fecha AS "Fecha Inscripcion"
            FROM 
                Inscripcion i
            INNER JOIN 
                Estudiante e ON i.IdEstudiante = e.IdEstudiante
            INNER JOIN 
                Curso c ON i.IdCurso = c.IdCurso;
            GO                
         */

    }
}
