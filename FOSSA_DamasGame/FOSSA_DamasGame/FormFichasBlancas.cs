using System;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;

namespace FOSSA_DamasGame
{
    public partial class FormFichasBlancas : Form
    {
        //Delegate para evitar el cross threading
        delegate void DelegadoParaEscribirEnChat(string texto, string nombre);
        delegate void DelegadoParaActualizarPosicion(int PosNX, int PosNY, int tagFichaN, int tagFichaMatada);

        //Declaramos los dos picture box que vamos a usar.
        PictureBox[] aircraft_vector;
        PictureBox[] PuntoAzul;

        //Variables globales usadas para controlar la posición de las fichas
        
        int i_global = 0;
        int contadorComerFicha = 0;
        int[] posición_ficha = new int[2];
        int[] posición_pictureBox = new int[2];
        int cont = 0;//Contador del número de kills que ha hecho el usuario que ha ganado la partida.
        int cont2 = 0;//Contador del num de kills que ha hecho el perdedor de la partida. 
        
        bool turno = true;

        //Medidas del tablero
        int medidaX = 493;
        int medidaY = 450;

        //Constructores para el correcto intercambio de información con el servidor.
        int nForm;
        Socket server;
        string Contrincante;
        string username;

        //Sets i Gets
        public void GetNomUsuario(string nombre)
        {
            this.username = nombre;
            this.Text = "Sala " + nForm.ToString() + " Usuario: " + this.username;
        }
        public void GetMensajeChat(string texto, string contrincante)
        {
            try { this.Invoke(new DelegadoParaEscribirEnChat(EscribirEnChat), new object[] { contrincante, texto }); }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Tu contrincante se ha desconectado");
                this.Close();
            }
            

        }
        public void GetInfoPartida(int PosNX, int PosNY, int tagFichaN, int tagFichaMatada)
        {
            try { this.Invoke(new DelegadoParaActualizarPosicion(CambiarPosición), new object[] { PosNX,PosNY,tagFichaN,tagFichaMatada }); }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Tu contrincante se ha desconectado");
                this.Close();
            }
        }


        public FormFichasBlancas(int nForm, Socket server, string Contrincante)
        {
            InitializeComponent();
            this.nForm = nForm;
            this.server = server;
            this.Contrincante = Contrincante;
        }


        private void FormFichasBlancas_Load(object sender, EventArgs e)
        {
            button1.Visible = false;

            //Cartel que indica el turno
            Bitmap ImgTurno = new Bitmap("fondotablero.png");
            Turnolbl.Size = new Size(130, 130);
            Turnolbl.BackgroundImage = ImgTurno;
            if (turno == true)
            { Turnolbl.Text = "Turno: Blancas"; Turnolbl.ForeColor = Color.AliceBlue; }
            else
            {
                Turnolbl.Text = "Turno : Negras"; Turnolbl.ForeColor = Color.DarkSlateGray;
            }

            

            Bitmap BckgndImage = new Bitmap("TableroBlancasSinFondo.png");
            Tablero.Size = new System.Drawing.Size(834, 572);//Size(834, 572);(577,432)
            Tablero.BackgroundImage = BckgndImage;
            Tablero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

           

            PuntoAzul = new PictureBox[2];
            PuntoAzul[0] = new PictureBox();
            PuntoAzul[1] = new PictureBox();

            aircraft_vector = new PictureBox[24];

            int x;
            int y;

            int j = 0; int k = 0; int jj = 1;

            int contadorfila8 = 0, contadorfila6 = 0, contadorfila7 = 0;//contadores fichas blancas
            int contadorfila1 = 0, contadorfila2 = 0; // contadores filas negras

            bool fichablanca = true;

            for (int i = 0; i < 24; i++) // Inicializar los PictureBox del vector
            {

                //Inicializamos las fichas blancas en el tablero en su posición correspondiente
                if (fichablanca == true)
                {
                    if ((i % 2 == 0) && ((contadorfila8 < 4)))//fila8(blancas)
                    {

                        aircraft_vector[i] = new PictureBox();
                        aircraft_vector[i].ClientSize = new Size(50, 50); // Establecer el tamaño del PictureBox del vuelo

                        x = 168 + 61 * i;//fichas blancas solo cuando i es impar
                        y = 504 - 56;

                        aircraft_vector[i].Location = new Point(x, y); // Establecer la posición del PictureBox de la dama en x,y
                        aircraft_vector[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        Bitmap image = new Bitmap("fichablanca.png");
                        aircraft_vector[i].Image = (Image)image;
                        aircraft_vector[i].BackColor = Color.Transparent; // Establecer el fondo transparente del PictureBox
                        Tablero.Controls.Add(aircraft_vector[i]); // Agregar el PictureBox al panel


                        contadorfila8++;
                    }
                    else if (((contadorfila8 == 4) && (i % 2 == 0)) || contadorfila7 >= 4)//fila6 (blancas)
                    {


                        aircraft_vector[i] = new PictureBox();
                        aircraft_vector[i].ClientSize = new Size(50, 50); // Establecer el tamaño del PictureBox del vuelo

                        x = 168 + 61 * 2 * j;//fichas blancas solo cuando i es impar
                        y = 504 - 3 * 56;

                        aircraft_vector[i].Location = new Point(x, y); // Establecer la posición del PictureBox de la dama en x,y
                        aircraft_vector[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        Bitmap image = new Bitmap("fichablanca.png");
                        aircraft_vector[i].Image = (Image)image;
                        aircraft_vector[i].BackColor = Color.Transparent; // Establecer el fondo transparente del PictureBox
                        Tablero.Controls.Add(aircraft_vector[i]); // Agregar el PictureBox al panel

                        j++;
                        contadorfila6++;
                    }
                    else if ((contadorfila7 < 4) && (i % 2 != 0))//fila7 (fichas blancas)
                    {

                        aircraft_vector[i] = new PictureBox();
                        aircraft_vector[i].ClientSize = new Size(50, 50); // Establecer el tamaño del PictureBox del vuelo

                        x = 168 + 61 * i;//fichas blancas solo cuando i es impar
                        y = 504 - 2 * 56;

                        aircraft_vector[i].Location = new Point(x, y); // Establecer la posición del PictureBox de la dama en x,y
                        aircraft_vector[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        Bitmap image = new Bitmap("fichablanca.png");
                        aircraft_vector[i].Image = (Image)image;
                        aircraft_vector[i].BackColor = Color.Transparent; // Establecer el fondo transparente del PictureBox
                        Tablero.Controls.Add(aircraft_vector[i]); // Agregar el PictureBox al panel  

                        contadorfila7++;

                    }


                    if ((contadorfila6 == 4) && (contadorfila8 == 4) && (contadorfila7 == 4)) //Cuando ya están colocadas las 12 fichas blancas empezamos el bucle de las fichas negras
                    {
                        fichablanca = false;
                    }

                }

                else //Colocamos las fichas negras en el tablero
                {
                    ; k = i - 12;

                    //Inicializamos las fichas negras en el tablero en su posición correspondiente
                    if ((i % 2 != 0) && (contadorfila1 < 4)) //fila 1
                    {

                        aircraft_vector[i] = new PictureBox();
                        aircraft_vector[i].ClientSize = new Size(50, 50); // Establecer el tamaño del PictureBox del vuelo

                        x = 168 + 61 * k;//fichas blancas solo cuando i es impar
                        y = 54;

                        aircraft_vector[i].Location = new Point(x, y); // Establecer la posición del PictureBox de la dama en x,y
                        aircraft_vector[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        Bitmap image = new Bitmap("fichasnegras.png");
                        aircraft_vector[i].Image = (Image)image;
                        aircraft_vector[i].BackColor = Color.Transparent; // Establecer el fondo transparente del PictureBox
                        Tablero.Controls.Add(aircraft_vector[i]); // Agregar el PictureBox al panel

                        contadorfila1++;

                    }
                    else if (((contadorfila1 == 4) && (i % 2 == 0)) || (contadorfila1 >= 4))//fila 3
                    {


                        aircraft_vector[i] = new PictureBox();
                        aircraft_vector[i].ClientSize = new Size(50, 50); // Establecer el tamaño del PictureBox del vuelo

                        x = 168 + 61 * jj;//fichas blancas solo cuando i es impar
                        y = 3 * 56;

                        aircraft_vector[i].Location = new Point(x, y); // Establecer la posición del PictureBox de la dama en x,y
                        aircraft_vector[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        Bitmap image = new Bitmap("fichasnegras.png");
                        aircraft_vector[i].Image = (Image)image;
                        aircraft_vector[i].BackColor = Color.Transparent; // Establecer el fondo transparente del PictureBox
                        Tablero.Controls.Add(aircraft_vector[i]); // Agregar el PictureBox al panel


                        jj = jj + 2;

                    }

                    else if ((contadorfila2 < 4) && (i % 2 == 0)) //fila 2
                    {


                        aircraft_vector[i] = new PictureBox();
                        aircraft_vector[i].ClientSize = new Size(50, 50); // Establecer el tamaño del PictureBox del vuelo

                        x = 168 + 61 * k;//fichas blancas solo cuando i es impar
                        y = 2 * 54;

                        aircraft_vector[i].Location = new Point(x, y); // Establecer la posición del PictureBox de la dama en x,y
                        aircraft_vector[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        Bitmap image = new Bitmap("fichasnegras.png");
                        aircraft_vector[i].Image = (Image)image;
                        aircraft_vector[i].BackColor = Color.Transparent; // Establecer el fondo transparente del PictureBox
                        Tablero.Controls.Add(aircraft_vector[i]); // Agregar el PictureBox al panel

                        contadorfila2++;
                    }



                }
                aircraft_vector[i].MouseMove += new System.Windows.Forms.MouseEventHandler(this.aircraft_MouseMove);
                aircraft_vector[i].Tag = i; // Asignar un valor de etiqueta al PictureBox para identificar el vuelo
                aircraft_vector[i].Click += new System.EventHandler(this.aircraft_Click); // Asociar el evento de click al PictureBox del vuelo
                aircraft_vector[i].LocationChanged += new System.EventHandler(this.aircraft_LocationChanged);
            }


        }


        //Los tres siguienetes métodos hacen referencia a los eventos de la los Picture Box de las fichas
        private void aircraft_MouseMove(object sender, MouseEventArgs e)
        {

            MouseMoveLabel2.Text = e.X.ToString() + "," + e.Y.ToString();
            posición_pictureBox[0] = e.X;
            posición_pictureBox[1] = e.Y;

           


        }
        private void aircraft_Click(object sender, EventArgs e) // código que se ejecuta al hacer click en un avión
        {
            
            PictureBox p = (PictureBox)sender; // Obtener el PictureBox que generó el evento
            int i = (int)p.Tag; // Obtener el valor de etiqueta del PictureBox para identificar el vuelo correspondiente 
            //MessageBox.Show(i.ToString());            
            aircraft_vector[i_global].BackColor = Color.Transparent;
            aircraft_vector[i].BackColor = Color.AliceBlue;
            i_global = i;

            //posición_ficha = CentrarImagen(posición_ficha[0], posición_ficha[1]);
            //CalcularMovPosibles(posición_ficha[0], posición_ficha[1]);



        }
        private void aircraft_LocationChanged(object sender, EventArgs e)
        {

            aircraft_vector[i_global].BackColor = Color.Transparent;


        }



        //Métodos relacionados a los eventos del Panel "Tablero".   
        private void Tablero_MouseMove(object sender, MouseEventArgs e)
        {
            posición_pictureBox[0] = 0;
            posición_pictureBox[1] = 0;
            MouseMoveLable.Text = e.X.ToString() + "," + e.Y.ToString();
            posición_ficha[0] = e.X + posición_pictureBox[0];
            posición_ficha[1] = e.Y + posición_pictureBox[1];

            
        }

        private void Tablero_Click(object sender, EventArgs e)//Es lo mismo que MouseClick?
        {

        }

        private void Tablero_MouseClick(object sender, MouseEventArgs e)
        {
            

            if (turno == true) 
            {
                int res = BuscarFicha(aircraft_vector[i_global].Location.X + 31, aircraft_vector[i_global].Location.Y + 28);

                if ((res!=-1)&&(Math.Abs(e.X - aircraft_vector[res].Location.X) > 100))
                {
                    contadorComerFicha = 1;
                    res = BuscarFicha(aircraft_vector[i_global].Location.X + 31, aircraft_vector[i_global].Location.Y + 28);

                } 

               

                if ((res != -1) && (aircraft_vector[i_global].Location.Y > e.Y)  && (Math.Abs(aircraft_vector[i_global].Location.Y-e.Y)>56) && (Math.Abs(aircraft_vector[i_global].Location.Y - e.Y) <2*56) && (((Math.Abs(aircraft_vector[i_global].Location.X - e.X) > 2 * 61 + 5) && (Math.Abs(aircraft_vector[i_global].Location.X - e.X) < 3 * 61) && ((aircraft_vector[i_global].Location.X-e.X)<0)) || ((e.X - aircraft_vector[i_global].Location.X) < 0) && (Math.Abs(aircraft_vector[i_global].Location.X-e.X)>65)&&(Math.Abs(aircraft_vector[i_global].Location.X - e.X) < 120) ))
                {
                    Tablero.Controls.Remove(aircraft_vector[res]);
                    this.cont++;
                    posición_ficha = CentrarImagen(e.X, e.Y);
                    aircraft_vector[i_global].Location = new Point(posición_ficha[0] - 31, posición_ficha[1] - 28);
                    turno = false;
                    bool ganador = BuscarGanador(posición_ficha[1]);
                    if (ganador)
                    { 

                        MessageBox.Show("Enorabuena, has ganado la partida!");

                        string mensaje = "11/" + nForm.ToString() + "/" + Contrincante + "/" + this.cont + "/" + this.cont2 +"/";
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);

                        if (server != null)
                        {
                            server.Send(msg);
                        }
                        
                        else
                        {
                            MessageBox.Show("Para utilizar los servicios debes conectarte primero al servidor");
                        }
                        
                        this.Close();
                    }
                    


                    if (server != null)
                    {
                        //Le enviamos al servidor la posición a la que hemos movido la ficha.
                        string mensaje = "10/" + nForm.ToString() + "/" + Contrincante + "/" + (posición_ficha[0] - 31).ToString() + "/" + (posición_ficha[1] - 28).ToString() + "/" + (aircraft_vector[i_global].Tag).ToString() + "/" + res;
                        textBox1.Text = " ";
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                    else
                    {
                        MessageBox.Show("Para utilizar los servicios debes conectarte primero al servidor");
                    }
                }
                else if ((aircraft_vector[i_global].Location.Y < e.Y) || ((Math.Abs(aircraft_vector[i_global].Location.X + 31 - e.X) < 31) || (Math.Abs(aircraft_vector[i_global].Location.X + 31 - e.X) > 79)) || (Math.Abs(aircraft_vector[i_global].Location.Y - e.Y) > 32))
                {
                    MessageBox.Show("Sólo se puede mover en diagonal y hacia delante.");
                }
                else 
                {
                    posición_ficha = CentrarImagen(e.X, e.Y);
                    aircraft_vector[i_global].Location = new Point(posición_ficha[0] - 31, posición_ficha[1] - 28);
                    turno = false;
                    bool ganador = BuscarGanador(posición_ficha[1]);
                    if (ganador)
                    {
                        MessageBox.Show("Enorabuena, has ganado la partida!");
                        string mensaje = "11/" + nForm.ToString() + "/" + Contrincante + "/" + this.cont + "/" + this.cont2 + "/";
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);

                        if (server != null)
                        {
                            server.Send(msg);
                        }

                        else
                        {
                            MessageBox.Show("Para utilizar los servicios debes conectarte primero al servidor");
                        }
                        this.Close();
                    }

                    if (server != null)
                    {
                        //Le enviamos al servidor la posición a la que hemos movido la ficha.
                        string mensaje = "10/" + nForm.ToString() + "/" + Contrincante + "/" + (posición_ficha[0] - 31).ToString() + "/" + (posición_ficha[1] - 28).ToString() + "/" + (aircraft_vector[i_global].Tag).ToString() + "/" + res;
                        textBox1.Text = " ";
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                    else
                    {
                        MessageBox.Show("Para utilizar los servicios debes conectarte primero al servidor");
                    }
                }
               
            }
            if (turno == true)
            { Turnolbl.Text = "Turno: Blancas"; Turnolbl.ForeColor = Color.AliceBlue; }
            else
            {
                Turnolbl.Text = "Turno : Negras"; Turnolbl.ForeColor = Color.DarkSlateGray;
            }

        }


        //Funciones auxiliares útiles para el juego.
        private int BuscarFicha(int x, int y)//Recibimos como input la posición de la ficha blanca que vamos a mover
        {
            //Si nos devuelve true es que hay una ficha en la casilla a la que nos vamos a mover, si nos deveulve false es que no hay ningúna ficha en la casilla a la que vamos a mover.
            //Le restamos 61 a la componente x y la restamos 56 a la componente y
            int x1 = x - 61;
            y = y - 56;
            int x2 = x + 61;
            Point p = new Point(x, y);
            int tag = 0;
            int i = 0;
            bool encontrado = false;
            while ((i < 24) && (encontrado == false))
            {
                tag = Convert.ToInt32(aircraft_vector[i].Tag);
                if ((((aircraft_vector[i].Location.X  + 61 > x2) && (aircraft_vector[i].Location.X < x2) && (aircraft_vector[i].Location.Y + 56 > y) && (aircraft_vector[i].Location.Y < y)) && (tag > 11)) || ((((aircraft_vector[i].Location.X + 61 > x1) && (aircraft_vector[i].Location.X < x1) && (aircraft_vector[i].Location.Y + 56 > y) && (aircraft_vector[i].Location.Y < y)) && (tag > 11))))
                {
                    
                    encontrado = true;
                    if (contadorComerFicha == 1)
                    {
                        encontrado = false;
                        this.contadorComerFicha = 0;
                    }

                }//Hay una ficha negra en la casilla donde hemos clickado
                if (!encontrado)
                    i++;
            }
            if (encontrado == false)
            {
                return -1;
            }
            else
            {
                return tag;
            }
        }



        private void CalcularMovPosibles(int x, int y)//Las varibles de esta función serán las coordenadas de la ficha que queremos mover y la salida nos mostrará los moviminetos legasles que puede hacer nuestra ficha
        {



            PuntoAzul[0].ClientSize = new Size(25, 25); // Establecer el tamaño del PictureBox del vuelo
            PuntoAzul[0].Location = new Point(x + 62, y - 58); // Establecer la posición del PictureBox de la dama en x,y
            PuntoAzul[0].SizeMode = PictureBoxSizeMode.StretchImage;
            Bitmap image = new Bitmap("PuntoAzul.png");
            PuntoAzul[0].Image = (Image)image;
            PuntoAzul[0].BackColor = Color.Transparent; // Establecer el fondo transparente del PictureBox
            Tablero.Controls.Add(PuntoAzul[0]); // Agregar el PictureBox al panel

            PuntoAzul[1].ClientSize = new Size(25, 25); // Establecer el tamaño del PictureBox del vuelo
            PuntoAzul[1].Location = new Point(x - 62, y - 58); // Establecer la posición del PictureBox de la dama en x,y
            PuntoAzul[1].SizeMode = PictureBoxSizeMode.StretchImage;

            PuntoAzul[1].Image = (Image)image;
            PuntoAzul[1].BackColor = Color.Transparent; // Establecer el fondo transparente del PictureBox
            Tablero.Controls.Add(PuntoAzul[1]); // Agregar el PictureBox al panel


        }
        private int[] ReUbicarFicha(int PosNX, int PosNY, int tagFichaN, int tagFichaMatada)//Con esta función reinterpretamos los datos que nos llegan del servidor.
        {
            int[] vector_salida = new int[4];
            //vector_salida[0] Tag de la ficha que hemos movido
            //vector_salida[1] Tag de la ficha que nos hemos comido
            //vector_salida[2] Posición X cambiada
            //vector_salida[3]


            if (tagFichaN == 0)
            { vector_salida[0] = 19; }
            if (tagFichaN == 1)
            { vector_salida[0] = 18; }
            if (tagFichaN == 2)
            { vector_salida[0] = 17; }
            if (tagFichaN == 3)
            { vector_salida[0] = 16; }
            if (tagFichaN == 4)
            { vector_salida[0] = 15; }
            if (tagFichaN == 5)
            { vector_salida[0] = 14; }
            if (tagFichaN == 6)
            { vector_salida[0] = 13; }
            if (tagFichaN == 7)
            { vector_salida[0] = 12; }
            if (tagFichaN == 8)
            { vector_salida[0] = 23; }
            if (tagFichaN == 9)
            { vector_salida[0] = 22; }
            if (tagFichaN == 10)
            { vector_salida[0] = 21; }
            if (tagFichaN == 11)
            { vector_salida[0] = 20; }

            //--------------
            if (tagFichaN == 12)
            { vector_salida[0] = 7; }
            if (tagFichaN == 13)
            { vector_salida[0] = 6; }
            if (tagFichaN == 14)
            { vector_salida[0] = 5; }
            if (tagFichaN == 15)
            { vector_salida[0] = 4; }
            if (tagFichaN == 16)
            { vector_salida[0] = 3; }
            if (tagFichaN == 17)
            { vector_salida[0] = 2; }
            if (tagFichaN == 18)
            { vector_salida[0] = 1; }
            if (tagFichaN == 19)
            { vector_salida[0] = 0; }
            if (tagFichaN == 20)
            { vector_salida[0] = 11; }
            if (tagFichaN == 21)
            { vector_salida[0] = 10; }
            if (tagFichaN == 22)
            { vector_salida[0] = 9; }


            //------------------------------------------
            if (tagFichaMatada == -1)
            { vector_salida[1] = -1; }
            if (tagFichaMatada == 0)
            { vector_salida[1] = 19; }
            if (tagFichaMatada == 1)
            { vector_salida[1] = 18; }
            if (tagFichaMatada == 2)
            { vector_salida[1] = 17; }
            if (tagFichaMatada == 3)
            { vector_salida[1] = 16; }
            if (tagFichaMatada == 4)
            { vector_salida[1] = 15; }
            if (tagFichaMatada == 5)
            { vector_salida[1] = 14; }
            if (tagFichaMatada == 6)
            { vector_salida[1] = 13; }
            if (tagFichaMatada == 7)
            { vector_salida[1] = 12; }
            if (tagFichaMatada == 8)
            { vector_salida[1] = 23; }
            if (tagFichaMatada == 9)
            { vector_salida[1] = 22; }
            if (tagFichaMatada == 10)
            { vector_salida[1] = 21; }
            if (tagFichaMatada == 11)
            { vector_salida[1] = 20; }

            //--------------
            if (tagFichaMatada == 12)
            { vector_salida[1] = 7; }
            if (tagFichaMatada == 13)
            { vector_salida[1] = 6; }
            if (tagFichaMatada == 14)
            { vector_salida[1] = 5; }
            if (tagFichaMatada == 15)
            { vector_salida[1] = 4; }
            if (tagFichaMatada == 16)
            { vector_salida[1] = 3; }
            if (tagFichaMatada == 17)
            { vector_salida[1] = 2; }
            if (tagFichaMatada == 18)
            { vector_salida[1] = 1; }
            if (tagFichaMatada == 19)
            { vector_salida[1] = 0; }
            if (tagFichaMatada == 20)
            { vector_salida[1] = 11; }
            if (tagFichaMatada == 21)
            { vector_salida[1] = 10; }
            if (tagFichaMatada == 22)
            { vector_salida[1] = 9; }

            vector_salida[2] = 493 - PosNX + 168 + 2 * 61;
            vector_salida[3] = 450 - PosNY +54;


            return vector_salida;
        }
        private int[] CentrarImagen(int x, int y)//Recibimos como inputs la posición en la que vamos a mover la pieza y nuestra intención es centrarla en el tablero.
        {
            int[] Posnueva = new int[2];
            int i = 0, j = 0;
            bool encontrarfila = false;
            bool encontrarcolumna = false;

            float medidaceldaX = medidaX / 8;
            float medidaceldaY = medidaY / 8;

            //Con estos bucles dividiremos el panel en 8 filas y 8 columnas y buscaremos en qué cuadrante se encunetra el punto.
            while ((i < 8) && (!encontrarfila))
            {
                i++;
                if ((x > 168) && (x < (medidaceldaX) * i + 168))
                {
                    encontrarcolumna = true;
                }


                if (encontrarcolumna == true)
                {
                    while ((j < 8) && !encontrarfila)
                    {
                        j++;
                        if ((y > 54) && (y < (medidaceldaY) * j + 54))
                        {
                            encontrarfila = true;
                        }

                    }

                }

            }

            //Una vez tenemos el cuadrante centraremos la Location de nuestra pieeza en medio de ese cuadrante
            Posnueva[0] = 169 + (i * medidaX / 8) - 32;
            Posnueva[1] = 54 + (j * medidaY / 8) - 28;

            return Posnueva;
        }
        private bool BuscarGanador(int y)//Recibe como input la posición de la ficha y comprueba si la ficha está en la última fila, si es el caso, la partida acaba proclamando como ganador al usuario.
        {//La ubicación de la función será justo después de la línea donde movemos la ficha.
            if ((y <= 54 + 56) && (1 == 1))
                return true;
            else
                return false;
        }
        private bool BuscarPerdedor(int y)//La función recibe la posición de la ficha que hemos recibido del servidor.
        {//La ubicación de la función será justo después de recibir y mover la ficha cuando recibimos l ainfo del servidor.
            if(y>=504-56)
                return true;
            else
                return false;
        }

        //Los próximos dos métodos se usan para los delegates,
        private void EscribirEnChat(string contrincante, string texto)
        {
            chat.BeginUpdate();
            chat.Items.Add(contrincante + ":- " + texto);
            chat.EndUpdate();
        }

        private void EnviarChat_Button_Click(object sender, EventArgs e)
        {
            chat.Items.Add(username + ":- " + textBox1.Text);
            string mensaje = "8/" + nForm.ToString() + "/" + Contrincante + "/" + textBox1.Text + "/";
            textBox1.Text = " ";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
           
            if (server != null)
                server.Send(msg);
            else
            {
                MessageBox.Show("Para utilizar los servicios debes conectarte primero al servidor");
            }
        }
        private void CambiarPosición(int PosNX, int PosNY, int tagFichaN, int tagFichaMatada)
        {

            int[] vector = ReUbicarFicha(PosNX, PosNY, tagFichaN, tagFichaMatada);

            if (vector[1] != -1)
            {
                Tablero.Controls.Remove(aircraft_vector[vector[1]]);
                this.cont2++;
            }
            aircraft_vector[vector[0]].Location = new Point(vector[2], vector[3]);
            turno = true;
            if (turno == true)
            { Turnolbl.Text = "Turno: Blancas"; Turnolbl.ForeColor = Color.AliceBlue; }
            else
            {
                Turnolbl.Text = "Turno : Negras"; Turnolbl.ForeColor = Color.DarkSlateGray;
            }
            bool perdedor = BuscarPerdedor(vector[3]);
            if (perdedor)
            {
                MessageBox.Show("El rival ha tenido suerte y te ha ganado, has sido derrotado!");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tablero.Controls.Remove(aircraft_vector[16]);
        }
    }
}
