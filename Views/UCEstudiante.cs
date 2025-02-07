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

namespace RegistroEstudiantes.Views
{
    public partial class UCEstudiante : UserControl
    {

        public UCEstudiante()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Estudiantes.frmEstudiante frm = new Estudiantes.frmEstudiante("n");
            frm.Text = "Formulario de Estudiantes";
            frm.ShowDialog();
            this.cargaGrilla(1);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.cargaGrilla(2);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.cargaGrilla(1);
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var filaselecciona = dataGridView1.Rows[e.RowIndex];
                var IdEstudiante = filaselecciona.Cells["IdEstudiante"].Value;
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    EditarEstudiante((int)IdEstudiante);
                }
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    EliminarEstudiante((int)IdEstudiante);
                }
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cargaGrilla(2);
        }

        private void UCEstudiante_Load(object sender, EventArgs e)
        {
            var logicaEstudiante = new estudiante_controller();
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = logicaEstudiante.obtenerTodos();
            this.cargaGrilla(1);
        }

        public void cargaGrilla(int numero)
        {

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            var logicaEstudiante = new estudiante_controller();
            var autoincrmento = new DataGridViewTextBoxColumn
            {
                HeaderText = "N.-",
                ReadOnly = true
            };
            dataGridView1.Columns.Add(autoincrmento);

            var btnEditar = new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true
            };

            var btnEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true
            };
            if (numero == 1)
            {
                dataGridView1.DataSource = logicaEstudiante.obtenerTodos();
            }
            else
            {
                dataGridView1.DataSource = logicaEstudiante.Buscar(txtBuscar.Text.Trim());
            }

            dataGridView1.Columns["NombreEstudiante"].HeaderText = "NombreEstudiante";
            dataGridView1.Columns["ApellidoEstudiante"].HeaderText = "ApellidoEstudiante";
            dataGridView1.Columns["Edad"].HeaderText = "Edad";
            dataGridView1.Columns["Direccion"].HeaderText = "Direccion";
            dataGridView1.Columns["IdEstudiante"].Visible = false;

            dataGridView1.Columns.Add(btnEditar);
            dataGridView1.Columns.Add(btnEliminar);

            //estudiante_model IdEstudiante
            //Apellido Edad Direccion
        }
        public void EditarEstudiante(int id)
        {
            Estudiantes.frmEstudiante frmpersonal = new Estudiantes.frmEstudiante(id.ToString());
            frmpersonal.ShowDialog();
            this.cargaGrilla(1);
        }
        public void EliminarEstudiante(int id)
        {
            DialogResult cuadrodialogo = MessageBox.Show("Esta srguro que desea eliminar el personal"
                , "Eliminar Personal", MessageBoxButtons.YesNo);
            if (cuadrodialogo == DialogResult.Yes)
            {
                var estudiante_controller = new estudiante_controller();
                if (estudiante_controller.Eliminar(id))
                {
                    MessageBox.Show("El registro se a eliminado con exito");
                    this.cargaGrilla(1);
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al eliminar");
                }
            }
            else
            {
                MessageBox.Show("El usuario cancelo la eliminacion");
            }
        }

    }
}
