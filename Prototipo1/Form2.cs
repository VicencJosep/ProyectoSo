using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototipo1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

          
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Queries.RowCount = 5;
            Queries.ColumnCount = 5;


        }
    }
}
