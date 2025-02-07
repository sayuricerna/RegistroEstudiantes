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

namespace RegistroEstudiantes.Views.Estudiantes
{
    public partial class frmEstudiante : Form
    {
        public bool modoEdicion = false;
        public int id = 0;
        public frmEstudiante(String modo)
        {
            InitializeComponent();
            if (modo != "n")
            {
                this.modoEdicion = true;
                this.id = int.Parse(modo);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtApellido.Text == "" || txtEdad.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.");
                return;
            }

            try
            {
                var estudiante = new estudiante_model()
                {
                    NombreEstudiante = txtNombre.Text,
                    ApellidoEstudiante = txtApellido.Text,
                    Edad = int.Parse(txtEdad.Text),
                    Direccion = txtDireccion.Text,
                };

                var controller = new estudiante_controller();

                if (!this.modoEdicion)
                {
                    var resultado = controller.Insertar(estudiante);
                    if (resultado == "ok")
                    {
                        MessageBox.Show("Estudiante guardado con éxito");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Error al guardar: {resultado}");
                    }
                }
                else
                {
                    estudiante.IdEstudiante = this.id;
                    var resultado = controller.Actualizar(estudiante);
                    if (resultado == "ok")
                    {
                        MessageBox.Show("Estudiante actualizado con éxito");
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
                MessageBox.Show("El campo Edad debe ser un número entero válido.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }

        private void frmEstudiante_Load(object sender, EventArgs e)
        {
            if (!this.modoEdicion)
            {
                lblTitulo.Text = "Ingreso de Nuevo Estudiante";
            }
            else
            {
                lblTitulo.Text = "Actualización de Estudiante";
                var estudianteController = new estudiante_controller();
                var estudiante = estudianteController.obtenerPorId(this.id);

                if (estudiante != null)
                {
                    txtNombre.Text = estudiante.NombreEstudiante;
                    txtApellido.Text = estudiante.ApellidoEstudiante;
                    txtEdad.Text = estudiante.Edad.ToString();
                    txtDireccion.Text = estudiante.Direccion;
                }
                else
                {
                    MessageBox.Show("No se encontró el estudiante seleccionado.");
                    this.Close();
                }
            }

        }
    }
}
