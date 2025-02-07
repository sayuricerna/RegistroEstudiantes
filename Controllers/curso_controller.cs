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
    class curso_controller
    {

        //curso_model IdCurso NombreCurso Creditos Profesor
        private readonly connection cn = new connection();

        public string Insertar(curso_model curso)
        {
            using (var connection = cn.GetConnection())
            {
                string query = "INSERT INTO curso (NombreCurso, Creditos, Profesor) VALUES (@NombreCurso, @Creditos, @Profesor)";
                using (var comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.AddWithValue("@NombreCurso", curso.NombreCurso);
                    comando.Parameters.AddWithValue("@Creditos", curso.Creditos);
                    comando.Parameters.AddWithValue("@Profesor", curso.Profesor);
                    return EjecutarComando(comando, connection);

                }
            }
        }
        public List<curso_model> obtenerTodos()
        {
            var listaCursos = new List<curso_model>();
            using (var connection = cn.GetConnection())
            {
                string query = "SELECT * FROM curso";
                using (var comando = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using(var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            listaCursos.Add(new curso_model
                            {
                                IdCurso = (int)lector["IdCurso"],
                                NombreCurso = lector["NombreCurso"].ToString(),
                                Creditos = (int)lector["Creditos"],
                                Profesor = lector["Profesor"].ToString(),
                            });
                        }
                    }
                }
            }
            return listaCursos;
        }

        public curso_model obtenerPorId(int id)
        {
            using (var connection = cn.GetConnection())
            {
                string query = "SELECT * FROM Curso WHERE IdCurso = @IdCurso";
                using (var comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.AddWithValue("@IdCurso", id);
                    connection.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            return new curso_model
                            {
                                IdCurso = (int)lector["IdCurso"],
                                NombreCurso = lector["NombreCurso"].ToString(),
                                Creditos = (int)lector["Creditos"],
                                Profesor = lector["Profesor"].ToString(),
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public string Actualizar(curso_model curso)
        {
            using (var connection = cn.GetConnection())
            {
                string query = "UPDATE Curso SET NombreCurso = @NombreCurso, Creditos = @Creditos, Profesor = @Profesor  WHERE IdCurso = @IdCurso";
                using (var comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.AddWithValue("@IdCurso", curso.IdCurso);
                    comando.Parameters.AddWithValue("@NombreCurso", curso.NombreCurso);
                    comando.Parameters.AddWithValue("@Creditos", curso.Creditos);
                    comando.Parameters.AddWithValue("@Profesor", curso.Profesor);
                    return EjecutarComando(comando, connection);
                }
            }
        }

        public bool Eliminar(int id)
        {
            using (var conexion = cn.GetConnection())
            {
                string query = "DELETE FROM Curso WHERE IdCurso = @IdCurso";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdCurso", id);
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

        public List<curso_model> Buscar(string texto)
        {
            var listaCursos = new List<curso_model>();
            using (var conexion = cn.GetConnection())
            {
                string query = "SELECT * FROM curso WHERE NombreCurso LIKE @Texto";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Texto", "%" + texto + "%");
                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            listaCursos.Add(new curso_model
                            {
                                IdCurso = (int)lector["IdCurso"],
                                NombreCurso = lector["NombreCurso"].ToString(),
                                Creditos = (int)lector["Creditos"],
                                Profesor = lector["Profesor"].ToString(),
                            });
                        }
                    }
                }
            }
            return listaCursos;
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
