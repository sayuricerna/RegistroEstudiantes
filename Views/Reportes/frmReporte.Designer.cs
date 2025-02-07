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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cmbCursos = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.registroEstudiantesDataSet1 = new RegistroEstudiantes.RegistroEstudiantesDataSet1();
            this.vistaEstudiantesPorCursoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vistaEstudiantesPorCursoTableAdapter = new RegistroEstudiantes.RegistroEstudiantesDataSet1TableAdapters.vistaEstudiantesPorCursoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.registroEstudiantesDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaEstudiantesPorCursoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.vistaEstudiantesPorCursoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "RegistroEstudiantes.Views.Reportes.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 92);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1306, 453);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // cmbCursos
            // 
            this.cmbCursos.FormattingEnabled = true;
            this.cmbCursos.Location = new System.Drawing.Point(12, 12);
            this.cmbCursos.Name = "cmbCursos";
            this.cmbCursos.Size = new System.Drawing.Size(916, 24);
            this.cmbCursos.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(1025, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(236, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "button1";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // registroEstudiantesDataSet1
            // 
            this.registroEstudiantesDataSet1.DataSetName = "RegistroEstudiantesDataSet1";
            this.registroEstudiantesDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vistaEstudiantesPorCursoBindingSource
            // 
            this.vistaEstudiantesPorCursoBindingSource.DataMember = "vistaEstudiantesPorCurso";
            this.vistaEstudiantesPorCursoBindingSource.DataSource = this.registroEstudiantesDataSet1;
            // 
            // vistaEstudiantesPorCursoTableAdapter
            // 
            this.vistaEstudiantesPorCursoTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 709);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cmbCursos);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporte";
            this.Text = "frmReporte";
            this.Load += new System.EventHandler(this.frmReporte_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.registroEstudiantesDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaEstudiantesPorCursoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox cmbCursos;
        private System.Windows.Forms.Button btnBuscar;
        private RegistroEstudiantesDataSet1 registroEstudiantesDataSet1;
        private System.Windows.Forms.BindingSource vistaEstudiantesPorCursoBindingSource;
        private RegistroEstudiantesDataSet1TableAdapters.vistaEstudiantesPorCursoTableAdapter vistaEstudiantesPorCursoTableAdapter;
    }
}