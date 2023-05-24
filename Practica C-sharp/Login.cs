using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Practica_C_sharp
{
    public partial class Login : Form
    {
        Thread th;
        string username, password;
        public Login()
        {
            InitializeComponent();
        
        }
        public void openmdi(object obj)
        {
            Application.Run(new Home());//deschide forma home
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxUsername.Text))//verifica daca s-au introdus date
            {
                MessageBox.Show("Introduceti Username !", "A intervenit o eroare !!! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (String.IsNullOrEmpty(textBoxPassword.Text))//verifica daca s-au introdus date
            {
                MessageBox.Show("Introduceti Password !", "A intervenit o eroare !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (checkUser() == true)//daca exista asa utilizator,se deschide formul Home
            { 
                this.Close();//acest form se inchide
                th = new Thread(openmdi);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();//formul Home devine principal
            }
            else
            {
                MessageBox.Show("utilizator inexistent");//daca nu exista acest utilizator se afiseaza mesajul

            }
        }


        private Boolean checkUser()
        {//variabilel logale din textbox
         
            var loginUser = textBoxUsername.Text;
            this.username = loginUser;
            var passUser = textBoxPassword.Text;
            this.password = passUser;
          
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=TV;Integrated Security=True");
            //stringul de conectare
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select username,pass from users where username = '{loginUser}' and pass = '{passUser}'  ";
            //verifica daca in baza noastra de date exista acest login si parola
            SqlCommand command = new SqlCommand(querystring, con);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

  

        private void pictureBox1_Click(object sender, EventArgs e)
        {
textBoxPassword.UseSystemPasswordChar = true;//ascunde textul
            pictureBox2.Visible = true;
            pictureBox1.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
 textBoxPassword.UseSystemPasswordChar = false;//daca tapam inca odata pe imagine parola se afiseaza
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;
        }

        private void textBoxUsername_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter) buttonLogin_Click(sender,e);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginUser = textBoxUsername.Text;
            this.username = loginUser;
            var passUser = textBoxPassword.Text;
            this.password = passUser;

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=TV;Integrated Security=True");
            //stringul de conectare
            string querystring = $"insert into users(username, pass) values('{loginUser}','{passUser}') ";
            SqlCommand command = new SqlCommand(querystring, con);
            //in acest querry se introduce in baza noastra de date deja loginul si parola si se creeaza un cont
            con.Open();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Contul a fost creat cu succes!", "Succes!");
                Login frm_login = new Login();
                //ne trimite dinnou la formul de login
                this.Hide();
                frm_login.ShowDialog();
            }
            else
            {
                MessageBox.Show("Contul nu a fost creat!");
            }
            con.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = '*';//daca tapam odata pe imaginea cu ochiul parola se transforma in *
            pictureBox2.Visible = false;

        }

    }
}
