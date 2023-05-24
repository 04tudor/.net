using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_C_sharp.SarciniSuplimentare
{
    public partial class raport : Form
    {
        public raport()
        {
            InitializeComponent();
        }

        private void raport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tVDataSet.CANALTV' table. You can move, or remove it, as needed.
            this.cANALTVTableAdapter.Fill(this.tVDataSet.CANALTV);

            this.reportViewer1.RefreshReport();
        }
    }
}
