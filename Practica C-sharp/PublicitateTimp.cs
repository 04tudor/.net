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
    public partial class PublicitateTimp : Form
    {
        public PublicitateTimp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))//verifica daca s-au introdus date
            {
                MessageBox.Show("Introduceti Id Canal !", "A intervenit o eroare !!! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                int idCanal = Convert.ToInt32(textBox2.Text);//verifica daca s-au introdus date
                //string de conectare
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=TV;Integrated Security=True");//stringul de conectare
                try
                {
                    using (con)
                    {
                        con.Open();//deschidere conexiune
                        using (SqlCommand command = new SqlCommand("SELECT * FROM duratapublicitate WHERE IdCanal=@IdCanal"
                                                                     , con))//stringul de query pentru a afisa durata publicitate a canalului dorit
                        {//creare parametri cu text boxurile introduse


                            command.Parameters.AddWithValue("@IdCanal", idCanal);

                            SqlDataReader reader = command.ExecuteReader();//executare comanda
                            DataTable dt = new DataTable();//creare tabel de date
                            dt.Load(reader);
                            dataGridView1.DataSource = dt;//afisare
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;//auto size

                            if (dataGridView1.DataSource == null || dataGridView1.Rows.Count == 0)
                            {
                                MessageBox.Show("Eroare, Lista este goala");
                            }
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);//obliga sa introducem date de tip integer
        }
    }
}
