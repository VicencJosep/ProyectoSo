using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FOSSA_DamasGame
{
    public partial class ConsultasForm : Form
    {

        delegate void DelegadoParaEscribirEnGrid();
        List<string> noms = new List<string>();
        delegate void DelegadoParaEscribirLabel(string consulta);
        delegate void DelegadoParaEscribirEnGrid2(string texto);

        //Gets i Sets
        public void GetResultadosMisPartidas(string resultado)
        {
            this.Invoke(new DelegadoParaEscribirEnGrid2(EscribirEnGrid), new object[] { resultado });
        }

        public ConsultasForm()
        {
            InitializeComponent();
        }

        private void ConsultasForm_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.ColumnCount = 1;
            dataGridView1.ReadOnly = true;
            dataGridView1.Visible = false;
        }

        public void GetConQuienHeJugado(string nombres)
        {
            this.Invoke(new DelegadoParaEscribirLabel(EscribirEnLabel), new object[] {"Con quién he jugado?" });
            bool encontrado = false;
            noms.Clear();
            string[] nombre = nombres.Split('$');
            for (int i = 0; i < nombre.Length; i++)
            {
                foreach (string s in noms)
                {
                    if (s == nombre[i])
                        encontrado = true;
                }
                if (encontrado == true)
                    encontrado = false;
                else
                {
                    encontrado = false;
                    noms.Add(nombre[i]);
                }

            }
            this.Invoke(new DelegadoParaEscribirEnGrid(EscribirEnList), new object[] { });
        }
        private void EscribirEnList()
        {
            dataGridView1.Visible = true;
            dataGridView1.RowCount = 1;
            foreach (string s in noms)
            {
                if (s != "-2")
                {
                    dataGridView1.Rows.Add(s);
                }

            }
        }
        private void EscribirEnLabel(string texto)
        {
            label1.Text = texto;
        }
        private void EscribirEnGrid(string texto)
        {
            dataGridView1.ColumnHeadersVisible = true;


            dataGridView1.Visible = true;
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].HeaderText = "ID Partida";
            dataGridView1.Columns[1].HeaderText = "Ganador";
            string[] trozos = texto.Split('¡');
            for (int i = 0; i < trozos.Length; i++)
            {
                string[] contenido = trozos[i].Split('$');
                dataGridView1.Rows.Add(contenido[1], contenido[0]);
            }
        }
    }
}
