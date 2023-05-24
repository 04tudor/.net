﻿using System;
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
    public partial class NumarEmisiuniCanal : Form
    {
        public NumarEmisiuniCanal()
        {
            InitializeComponent();
        }

        private void NumarEmisiuniCanal_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=TV;Integrated Security=True");//stringul de conectare
            try
            {
                using (con)
                {
                    con.Open();//deschidere conexiune
                    using (SqlCommand command = new SqlCommand("EXEC NumarEmisiuniCanalTV"
                                , con))//stringul de query pentru update
                    {//creare parametri cu text boxurile introduse

                        SqlDataReader reader = command.ExecuteReader();//executare comanda
                        DataTable dt = new DataTable();//creare tabel de date
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;//afisare
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;//autosize

                        con.Close();//inchidere conexiune

                    }
                }

                con.Close();//inchidere conexiune
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare " + ex.Message);//in caz de eroare se afiseeaza message box
            }
        }
    }
}
