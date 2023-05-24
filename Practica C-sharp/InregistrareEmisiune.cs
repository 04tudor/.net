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
    public partial class InregistrareEmisiune : Form
    {
        public InregistrareEmisiune()
        {
            InitializeComponent();
        }

        private void InregistrareEmisiune_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))//verifica daca s-au introdus date
            {
                MessageBox.Show("Introduceti id-ul Emisiunii !", "A intervenit o eroare !!! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (String.IsNullOrEmpty(textBox1.Text))//verifica daca s-au introdus date
            {
                MessageBox.Show("Introduceti id-ul Canalului !", "A intervenit o eroare !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(textBox3.Text))//verifica daca s-au introdus date
            {
                MessageBox.Show("Introduceti Denumirea !", "A intervenit o eroare !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(textBox4.Text))//verifica daca s-au introdus date
            {
                MessageBox.Show("Introduceti Limba !", "A intervenit o eroare !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(textBox5.Text))//verifica daca s-au introdus date
            {
                MessageBox.Show("Introduceti Ora (**:**) !", "A intervenit o eroare !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(textBox6.Text))//verifica daca s-au introdus date
            {
                MessageBox.Show("Introduceti Durata in minute !", "A intervenit o eroare !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(tipcmb.Text))//verifica daca s-au introdus date
            {
                MessageBox.Show("Introduceti Tipul Emisiunii !", "A intervenit o eroare !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(textBox8.Text))//verifica daca s-au introdus date
            {
                MessageBox.Show("Introduceti Audienta !", "A intervenit o eroare !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {//stringul de conectare
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=TV;Integrated Security=True");//stringul de conectare
             //atribuire valori in variabilele locale din textbox
                int idEmisiune = Convert.ToInt32(textBox2.Text);
                int idcanal = Convert.ToInt32(textBox1.Text);
                String denumire = textBox3.Text;
                String limba = textBox4.Text;
                String ora = textBox5.Text;
                int durata = Convert.ToInt32(textBox6.Text);
                String tip = tipcmb.Text;
                int audienta = Convert.ToInt32(textBox8.Text);
                try
                {
                    using (con)
                    {
                        con.Open();//deschidere conexiune
                        using (SqlCommand command = new SqlCommand("INSERT INTO EMISIUNITV Values( " +
                                                                      " @IdEmisiune, " +
                                                                     " @IdCanal, " +
                                                                     "@Denumire, " +
                                                                     " @Limba , " +
                                                                       " @Ora, " +
                                                                         " @DurataMin, " +
                                                                           " @Tip, " +
                                                                             " @audienta) " 
                                                                     , con))//stringul de query pentru adauga date in tabelul emisiuni
                        {//creare parametri cu text boxurile introduse
                             command.Parameters.AddWithValue("@IdEmisiune",idEmisiune );
                            command.Parameters.AddWithValue("@IdCanal", idcanal);
                            command.Parameters.AddWithValue("@Denumire", denumire);
                            command.Parameters.AddWithValue("@Limba",limba );
                            command.Parameters.AddWithValue("@Ora", ora);
                            command.Parameters.AddWithValue("@DurataMin", durata);
                            command.Parameters.AddWithValue("@Tip", tip);
                            command.Parameters.AddWithValue("@audienta", audienta);

                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Emisiunea a fost Adaugat cu succes!");//Se afiseaza message box
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);//obliga sa introducem date de tip integer
        }
    }
}
