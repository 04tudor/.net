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
    public partial class CanaleEmisiuniTip : Form
    {
        public CanaleEmisiuniTip()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))//verifica daca s-au introdus date in textbox
            {
                MessageBox.Show("Tipul Emisiunii !", "A intervenit o eroare !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //dam valoare variabilei locale cu cea din textbox
                String tip = Convert.ToString(textBox2.Text);
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=TV;Integrated Security=True");//stringul de conectare
                try
                {
                    using (con)
                    {
                        con.Open();//deschidere conexiune
                        using (SqlCommand command = new SqlCommand("EXEC AfisareCanalTematica  @Tip"   , con))//stringul de query a executa procedura de a afisa canalele cu tematica dorita
                        {//creare parametri cu text boxurile introduse

                            command.Parameters.AddWithValue("@Tip", tip);
                            SqlDataReader reader = command.ExecuteReader();//executare comanda
                            DataTable dt = new DataTable();//creare tabel de date
                            dt.Load(reader);
                            dataGridView1.DataSource = dt;//afisare
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;//marime automata dupa datele afisate

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
}
