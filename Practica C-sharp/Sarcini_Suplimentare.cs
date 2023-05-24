using Practica_C_sharp.SarciniSuplimentare;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_C_sharp
{
    public partial class Sarcini_Suplimentare : Form
    {
        public Point mouseLocation;
        Thread th;
        public void openhome(object obj)
        {
            Application.Run(new Home());
        }
        public Sarcini_Suplimentare()
        {
            InitializeComponent();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            NumarEmisiuniCanal myForm = new NumarEmisiuniCanal();//cand apasam pe buton se deschide alt form dat
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(myForm);//afisam in panel formul nostru
            myForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Sarcini_Suplimentare_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

   

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            CanaleEmisiuniTip myForm = new CanaleEmisiuniTip();//cand apasam pe buton se deschide alt form dat
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.Dock = DockStyle.Fill;

            this.panel1.Controls.Add(myForm);//afisam in panel formul nostru
            myForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Top10 myForm = new Top10();//cand apasam pe buton se deschide alt form dat
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.Dock = DockStyle.Fill;

            this.panel1.Controls.Add(myForm);//afisam in panel formul nostru
            myForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            chart myForm = new chart();//cand apasam pe buton se deschide alt form dat
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.Dock = DockStyle.Fill;

            this.panel1.Controls.Add(myForm);//afisam in panel formul nostru
            myForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            ExportPDF myForm = new ExportPDF();//cand apasam pe buton se deschide alt form dat
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.Dock = DockStyle.Fill;

            this.panel1.Controls.Add(myForm);//afisam in panel formul nostru
            myForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            raport myForm = new raport();//cand apasam pe buton se deschide alt form dat
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.Dock = DockStyle.Fill;

            this.panel1.Controls.Add(myForm);//afisam in panel formul nostru
            myForm.Show(); 
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);

        }

     

        private void pictureBox1_Click(object sender, EventArgs e)
        {this.Close();//acest form se inchide
            th = new Thread(openhome);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();//formul Home devine principal

        }
    }
}
