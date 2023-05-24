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
    public partial class CrescatorCanale : Form
    {
        public CrescatorCanale()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tipcmb.Text))//verifica daca s-au introdus date in textbox
            {
                MessageBox.Show("Introduceti Tipul Emisiunii !", "A intervenit o eroare !!! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                //dam valoare variabilei locale tip
                String tip = tipcmb.Text;

                //stringul de conectare
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=TV;Integrated Security=True");//stringul de conectare
                try
                {
                    using (con)
                    {
                        con.Open();//deschidere conexiune
                        using (SqlCommand command = new SqlCommand("SELECT IdCanal, COUNT(*) AS numar_emisiuni FROM EMISIUNITV " +
                            "WHERE Tip =@Tip " +
                            "GROUP BY IdCanal " +
                            "ORDER BY numar_emisiuni ASC;"
                                    , con))//stringul de query pentru a afisa numarul de emisiuni la fiecare canal in ordine crescatoare
                        {//creare parametri cu text boxurile introduse

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
    }
}
