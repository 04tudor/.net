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
    public partial class AnuleazaEmisiune : Form
    {
        public AnuleazaEmisiune()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {//verifica daca s-au inserat date in textbox,ceea ce este obligatoriu
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Introduceti  Id Emisiune", "A intervenit o eroare !!! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                //dam valoare unei variabile datele din textbox
                int id = Convert.ToInt32(textBox1.Text);

                //stringul de conectare
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=TV;Integrated Security=True");//stringul de conectare
                try
                {
                    using (con)
                    {
                        con.Open();//deschidere conexiune
                        //query pentru a insera date in tabelul emisiunianulate,a afisa si a sterge din emisiunitv
                        using (SqlCommand commandinsert = new SqlCommand("INSERT INTO EMISIUNIANULATE (IdEmisiune, Denumire,Ora)" +
                            " SELECT IdEmisiune, Denumire,Ora FROM EMISIUNITV WHERE IdEmisiune=@IdEmisiune;" +
                            "DELETE FROM EMISIUNITV WHERE IdEmisiune=@IdEmisiune;"


                                                                   , con))//stringul de query 

                        {//creare parametri cu text boxurile introduse


                            commandinsert.Parameters.AddWithValue("@IdEmisiune", id);
                            SqlDataReader reader1 = commandinsert.ExecuteReader();//executare comanda
                            con.Close();//inchidere conexiune
                            reader1.Close();
                            MessageBox.Show("Emisiunea a fost Stearsa din tabelul Emisiuni si adaugata in emisiuni anulate! ");
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

        private void AnuleazaEmisiune_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {//stringul de conectare
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=TV;Integrated Security=True");//stringul de conectare

            try
            {
         using (con)
         {
             con.Open();//deschidere conexiune


             using (SqlCommand command = new SqlCommand("SELECT * FROM EMISIUNIANULATE", con))//stringul de query pentru a afisa emisiunile anulate
             {//creare parametri cu text boxurile introduse


                 SqlDataReader reader = command.ExecuteReader();//executare comanda
                 DataTable dt = new DataTable();//creare tabel de date
                 dt.Load(reader);
                 dataGridView1.DataSource = dt;//afisare
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;//a da marimea data grid view automata dupa datele afisate

                        con.Close();//inchidere conexiune
                        reader.Close();
             }
         }

         con.Close();
     }
     catch (Exception ex)
     {
         MessageBox.Show("Eroare " + ex.Message);//in caz de eroare se afiseeaza message box
     }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);//obliga ca datele introduse in textbox sa fie integer
        }
    }
}
