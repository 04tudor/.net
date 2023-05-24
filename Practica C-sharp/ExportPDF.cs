using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using DataTable = System.Data.DataTable;

namespace Practica_C_sharp
{
    public partial class ExportPDF : Form
    {
        public ExportPDF()
        {
            InitializeComponent();
        }

        private void ExportPDF_Load(object sender, EventArgs e)
        {
            label5.Show();
            pictureBox7.Show();
            string con = "Data Source=.;Initial Catalog=TV;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                List<string> tableNames = GetTableNames(connection);

                foreach (string tableName in tableNames)
                {
                    DataTable dataTable = GetDataFromTable(tableName, connection);
                    ExportDataTableToPDF(dataTable, $"{tableName}.pdf");
                }
            }

            MessageBox.Show("Export completed.");
        }

        private List<string> GetTableNames(SqlConnection connection)
        {
            List<string> tableNames = new List<string>();
            DataTable schema = connection.GetSchema("Tables");

            foreach (DataRow row in schema.Rows)
            {
                string tableName = row["TABLE_NAME"].ToString();
                tableNames.Add(tableName);
            }

            return tableNames;
        }

        private DataTable GetDataFromTable(string tableName, SqlConnection connection)
        {
            string query = $"SELECT * FROM {tableName}";

            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        private void ExportDataTableToPDF(DataTable dataTable, string fileName)
        {
            string folderPath = @"C:\Users\user\OneDrive\Desktop\Practica Anul 3\Raports";
            Directory.CreateDirectory(folderPath); // Create the folder if it doesn't exist

            string filePath = Path.Combine(folderPath, fileName);

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                PdfWriter writer = new PdfWriter(stream);
                PdfDocument pdfDoc = new PdfDocument(writer);
                Document document = new Document(pdfDoc);

                // Create table
                iText.Layout.Element.Table table = new iText.Layout.Element.Table(dataTable.Columns.Count);

                // Set font for table cells
                PdfFont font = PdfFontFactory.CreateFont("Helvetica");
                Cell headerCell;
                Cell cell;
                foreach (DataColumn column in dataTable.Columns)
                {
                    headerCell = new Cell().Add(new Paragraph(column.ColumnName));
                    headerCell.SetFont(font);
                    table.AddHeaderCell(headerCell);
                }

                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (object item in row.ItemArray)
                    {
                        cell = new Cell().Add(new Paragraph(item.ToString()));
                        cell.SetFont(font);
                        table.AddCell(cell);
                    }
                }

                document.Add(table);
                document.Close();
            }
        }
    }
}
