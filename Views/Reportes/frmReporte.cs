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

namespace RegistroEstudiantes.Views.Reportes
{
    public partial class frmReporte : Form
    {
        public frmReporte()
        {
            InitializeComponent();
        }

        private void frmReporte_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'registroEstudiantesDataSet.vistaEstudiantesPorCurso' table. You can move, or remove it, as needed.
            this.vistaEstudiantesPorCursoTableAdapter.Fill(this.registroEstudiantesDataSet1.vistaEstudiantesPorCurso);

        }

        private void frmReporte_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'registroEstudiantesDataSet1.vistaEstudiantesPorCurso' table. You can move, or remove it, as needed.
            this.vistaEstudiantesPorCursoTableAdapter.Fill(this.registroEstudiantesDataSet1.vistaEstudiantesPorCurso);

            this.reportViewer1.RefreshReport();
            cargaCursos();
        }

        public void cargaCursos()
        {
            var listacursos = new curso_controller();
            cmbCursos.DataSource = listacursos.obtenerTodos();
            cmbCursos.ValueMember = "IdCurso";
            cmbCursos.DisplayMember = "NombreCurso";
        }
        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int idCurso = Convert.ToInt32(cmbCursos.SelectedValue);
            this.vistaEstudiantesPorCursoTableAdapter.FillByIdCurso(this.registroEstudiantesDataSet1.vistaEstudiantesPorCurso, idCurso);
            this.reportViewer1.RefreshReport();

        }
    }
}
