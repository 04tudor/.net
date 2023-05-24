using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_C_sharp
{
    public partial class Top10 : Form
    {
        public Top10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Top10_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=TV;Integrated Security=True");//stringul de conectare
            try
            {
                using (con)
                {
                    con.Open();//deschidere conexiune
                    using (SqlCommand command = new SqlCommand("EXEC top10 "
                                , con))//stringul de query pentru a executa procedura
                    {//creare parametri cu text boxurile introduse

                        SqlDataReader reader = command.ExecuteReader();//executare comanda
                        DataTable dt = new DataTable();//creare tabel de date
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;//afisare
                        con.Close();//inchidere conexiune

                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare " + ex.Message);//in caz de eroare se afiseeaza message box
            }
        }
    }
}
