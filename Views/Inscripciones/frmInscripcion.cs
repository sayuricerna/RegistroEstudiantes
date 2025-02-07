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

namespace RegistroEstudiantes.Views.Inscripciones
{
    public partial class frmInscripcion : Form
    {
        //inscripion_model IdInscripcion IdCurso IdEstudiante Fecha

        public bool modoEdicion = false;
        public int id = 0;
        public frmInscripcion(string modo)
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
        public void cargaCursos()
        {
            var listacursos = new curso_controller();
            cmbCursos.DataSource = listacursos.obtenerTodos();
            cmbCursos.ValueMember = "IdCurso";
            cmbCursos.DisplayMember = "NombreCurso";
        }
        public void cargaEstudiantes()
        {
            var listaestudiantes = new estudiante_controller();
            cmbEstudiantes.DataSource = listaestudiantes.obtenerTodos();
            cmbEstudiantes.ValueMember = "IdEstudiante";
            cmbEstudiantes.DisplayMember = "NombreCompleto";

        }

        private void frmInscripcion_Load(object sender, EventArgs e)
        {
            cargaEstudiantes();
            cargaCursos();
            if (!this.modoEdicion)
            {
                lblTitulo.Text = "Ingreso de Nueva Incripción";
            }
            else
            {
                lblTitulo.Text = " Actualizacion de Incripción";
                var inscripcionController = new inscripcion_controller();
                var inscripcion = inscripcionController.obtenerPorId(this.id);
                cmbEstudiantes.SelectedValue = inscripcion.IdEstudiante;
                cmbCursos.SelectedValue = inscripcion.IdCurso;

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbEstudiantes.SelectedValue == null || cmbCursos.SelectedValue == null)
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.");
                return;
            }

            try
            {
                var inscripcion = new inscripcion_model()
                {
                    IdEstudiante = (int)cmbEstudiantes.SelectedValue,
                    IdCurso = (int)cmbCursos.SelectedValue,
                };

                var controller = new inscripcion_controller();

                if (!this.modoEdicion && controller.verificarInscripcion(inscripcion.IdEstudiante, inscripcion.IdCurso))
                {
                    MessageBox.Show("Este estudiante ya está inscrito en este curso.");
                    return;
                }

                if (!this.modoEdicion)
                {
                    var resultado = controller.Insertar(inscripcion);
                    if (resultado == "ok")
                    {
                        MessageBox.Show("Inscripción guardada con éxito.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Error al guardar: {resultado}");
                    }
                }
                else
                {
                    inscripcion.IdInscripcion = this.id;
                    var resultado = controller.Actualizar(inscripcion);
                    if (resultado == "ok")
                    {
                        MessageBox.Show("Inscripción actualizada con éxito.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Error al actualizar: {resultado}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }

        private void cmbCursos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
