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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Practica_C_sharp
{
    public partial class InregistrareCanal : Form
    {
        public InregistrareCanal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox1.Text))//verifica daca s-au introdus date
            {
                MessageBox.Show("Introduceti id-ul Canalului !", "A intervenit o eroare !!! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (String.IsNullOrEmpty(textBox2.Text))//verifica daca s-au introdus date
            {
                MessageBox.Show("Introduceti Denumirea !", "A intervenit o eroare !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(tipcmb.Text))//verifica daca s-au introdus date
            {
                MessageBox.Show("Introduceti tematica !", "A intervenit o eroare !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {//string de conectare
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=TV;Integrated Security=True");//stringul de conectare
               //atribuire date din textbox in varabilele noastre locale
                int canal = Convert.ToInt32(textBox1.Text);
                String denumire = textBox2.Text;
                String tematica = tipcmb.Text;

                try
                {
                    using (con)
                    {
                        con.Open();//deschidere conexiune
                        using (SqlCommand command = new SqlCommand("INSERT INTO CANALTV Values( " +
                                                                     " @IdCanal, " +
                                                                     "@Denumire, " +
                                                                     " @Tematica ) "

                                                                     , con))//stringul de query pentru a adauga date in tabelul canale
                        {//creare parametri cu text boxurile introduse
                            command.Parameters.AddWithValue("@IdCanal", canal);
                            command.Parameters.AddWithValue("@Denumire", denumire);
                            command.Parameters.AddWithValue("@Tematica", tematica);




                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Inregistrarea a fost Adaugat cu succes!");//Se afiseaza message box
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare " + ex.Message);//in caz de eroare se afiseeaza message box
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);//obliga de introdus date de tip integer
        }
    }
}