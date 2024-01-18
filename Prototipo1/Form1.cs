using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Prototipo1
{
    public partial class Form1 : Form
    {
        Socket server;
        List<string> conectados = new List<string>();
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Timer_Conectados.Interval = 1000;

        }

        private void Conectar_Button_Click(object sender, EventArgs e)
        {
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9070);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try 
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Blue;
            }
            catch (SocketException) 
            {
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
          

        }

        private void Desconectar_Button_Click(object sender, EventArgs e)
        {
            // Se terminó el servicio. 
            // Nos desconectamos
            this.BackColor = Color.Gray;
            //string mensaje = "0/";
            //byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            //server.Send(msg);
            server.Shutdown(SocketShutdown.Both);
        }

        private void Registrar_Buttton_Click(object sender, EventArgs e)
        {
            string mensaje = "1/"+usuario.Text+"/"+ contraseña.Text;

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //El Servidor responde
            
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];



            if (mensaje == "si")
            {
                MessageBox.Show("Se ha registrado correctamente.)");
            }
            else
            {
                MessageBox.Show("No se ha podido registrar.");
            }
        }



        private void IniciarSesion_Button_Click(object sender, EventArgs e)
        {
            string mensaje = "2/" + usuario.Text + "/" + contraseña.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
           
            //El Servidor responde
            
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
           
            
            if (mensaje=="si")
            {
                MessageBox.Show("Se ha iniciado sesión correctamente.");
            }
            else 
            {
                MessageBox.Show("No se ha podido iniciar sesión");
            }
        }

        private void Queries_Button_Click(object sender, EventArgs e)
        {
           // Form2.OpenDialog(); No se usa en la versión actual
        }

        private void nombres_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Dificultad_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Enviar_Click(object sender, EventArgs e)
        {
            if (Dificultad.Checked) //Se pide la dificultad de la partida y se devulve el número de kills
            {
                string mensaje = "5/"+QueriesText.Text + "/" ;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                int respuesta = Convert.ToInt32(mensaje);
                if (respuesta != -2)
                {
                    MessageBox.Show("El número de kills que e hicieron en la partida con dificultad " + QueriesText.Text + " es :  " + mensaje);//Mensaje
                }
                else
                    MessageBox.Show("No se han obtenido resultados de la consulta");
               


            }
            if (Entorno.Checked) //Se pide un entorno y se devuelve el ID de la partida
            {
                string mensaje = "3/"+QueriesText.Text + "/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                int respuesta = Convert.ToInt32(mensaje);
                if (respuesta != -2)
                {
                    MessageBox.Show("El ID de la partida que se jugó con entorno" + QueriesText.Text + " es   " + mensaje);//Mensaje
                }
                else
                    MessageBox.Show("No se han obtenido resultados de la consulta");

            }
            if (nombres.Checked) //Se piden dos nombres y una fecha y se devuelve la dificultad de l apartida
            {
                string mensaje = "4/"+QueriesText.Text + "/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                int respuesta = Convert.ToInt32(mensaje);
                if (respuesta != -2)
                {
                    MessageBox.Show("La dificultad de la partida que jugaron es :" + mensaje);//Mensaje
                }
                else
                    MessageBox.Show("No se han obtenido resultados de la consulta");
            }
        }

        private void ConectadosGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Conectados_Button_Click(object sender, EventArgs e)
        {
            ConectadosGrid.RowCount = 5;
            ConectadosGrid.ColumnCount = 1;
            
            Timer_Conectados.Start();    
            

            


        }

        private void Timer_Conectados_Tick(object sender, EventArgs e)
        {
            //Avisar al servidor de que queremos ver las personas que hay conectadas

            string mensaje = "7/conectados";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

        }

        
    }
}
