using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroEstudiantes.Views
{
    /*
     * Registro de Estudiantes

        Diseña una aplicación que administre la información de estudiantes y cursos en una institución educativa. 
        Entidades:

        Estudiante (ID, Nombre, Apellido, Edad, Dirección)
        Curso (ID, Nombre, Créditos, Profesor)
        Inscripción (ID, ID_Estudiante, ID_Curso, Fecha)
        Debe permitir realizar CRUD y visualizar datos en una interfaz gráfica.
     */
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            UCEstudiante frmNueva = new UCEstudiante();
            pnlGeneral.Controls.Clear();
            frmNueva.Dock = DockStyle.Fill;
            pnlGeneral.Controls.Add(frmNueva);
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            UCCurso frmNueva = new UCCurso();
            pnlGeneral.Controls.Clear();
            frmNueva.Dock = DockStyle.Fill;
            pnlGeneral.Controls.Add(frmNueva);
        }

        private void btnInscripciones_Click(object sender, EventArgs e)
        {
            UCInscripcion frmNueva = new UCInscripcion();
            pnlGeneral.Controls.Clear();
            frmNueva.Dock = DockStyle.Fill;
            pnlGeneral.Controls.Add(frmNueva);
        }
    }
}
