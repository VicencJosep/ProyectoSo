using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FOSSA_DamasGame
{
    public partial class FormPrincipal : Form
    {
        //Devlaramos los constructores que utilizaremos para poder conectarnos con el servidor
        string nombre;
        string username;
        string Contrincante;
        Socket server;
        Thread atender;
        bool Admin = false;

        ConsultasForm formDeConsultas = new ConsultasForm();

        //Declaramos varios delegates para evitar el cross threading.
        delegate void DelegadoParaEscribirTexto(string text);
        delegate void DelegadoParaDeshabilitarBoton();
        List<FormFichasBlancas> formulariosB = new List<FormFichasBlancas>();
        List<FormFichasNegras> formulariosN = new List<FormFichasNegras>();
        delegate void DelegadoParaEnviarTextoFormulario(string texto, string nombre, int numForm);
        delegate void DelegadoParaEnviarPosicionFormulario(int numForm, int posX, int posY, int TagFicha1, int TagFichaMatada);
        delegate void DelegadoParaConsultar(int consulta, string nombres);
        delegate void DelegadoParaEstadoPartida(int numForm);




        public FormPrincipal()
        {
            InitializeComponent();
        }
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            //ForzarAperturaForm.Visible = true;

            Bitmap fondoForm = new Bitmap("fondoForm1.jpg");
            this.BackgroundImage = fondoForm;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            //this.BackColor = Color.Transparent;

            Estadolbl.Text = "DESCONECTADO";

            //Inicializamos el dataGridView que tendrá la información de las personas conectadas.
            Conectados.RowHeadersVisible = false;
            Conectados.ColumnHeadersVisible = false;
            //Conectados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //Conectados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            Conectados.RowCount = 20;
            Conectados.ColumnCount = 1;
            Conectados.ReadOnly = true;

            //Los botones de aceptar y denegar inicialmente serán no visibles.
            Aceptar_Button.Visible = false;
            Denegar_Button.Visible = false;
        }

        private void AtenderServidor()
        {
            while (true)
            {
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                string[] trozos = mensaje.Split('/');

                int codigo = Convert.ToInt32(trozos[0]);
                mensaje = trozos[2];
                int numForm = Convert.ToInt32(trozos[1]);
                //MessageBox.Show(codigo.ToString());

                switch (codigo)
                {
                    case 1: // Respuesta al registrar

                        string respuesta;
                        if (mensaje == "si")
                        {
                            respuesta = "Se ha registrado correctamente.)";
                        }
                        else if (mensaje == "-1")
                        {
                            respuesta = "Este nombre de usuario ya está en uso.";
                        }
                        else
                        {
                            respuesta = "No se ha podido registrar.";
                        }
                        this.Invoke(new DelegadoParaEscribirTexto(PonRespuesta), new object[] { respuesta });
                        break;

                    case 2: // Respuesta al LogIn
                        string respuesta2;
                        if (mensaje == "si")
                        {
                            respuesta2 = "Se ha iniciado sesión correctamente.";
                            this.username = UsuarioBox.Text;
                            this.Invoke(new DelegadoParaDeshabilitarBoton(DesabilitarIniciarSessionBoton), new object[] { });
                        }
                        else if (mensaje == "YaConectado")
                            respuesta2 = "El usuario ya esta conectado en otro dispositivo";
                        else
                            respuesta2 = "No se ha podido iniciar sesion";
                        this.Invoke(new DelegadoParaEscribirTexto(PonRespuesta), new object[] { respuesta2 });
                        break;

                    case 3: // Respuesta a la Query1
                        this.Invoke(new DelegadoParaConsultar(Consultar), new object[] { 1, mensaje });
                        break;

                    case 4: // Respuesta Query 2

                        this.Invoke(new DelegadoParaConsultar(Consultar), new object[] { 2, mensaje });
                        break;

                    case 5:

                        this.Invoke(new DelegadoParaConsultar(Consultar), new object[] { 3, mensaje });

                        break;
                    case 6:
                        string respuesta6;
                        if (mensaje == "error")
                        {
                            respuesta6 = "usuario no encontrado";
                        }
                        else if (mensaje == "NoPuedesAutoinvitarte")
                        {
                            respuesta6 = "No puedes invitarte a ti mismo, ecoja otro usuario";
                        }
                        else
                        {
                            respuesta6 = "Invitación enviada ";
                        }
                        this.Invoke(new DelegadoParaEscribirTexto(PonRespuesta), new object[] { respuesta6 });
                        break;
                    case 9://Eliminar usuario de la base de datos.

                        if (mensaje == "Eliminado")
                        {
                            MessageBox.Show("Usuario eliminado correctamente");
                        }
                        else
                            MessageBox.Show("El ususario no ha podido ser eliminado");
                        break;
                    case -2:

                        for (int i = 2; i < trozos.Length; i++)
                        {
                            if (trozos[i] == "eliminado")
                                Conectados.Rows[i - 2].Cells[0].Value = null;
                            else
                                Conectados.Rows[i - 2].Cells[0].Value = trozos[i];
                        }
                        break;

                    case -3:
                        string notificacion2;
                        notificacion2 = "-3/" + mensaje + "/le ha invitado a una partida";
                        this.Invoke(new DelegadoParaEscribirTexto(PonNotificacion), new object[] { notificacion2 });
                        this.Contrincante = mensaje;
                        break;
                    case -4:
                        string notificacion3;
                        if (mensaje == "No")
                        {
                            notificacion3 = Contrincante + "ha denegado tu solicitud.";
                            this.Invoke(new DelegadoParaEscribirTexto(PonNotificacion), new object[] { notificacion3 });
                        }
                        else if (mensaje == "Si")
                        {
                            //PonerEnMarchaFormulario();
                            ThreadStart ts = delegate { PonerEnMarchaFormularioBlancas(); };
                            Thread T = new Thread(ts);
                            T.Start();
                        }
                        else
                            MessageBox.Show("Ha habido un error registrando la partida");

                        break;
                    case -5:

                        this.Invoke(new DelegadoParaEnviarTextoFormulario(EnviarTextoAChat), new object[] { mensaje, this.Contrincante, numForm });
                        break;
                    case -6:
                        int posX = Convert.ToInt32(trozos[2]);
                        int posY = Convert.ToInt32(trozos[3]);
                        int TagFicha1 = Convert.ToInt32(trozos[4]);
                        int TagFichaMatada = Convert.ToInt32(trozos[5]);
                        this.Invoke(new DelegadoParaEnviarPosicionFormulario(EnviarInfoAPartida), new object[] { numForm, posX, posY, TagFicha1, TagFichaMatada });
                        break;
                    case -7:
                        this.Invoke(new DelegadoParaEstadoPartida(EnviarEstado),new object[] {numForm});
                        break;
                        

                }
            }
        }

        //Los próximos métodos se usan en los delegates.
        private void PonRespuesta(string respuesta)
        {
            //respuestabl.Text = respuesta;
            MessageBox.Show(respuesta);
        }

        private void PonNotificacion(string notificacion)
        {
            string[] trozos = notificacion.Split('/');
            if (Convert.ToInt32(trozos[0]) == -2)
                MessageBox.Show(trozos[1]);//notificacionlbl.Text = trozos[1];

            else
            {
                MessageBox.Show(trozos[1] + trozos[2]);//InvitacionLbl.Text = trozos[1] + trozos[2];
                Aceptar_Button.Visible = true;
                Denegar_Button.Visible = true;

            }


        }
       
        private void DesabilitarIniciarSessionBoton()
        {
            Iniciar_Button.Enabled = false;
            Iniciar_Button.BackColor = Color.Gray;
        }

        private void EnviarTextoAChat(string texto, string nombre, int numForm)
        {
            if (this.Admin == true)
                formulariosB[numForm].GetMensajeChat(texto, nombre);
            else
                formulariosN[numForm].GetMensajeChat(texto, nombre);
        }

        private void EnviarInfoAPartida(int numForm, int PosNX, int PosNY, int tagFichaN, int tagFichaMatada)
        {
            if (this.Admin == true)
                formulariosB[numForm].GetInfoPartida(PosNX, PosNY, tagFichaN, tagFichaMatada);
            else
                formulariosN[numForm].GetInfoPartida(PosNX, PosNY, tagFichaN, tagFichaMatada);
        }
        private void EnviarEstado(int numForm)
        {
            if (this.Admin == true)
                formulariosB[numForm].GetEstadoPartida();
            else
                formulariosN[numForm].GetEstadoPartida();
        }


        //Código de los métodos para abrir el formulario de las fichas negras y blancas.
        private void PonerEnMarchaFormularioNegras()
        {
            int cont = formulariosN.Count;
            FormFichasNegras f = new FormFichasNegras(cont, server, Contrincante);
            f.GetNomUsuario(username);
            formulariosN.Add(f);
            f.ShowDialog();
        }
        private void PonerEnMarchaFormularioBlancas()
        {
            int cont = formulariosB.Count;
            FormFichasBlancas f = new FormFichasBlancas(cont, server, Contrincante);
            f.GetNomUsuario(username);
            formulariosB.Add(f);
            f.ShowDialog();
        }
        private void Consultar(int consulta, string texto)
        {
            if (consulta == 1)
                formDeConsultas.GetConQuienHeJugado(texto);
            else if (consulta == 2)
                formDeConsultas.GetResultadosMisPartidas(texto);
            else
                formDeConsultas.GetPartidasEnUnPeriodo(texto);
        }


        //Código que se ejecuta al clickar el dataGridView; se envía una invitación a el usuario seleccionado.
        private void Conectados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Admin = true;
            string nom = Conectados.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            string mensaje = "6/0/" + nom + "/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            Contrincante = nom;
        }



        //Primera opción del menu; eliminar usuario de la base de datos
        private void eliminarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                Conectados.Rows[i].Cells[0].Value = null;

            }
            Iniciar_Button.Enabled = true;
            Iniciar_Button.BackColor = Color.White;
            Aceptar_Button.Visible = false;
            Denegar_Button.Visible = false;

            string mensaje = "9/0/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = "3/0/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            if (server != null)
                server.Send(msg);
            else
            {
                MessageBox.Show("Para utilizar los servicios debes conectarte primero al servidor");
            }
            formDeConsultas.ShowDialog();
        }
        private void resultadosDeMisPartidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = "4/0/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            if (server != null)
                server.Send(msg);
            else
            {
                MessageBox.Show("Para utilizar los servicios debes conectarte primero al servidor");
            }
            formDeConsultas.ShowDialog();
        }



        //Los dos próximos botones serán los de registrar e iniciar sesión.
        private void Registrar_Button_Click(object sender, EventArgs e)
        {
            string mensaje = "1/0/" + UsuarioBox.Text + "/" + contraseña.Text;

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            if (server != null)
                server.Send(msg);
            else
            {
                MessageBox.Show("Para utilizar los servicios debes conectarte primero al servidor");
            }
        }

        private void Iniciar_Button_Click(object sender, EventArgs e)
        {
            string mensaje = "2/0/" + UsuarioBox.Text + "/" + contraseña.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            if (server != null)
                server.Send(msg);
            else
            {
                MessageBox.Show("Para utilizar los servicios debes conectarte primero al servidor");
            }
        }


        //Las próximas líneas de código muestran los botones que se usarán para interactuar con el servidor.
        private void Conectar_Button_Click(object sender, EventArgs e)//Botón para conectarse al servidor
        {
            IPAddress direc = IPAddress.Parse("10.4.119.5");//posibles IP; 192.168.56.102 || 192.168.56.101
            IPEndPoint ipep = new IPEndPoint(direc, 50070);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                //this.BackColor = Color.Blue;
                Estadolbl.Text = "CONECTADO";
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

        private void Desconectar_Button_Click(object sender, EventArgs e) //Botón para desconectarse del servidor
        {
            // Se terminó el servicio. 
            // Nos desconectamos
            atender.Abort();
            this.BackColor = Color.Gray;

            string mensaje = "0/0/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            if (server != null)
                server.Send(msg);
            else
            {
                MessageBox.Show("Para utilizar los servicios debes conectarte primero al servidor");
            }

            for (int i = 0; i < 20; i++)
            {
                Conectados.Rows[i].Cells[0].Value = null;

            }
            Iniciar_Button.Enabled = true;
            Iniciar_Button.BackColor = Color.White;
            Aceptar_Button.Visible = false;
            Denegar_Button.Visible = false;
            Estadolbl.Text = "DESCONECTADO";
        }

        private void Denegar_Button_Click(object sender, EventArgs e)
        {
           
            string mensaje = "7/0/No/" + Contrincante + "/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            Aceptar_Button.Visible = false;
            Denegar_Button.Visible = false;

        }

        private void Aceptar_Button_Click(object sender, EventArgs e)
        {
            string mensaje = "7/0/Si/" + Contrincante + "/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            ThreadStart ts = delegate { PonerEnMarchaFormularioNegras(); };
            Thread T = new Thread(ts);
            T.Start();

            Aceptar_Button.Visible = false;
            Denegar_Button.Visible = false;
        }

        private void ForzarAperturaForm_Click(object sender, EventArgs e)
        {
            FormFichasBlancas frm = new FormFichasBlancas(1, server, Contrincante);
            frm.ShowDialog();
        }

        private void consultarPartidaPorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDeConsultas.GetConsultaPorFecha(3);
            formDeConsultas.GetSocket(server);
            formDeConsultas.ShowDialog();
        }

        private void InvitacionLbl_Click(object sender, EventArgs e)
        {

        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            atender.Abort();
           

            string mensaje = "0/0/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            if (server != null)
                server.Send(msg);
            else
            {
                MessageBox.Show("Para utilizar los servicios debes conectarte primero al servidor");
            }

            for (int i = 0; i < 20; i++)
            {
                Conectados.Rows[i].Cells[0].Value = null;

            }
           
        }
    }
}
