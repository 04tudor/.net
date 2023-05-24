namespace Practica_C_sharp
{
    partial class CrescatorCanale
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
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tipcmb = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(233, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 38);
            this.button1.TabIndex = 99;
            this.button1.Text = "Afisare";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(52, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 25);
            this.label3.TabIndex = 98;
            this.label3.Text = "Selectati Tipul Emisiune";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(107, 106);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(417, 201);
            this.dataGridView1.TabIndex = 96;
            // 
            // tipcmb
            // 
            this.tipcmb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tipcmb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.tipcmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tipcmb.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipcmb.ForeColor = System.Drawing.Color.White;
            this.tipcmb.FormattingEnabled = true;
            this.tipcmb.Items.AddRange(new object[] {
            "Serial",
            "Desene animate",
            "Sport",
            "Stiri",
            "Documentar",
            "Divertisment",
            "Talk Show",
            "Filme",
            "Interviu"});
            this.tipcmb.Location = new System.Drawing.Point(350, 13);
            this.tipcmb.Margin = new System.Windows.Forms.Padding(4);
            this.tipcmb.Name = "tipcmb";
            this.tipcmb.Size = new System.Drawing.Size(198, 36);
            this.tipcmb.TabIndex = 100;
            this.tipcmb.UseWaitCursor = true;
            // 
            // CrescatorCanale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(604, 407);
            this.Controls.Add(this.tipcmb);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CrescatorCanale";
            this.Text = "CrescatorCanale";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.ComboBox tipcmb;
    }
}