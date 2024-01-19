using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace FOSSA_DamasGame
{
    public partial class ConsultasForm : Form
    {
        Socket server;

        delegate void DelegadoParaEscribirEnGrid();
        List<string> noms = new List<string>();
        delegate void DelegadoParaEscribirLabel(string consulta);
        delegate void DelegadoParaEscribirEnGrid2(string texto);
        int consulta=0;

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
            if (consulta == 0)
            {
                Fecha1Box.Visible = false;
                Fecha2Box.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                ConsultarBtn.Visible = false;
            }
        }
        public void GetSocket(Socket server)
        {
            this.server = server;
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
        public void GetConsultaPorFecha(int consulta)
        {
            this.consulta = consulta;
            Fecha1Box.Visible = true;
            Fecha2Box.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            ConsultarBtn.Visible = true;
            label1.Text = "Indique el periodo en el que desea ver las partidas realizadas.";
        }
        public void GetPartidasEnUnPeriodo(string texto)
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.ColumnCount = 1;
            dataGridView1.ReadOnly = true;
            dataGridView1.Visible = false;
            if (texto == "Err")
                MessageBox.Show("No hay partidas registradas en ese periodo");
            string[] Partidas = texto.Split('$');
            for (int i = 0; i < Partidas.Length; i++)
            {
                dataGridView1.Rows.Add(Partidas[i]);
            }
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ConsultarBtn_Click(object sender, EventArgs e)
        {
            string mensaje = "5/0/" + Fecha1Box.Text + "/" + Fecha2Box.Text + "/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            if (server != null)
                server.Send(msg);
            else
            {
                MessageBox.Show("Para utilizar los servicios debes conectarte primero al servidor");
            }
        }
    }
}
