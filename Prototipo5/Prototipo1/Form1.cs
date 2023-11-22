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
        Thread atender;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false; // Necesario para poder modificar con los threads elementos de los formularios

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Timer_Conectados.Interval = 10000;

            ConectadosGrid.RowHeadersVisible = false;
            ConectadosGrid.ColumnHeadersVisible = false;
            //ConectadosGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //ConectadosGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            ConectadosGrid.RowCount = 20;
            ConectadosGrid.ColumnCount = 1;

            Conectados_Button.Visible = false;  

            //Botones de invitar
           



        }
        int kl = 0;

        private void AtenderServidor()
        {
            while (true)
            {
                // Recibimos mensaje del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string [] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = trozos[1].Split('\0')[0];

                switch (codigo)
                {
                    case 1: // Respuesta al registrar                       
                        if (mensaje == "si")
                        {
                            MessageBox.Show("Se ha registrado correctamente.)");
                        }
                        else if (mensaje == "nono")
                        {
                            MessageBox.Show("Este nombre de usuario ya está en uso.");
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido registrar.");
                        }
                        break;

                    case 2: // Respuesta al LogIn
                        if (mensaje == "si")
                        {
                            MessageBox.Show("Se ha iniciado sesión correctamente.");
                           // kl = 1;
                            IniciarSesion_Button.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido iniciar sesión");
                        }
                        break;

                    case 3: // Respuesta a la Query1
                        MessageBox.Show("El ID de la partida que se jugó con entorno" + BoxID.Text + " es   " + mensaje);//Mensaje
                        break;

                    case 4: // Respuesta Query 2
                        MessageBox.Show("La dificultad de la partida que jugaron es :" + mensaje);//Mensaje
                        break;

                    case 5: 
                        MessageBox.Show("El número de kills que e hicieron en la partida con dificultad" + BoxID.Text + " es :  " + mensaje);//Mensaje
                        break;
                        
                    case -2:
                        if (mensaje != null)
                        {
                            //Partir el mensaje que nos da el servidor y que 



                            string[] info = mensaje.Split('/');

                            for (int i = 0; i < info.Length; i++)
                            {
                                ConectadosGrid.Rows[i].Cells[0].Value = info[i];

                            }

                        }                                                                                                                                                                                            
                        else
                        {
                            MessageBox.Show("El mensaje ha sido no.");
                        }
                        break;

                    case -1:
                        Contlbl.Text = mensaje;
                        break;
                }
            }
        }
        private void Conectar_Button_Click(object sender, EventArgs e)
        {
            IPAddress direc = IPAddress.Parse("192.168.56.101");//posibles IP; 192.168.56.102 || 192.168.56.101
            IPEndPoint ipep = new IPEndPoint(direc, 9060);

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

            //Pongo en marcha el thread que atenderá los mensajes del servidor
            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();           
        }

        private void Desconectar_Button_Click(object sender, EventArgs e)
        {
            // Se terminó el servicio. 
            // Nos desconectamos
            atender.Abort();
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

        private void Registrar_Buttton_Click(object sender, EventArgs e)
        {
            string mensaje = "1/"+usuario.Text+"/"+ contraseña.Text;

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);           
        }
        private void IniciarSesion_Button_Click(object sender, EventArgs e)
        {
            if (kl == 0)
            {
                string mensaje = "2/" + usuario.Text + "/" + contraseña.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        private void Queries_Button_Click(object sender, EventArgs e)//Este código debe acabar siendo eliminado.
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
            if (QueryKills.Checked) //Se pide la dificultad de la partida y se devulve el número de kills
            {
                string mensaje = "5/"+BoxDificultad.Text + "/" ;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            if (QueryID.Checked) //Se pide un entorno y se devuelve el ID de la partida
            {
                string mensaje = "3/"+BoxID.Text + "/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            if (QueryDificultad.Checked) //Se piden dos nombres y una fecha y se devuelve la dificultad de l apartida
            {
                string mensaje = "4/"+BoxNom1.Text + "/" + BoxNom2.Text + "/" + BoxFecha.Text + "/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        private void ConectadosGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Conectados_Button_Click(object sender, EventArgs e)//Este código debe acabar siendo eliminado.
        {

            

            
            //Código que se ejecuta al pulsar el botón de refrecar.
            ConectadosGrid.RowHeadersVisible = false;
            //ConectadosGrid.ColumnHeadersVisible = false;
            //ConectadosGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //ConectadosGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            ConectadosGrid.RowCount = 20;
            ConectadosGrid.ColumnCount = 1;
            
            Timer_Conectados.Start();


            //-----------------------------------------------------------------------
            //Avisar al servidor de que queremos ver las personas que hay conectadas

            string mensaje = "6/conectados";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void Timer_Conectados_Tick(object sender, EventArgs e)
        {
            

        }

        private void Contlbl_Click(object sender, EventArgs e)
        {

        }

        private void BoxID_TextChanged(object sender, EventArgs e)
        {

        }

        private void BoxFecha_TextChanged(object sender, EventArgs e)
        {

        }

        private void Invitar_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
