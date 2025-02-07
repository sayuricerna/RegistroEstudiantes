namespace RegistroEstudiantes.Views.Reportes
{
    partial class frmReporte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.vistaEstudiantesPorCursoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.registroEstudiantesDataSet1 = new RegistroEstudiantes.RegistroEstudiantesDataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cmbCursos = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.vistaEstudiantesPorCursoTableAdapter = new RegistroEstudiantes.RegistroEstudiantesDataSet1TableAdapters.vistaEstudiantesPorCursoTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vistaEstudiantesPorCursoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registroEstudiantesDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // vistaEstudiantesPorCursoBindingSource
            // 
            this.vistaEstudiantesPorCursoBindingSource.DataMember = "vistaEstudiantesPorCurso";
            this.vistaEstudiantesPorCursoBindingSource.DataSource = this.registroEstudiantesDataSet1;
            // 
            // registroEstudiantesDataSet1
            // 
            this.registroEstudiantesDataSet1.DataSetName = "RegistroEstudiantesDataSet1";
            this.registroEstudiantesDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.vistaEstudiantesPorCursoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "RegistroEstudiantes.Views.Reportes.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 92);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1330, 615);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // cmbCursos
            // 
            this.cmbCursos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCursos.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCursos.FormattingEnabled = true;
            this.cmbCursos.Location = new System.Drawing.Point(12, 36);
            this.cmbCursos.Name = "cmbCursos";
            this.cmbCursos.Size = new System.Drawing.Size(1036, 37);
            this.cmbCursos.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Navy;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBuscar.Location = new System.Drawing.Point(1054, 29);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(253, 51);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // vistaEstudiantesPorCursoTableAdapter
            // 
            this.vistaEstudiantesPorCursoTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Reporte de Estudiantes Inscritos por Curso";
            // 
            // frmReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1328, 709);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cmbCursos);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporte";
            this.Text = "frmReporte";
            this.Load += new System.EventHandler(this.frmReporte_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.vistaEstudiantesPorCursoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registroEstudiantesDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox cmbCursos;
        private System.Windows.Forms.Button btnBuscar;
        private RegistroEstudiantesDataSet1 registroEstudiantesDataSet1;
        private System.Windows.Forms.BindingSource vistaEstudiantesPorCursoBindingSource;
        private RegistroEstudiantesDataSet1TableAdapters.vistaEstudiantesPorCursoTableAdapter vistaEstudiantesPorCursoTableAdapter;
        private System.Windows.Forms.Label label1;
    }
}