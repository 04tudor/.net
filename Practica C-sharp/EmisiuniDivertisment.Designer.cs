namespace Practica_C_sharp
{
    partial class EmisiuniDivertisment
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
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
            this.button1.Location = new System.Drawing.Point(235, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 38);
            this.button1.TabIndex = 19;
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
            this.label3.Location = new System.Drawing.Point(33, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 25);
            this.label3.TabIndex = 18;
            this.label3.Text = "Introduceti Id Canal:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(377, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(191, 34);
            this.textBox1.TabIndex = 17;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.Location = new System.Drawing.Point(12, 136);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(598, 306);
            this.dataGridView1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(33, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 25);
            this.label1.TabIndex = 21;
            this.label1.Text = "Selectati Tipul Emisiunii:";
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
            this.tipcmb.Location = new System.Drawing.Point(377, 49);
            this.tipcmb.Margin = new System.Windows.Forms.Padding(4);
            this.tipcmb.Name = "tipcmb";
            this.tipcmb.Size = new System.Drawing.Size(191, 36);
            this.tipcmb.TabIndex = 22;
            this.tipcmb.UseWaitCursor = true;
            // 
            // EmisiuniDivertisment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(622, 454);
            this.Controls.Add(this.tipcmb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmisiuniDivertisment";
            this.Text = "EmisiuniDivertisment";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox tipcmb;
    }
}