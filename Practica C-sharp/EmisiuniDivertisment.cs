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
    public partial class EmisiuniDivertisment : Form
    {
        public EmisiuniDivertisment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))//verifica daca s-au introdus date
            {
                MessageBox.Show("Introduceti Id Canal !", "A intervenit o eroare !!! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (String.IsNullOrEmpty(tipcmb.Text))//verifica daca s-au introdus date
            {
                MessageBox.Show("Tipul Emisiunii !", "A intervenit o eroare !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //variabile locale din textboxuri
                int idCanal = Convert.ToInt32(textBox1.Text);
                String tip = Convert.ToString(tipcmb.Text);
                //string de conectare
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=TV;Integrated Security=True");//stringul de conectare
                try
                {
                    using (con)
                    {
                        con.Open();//deschidere conexiune
                        using (SqlCommand command = new SqlCommand("SELECT * FROM EMISIUNITV Where IdCanal=@IdCanal and Tip=@Tip"
                                                                     , con))//stringul de query pentru afisarea emisiunilor din canalul dorit de tipul dorit
                        {//creare parametri cu text boxurile introduse

                            command.Parameters.AddWithValue("@IdCanal", idCanal);

                            command.Parameters.AddWithValue("@Tip", tip);
                            SqlDataReader reader = command.ExecuteReader();//executare comanda
                            DataTable dt = new DataTable();//creare tabel de date
                            dt.Load(reader);
                            dataGridView1.DataSource = dt;//afisare
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;//auto size

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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);//obliga introducerea datelor de tip integer
        }
    }
}
