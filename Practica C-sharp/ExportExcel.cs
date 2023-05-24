
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Practica_C_sharp
{
    public partial class ExportExcel : Form
    {
        public ExportExcel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))//verifica daca s-au introdus date
            {
                MessageBox.Show("Introduceti inceputul intervalului (**:**) !", "A intervenit o eroare !!! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (String.IsNullOrEmpty(textBox2.Text))//verifica daca s-au introdus date
            {
                MessageBox.Show("Introduceti Sfarsitul intervalului (**:**) !", "A intervenit o eroare !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(tipcmb.Text))//verifica daca s-au introdus date
            {
                MessageBox.Show("Introduceti Tipul Emisiunii!", "A intervenit o eroare !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                //atribuirea variabilelor locale date din textboxuri
                String tip = Convert.ToString(tipcmb.Text);
                //string de conectare
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=TV;Integrated Security=True");//stringul de conectare

                String min = Convert.ToString(textBox1.Text);
                String max = Convert.ToString(textBox2.Text);
                TimeSpan tsmin = TimeSpan.Parse(min);
                TimeSpan tsmax = TimeSpan.Parse(max);
                try
                {
                    using (con)
                    {
                        con.Open();//deschidere conexiune
                        using (SqlCommand command = new SqlCommand("SELECT * FROM EMISIUNITV Where  Tip=@Tip and Ora>=@OraMin and Ora<=@OraMax"
                                                                     , con))//stringul de query pentru afisare a emisiunilor de tipul dorit in intervalul dorit
                        {//creare parametri cu text boxurile introduse


                            command.Parameters.AddWithValue("@Tip", tip);
                            command.Parameters.AddWithValue("@OraMin", tsmin);
                            command.Parameters.AddWithValue("@OraMax", tsmax);
                            SqlDataReader reader = command.ExecuteReader();//executare comanda
                            DataTable dt = new DataTable();//creare tabel de date
                            dt.Load(reader);
                            dataGridView1.DataSource = dt;//afisare
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;//autosize


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

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog(); //obiect de tip saveFile
            saveFileDialog1.InitialDirectory = ("C:\\Users\\user\\OneDrive\\Desktop\\Practica Anul 3\\Raports");//pathul de salvare a file-ului
            saveFileDialog1.Title = "Save as Excel File";//titlul file-ul
            saveFileDialog1.FileName = "ExportExcel";//numele 
            saveFileDialog1.Filter = "Excel Files(2003)|*.xls| Excel Files(2007)|*.xlsx";//extensia de tip excel

            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)//verifica daca nu a fost inchis
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();//obiect excel
                ExcelApp.Application.Workbooks.Add(Type.Missing);
                ExcelApp.Columns.AutoFit();//coloanele se genereaza
                Microsoft.Office.Interop.Excel.Worksheet sheet = ExcelApp.ActiveSheet;//creeaza o foaie
                for (int i = 0; i < dataGridView1.Columns.Count; i++)//transfera datele din datagridview in tabela din excel
                {
                    sheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;//adaugare header
                }

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        sheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();//adaugare valorile
                    }

                }
                MessageBox.Show("Datele au fost Exportate cu succes!!!");
                sheet.SaveAs(saveFileDialog1.FileName);//se salveaza
                ExcelApp.Visible = true;//se deschide
                ExcelApp.Quit();//se inchide

            }
        }
    
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
    saveFileDialog1.InitialDirectory = "C:\\Users\\user\\OneDrive\\Desktop\\Practica Anul 3\\Raports";
    saveFileDialog1.Title = "Save as Word File";
    saveFileDialog1.FileName = "ExportWord";
    saveFileDialog1.Filter = "Word Documents|*.docx";

    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
    {
        Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
        Microsoft.Office.Interop.Word.Document wordDoc = wordApp.Documents.Add();
        wordApp.Visible = true;

        // Add a table to the Word document
        Microsoft.Office.Interop.Word.Table table = wordDoc.Tables.Add(wordDoc.Range(), dataGridView1.Rows.Count + 1, dataGridView1.Columns.Count);

        // Set table properties
        table.Borders.Enable = 1;
        table.AllowAutoFit = true;

        // Add headers to the table
        for (int c = 0; c < dataGridView1.Columns.Count; c++)
        {
            table.Cell(1, c + 1).Range.Text = dataGridView1.Columns[c].HeaderText;
            table.Cell(1, c + 1).Range.Bold = 1;
        }

        // Add data to the table
        for (int r = 0; r < dataGridView1.Rows.Count; r++)
        {
            for (int c = 0; c < dataGridView1.Columns.Count; c++)
            {
                object value = dataGridView1.Rows[r].Cells[c].Value;
                table.Cell(r + 2, c + 1).Range.Text = value != null ? value.ToString() : string.Empty;
            }
        }

        // Save the Word document
        wordDoc.SaveAs2(saveFileDialog1.FileName);
        wordDoc.Close();
        wordApp.Quit();

                    MessageBox.Show("Datele au fost exportate cu succes!");
                    this.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare " + ex.Message);//in caz de eroare se afiseeaza message box
            }
        }
    }

        
    }
