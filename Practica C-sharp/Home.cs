using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_C_sharp
{
    public partial class Home : Form
    {    
        public Point mouseLocation;
      
        public Home()
        {
            InitializeComponent();
          
        }

        Thread th;
        public void openmdi(object obj)
        {
        Application.Run(new Sarcini_Suplimentare());
        }

        private void mouse_Down(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void mouse_Move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/tudortc2");
        }
       

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/tudorcoretchi/");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/tudor_tc/");
        }
       
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("+373 67 499754");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void button18_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            InregistrareCanal myForm = new InregistrareCanal();//cand apasam pe buton se deschide alt form dat
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.Dock = DockStyle.Fill;

            this.panel1.Controls.Add(myForm);//afisam in panel formul nostru
            myForm.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            InregistrareEmisiune myForm = new InregistrareEmisiune();//cand apasam pe buton se deschide alt form dat
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.Dock = DockStyle.Fill;

            this.panel1.Controls.Add(myForm);//afisam in panel formul nostru
            myForm.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            AnuleazaEmisiune myForm = new AnuleazaEmisiune();//cand apasam pe buton se deschide alt form dat
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.Dock = DockStyle.Fill;

            this.panel1.Controls.Add(myForm);//afisam in panel formul nostru
            myForm.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            EmisiuniCanal myForm = new EmisiuniCanal();//cand apasam pe buton se deschide alt form dat
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.Dock = DockStyle.Fill;
            myForm.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(myForm);//afisam in panel formul nostru
            myForm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            EmisiuniDivertisment myForm = new EmisiuniDivertisment();//cand apasam pe buton se deschide alt form dat
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
            ExportExcel myForm = new ExportExcel();//cand apasam pe buton se deschide alt form dat
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
            Filme myForm = new Filme();//cand apasam pe buton se deschide alt form dat
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
            CrescatorCanale myForm = new CrescatorCanale();//cand apasam pe buton se deschide alt form dat
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
            EmisiuneVizionataCanal myForm = new EmisiuneVizionataCanal();//cand apasam pe buton se deschide alt form dat
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.Dock = DockStyle.Fill;

            this.panel1.Controls.Add(myForm);//afisam in panel formul nostru
            myForm.Show();
        }
        ToolTip t1 = new ToolTip();

           private void button7_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            PublicitateTimp myForm = new PublicitateTimp();//cand apasam pe buton se deschide alt form dat
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            myForm.Dock = DockStyle.Fill;

            myForm.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(myForm);//afisam in panel formul nostru
            myForm.Show();
        }

      

        private void button1_MouseHover(object sender, EventArgs e)
        {
toolTip1.Show("5.Afişează emisiunile de un Divertisment ale unui canal", button1);
        }

        private void button20_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("4.  Afişează lista emisiunilor unui Canal", button20);

        }

        private void button17_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("3. Exclude datele, ce corespund unei emisiuni anulate ale unui Canal", button17);

        }

        private void button19_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("2. Înregistrează o nouă emisiune pentru un Canal", button19);

        }

        private void button18_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(" 1. Înregistrează un nou canal TV", button18);

        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(" 6. Export  lista emisiunilor Intre ora 15:00 si 19:00", button3);

        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("7. Afişează Crescator numărul emisiunilor de un tip  pentru canale.", button6);

        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("8. Afişează numele emisiunilor de un tip  cu durata mai mare de un timp", button4);

        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("9. Afișează timpul preconizat pentru publicitate pentru 24 ore", button7);

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("10. Afiseaza cele mai vizionate emisiuni a fiecărui canal", button2);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();//acest form se inchide
            th = new Thread(openmdi);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();//formul Home devine principal
        }

        private void Home_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=TV;Integrated Security=True");//stringul de conectare
            using (con)
            {

                con.Open();
                var query = "SELECT COUNT(*) FROM CANALTV ";
                var query2 = "SELECT COUNT(*) FROM EMISIUNITV ";
                SqlCommand comand = new SqlCommand(query, con);
                             SqlCommand comand2 = new SqlCommand(query2, con);



                    var canale = (int)comand.ExecuteScalar();
                var emisiuni = (int)comand2.ExecuteScalar();

                label7.Text = "Canale: " + canale.ToString()+"\nEmisiuni: "+emisiuni.ToString();
                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

     
    }
}
