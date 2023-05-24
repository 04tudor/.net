namespace Practica_C_sharp.SarciniSuplimentare
{
    partial class raport
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tVDataSet = new Practica_C_sharp.TVDataSet();
            this.cANALTVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cANALTVTableAdapter = new Practica_C_sharp.TVDataSetTableAdapters.CANALTVTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tVDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cANALTVBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(73)))));
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.cANALTVBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Practica_C_sharp.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(604, 407);
            this.reportViewer1.TabIndex = 0;
            // 
            // tVDataSet
            // 
            this.tVDataSet.DataSetName = "TVDataSet";
            this.tVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cANALTVBindingSource
            // 
            this.cANALTVBindingSource.DataMember = "CANALTV";
            this.cANALTVBindingSource.DataSource = this.tVDataSet;
            // 
            // cANALTVTableAdapter
            // 
            this.cANALTVTableAdapter.ClearBeforeFill = true;
            // 
            // raport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(604, 407);
            this.Controls.Add(this.reportViewer1);
            this.Name = "raport";
            this.Text = "raport";
            this.Load += new System.EventHandler(this.raport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tVDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cANALTVBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private TVDataSet tVDataSet;
        private System.Windows.Forms.BindingSource cANALTVBindingSource;
        private TVDataSetTableAdapters.CANALTVTableAdapter cANALTVTableAdapter;
    }
}