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
    public partial class Filme : Form
    {
        public Filme()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tipcmb.Text))//verifica daca s-au introdus date
            {
                MessageBox.Show("Introduceti Tipul emisiunii !", "A intervenit o eroare !!! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (String.IsNullOrEmpty(textBox2.Text))//verifica daca s-au introdus date
            {
                MessageBox.Show("Introduceti Durata !", "A intervenit o eroare !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {//atribuie date in variabile locale din textbox
                String tip = tipcmb.Text;
                int durata = Convert.ToInt32(textBox2.Text);
                //string de conectare
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=TV;Integrated Security=True");//stringul de conectare
                try
                {
                    using (con)
                    {
                        con.Open();//deschidere conexiune
                        using (SqlCommand command = new SqlCommand("SELECT * FROM EMISIUNITV WHERE Tip=@Tip and DurataMin>@Durata"
                                                                     , con))//stringul de query pentru a afisa emisiunile de tipul dorit cu durata mai mare decat cea introdusa
                        {//creare parametri cu text boxurile introduse


                            command.Parameters.AddWithValue("@Tip", tip);
                            command.Parameters.AddWithValue("@Durata", durata);

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
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);//obliga de introdus date de tip integer
        }
    }
}
