using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegistroEstudiantes.Controllers;
using RegistroEstudiantes.Models;

namespace RegistroEstudiantes.Views.Cursos
{
    public partial class frmCurso : Form
    {
        public bool modoEdicion = false;
        public int id = 0;
        public frmCurso(String modo)
        {
            InitializeComponent();
            if (modo != "n")
            {
                this.modoEdicion = true;
                this.id = int.Parse(modo);
            }
        }
        //curso_model IdCurso Nombre Creditos Profesor

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtProfesor.Text == "" || txtCreditos.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.");
                return;
            }

            try
            {
                var curso = new curso_model()
                {
                    NombreCurso = txtNombre.Text,
                    Creditos = int.Parse(txtCreditos.Text), // Convertir Creditos a int
                    Profesor = txtProfesor.Text,
                };

                var controller = new curso_controller();

                if (!this.modoEdicion)
                {
                    var resultado = controller.Insertar(curso);
                    if (resultado == "ok")
                    {
                        MessageBox.Show("Curso guardado con éxito");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Error al guardar: {resultado}");
                    }
                }
                else
                {
                    curso.IdCurso = this.id;
                    var resultado = controller.Actualizar(curso);
                    if (resultado == "ok")
                    {
                        MessageBox.Show("Curso actualizado con éxito");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Error al actualizar: {resultado}");
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("El campo Créditos debe ser un número entero válido.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }

        private void frmCurso_Load(object sender, EventArgs e)
        {
            if (!this.modoEdicion)
            {
                lblTitulo.Text = "Ingreso de Nuevo Curso";
            }
            else
            {
                lblTitulo.Text = "Actualización de Curso";
                var cursoController = new curso_controller();
                var curso = cursoController.obtenerPorId(this.id);

                if (curso != null)
                {
                    txtNombre.Text = curso.NombreCurso;
                    txtCreditos.Text = curso.Creditos.ToString();
                    txtProfesor.Text = curso.Profesor;
                }
                else
                {
                    MessageBox.Show("No se encontró el curso seleccionado.");
                    this.Close();
                }
            }
        }

        private void txtCreditos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
