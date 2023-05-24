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
using System.Windows.Forms.DataVisualization.Charting;

namespace Practica_C_sharp
{
    public partial class chart : Form
    {
        public chart()
        {
            InitializeComponent();
        }

        // Assuming you have already established a connection to your database
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=TV;Integrated Security=True");//stringul de conectare

        private void chart_Load(object sender, EventArgs e)
        {
            // Create a new chart control

            // Set the chart title
            chart1.Titles.Add("Diagrama audienta");

            try
            {
                // Open the database connection
                con.Open();

                // Create a SQL command to retrieve the IdCanal and audienta values from the EMISIUNITV table
                string query = "SELECT IdEmisiune, audienta FROM EMISIUNITV";
                SqlCommand command = new SqlCommand(query, con);

                // Execute the command and retrieve the data
                SqlDataReader reader = command.ExecuteReader();

                // Dictionary to store the cumulative audience for each IdCanal
                Dictionary<int, int> cumulativeAudience = new Dictionary<int, int>();

                // Iterate through the data and calculate the cumulative audience for each IdCanal
                while (reader.Read())
                {
                    int idCanal = Convert.ToInt32(reader["IdEmisiune"]);
                    int audience = Convert.ToInt32(reader["audienta"]);

                    if (cumulativeAudience.ContainsKey(idCanal))
                    {
                        cumulativeAudience[idCanal] += audience;
                    }
                    else
                    {
                        cumulativeAudience[idCanal] = audience;
                    }
                }

                // Close the data reader
                reader.Close();

                // Create a series for the chart
                Series series = new Series("Audienta");
                
                // Add the cumulative audience values to the series
                foreach (KeyValuePair<int, int> item in cumulativeAudience)
                {
                    series.Points.AddXY(item.Key.ToString(), item.Value);
                }

                // Add the series to the chart
                chart1.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the database connection
                con.Close();
            }

            // Create a chart area and add it to the chart
            /*ChartArea chartArea = new ChartArea();
            chart1.ChartAreas.Add(chartArea);
            */
            // Set the chart control's dock property to fill the form
            chart1.Dock = DockStyle.Fill;

            // Add the chart to the form
            Controls.Add(chart1);
        }
    }
}
