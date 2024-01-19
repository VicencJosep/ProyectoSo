//Incluir esta libreri\uffc2\uffada para poder hacer las llamadas en shiva2.upc.es
#include <stdio.h>
#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <mysql.h>
#include <pthread.h>

int contador;
int i;
int sockets[100];
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
pthread_mutex_t mutexLista = PTHREAD_MUTEX_INITIALIZER;

typedef struct
{
	char nombre[100];
	int socket;
}Conectado;

typedef struct
{
	Conectado conectados [100];
	int num; 
}ListaConectados;

ListaConectados milista;
typedef struct 
{
	char player1[100];
	char player2[100];
	int socket1;
	int socket2;
	int enMarcha;
	int slot;
}Partida;
typedef struct 
{
	Partida partidas[100];
	int num;
}TablaPartidas;

TablaPartidas tPartidas;

int  RegistrarFinPartida(TablaPartidas*t, char username[100],char perdedor[100],int killsGanador,int  killsPerdedor,MYSQL*conn,MYSQL_RES*resultado,MYSQL_ROW row)
{
	int encontrado = 0;
	int j = 0;
	int slot;
	int IDGanador;
	int IDPerdedor;
	char consulta[512];
	int err;
	while((j < t->num) && (encontrado == 0))
	{
		if((strcmp(username, t->partidas[j].player1) == 0) ||(strcmp(username, t->partidas[j].player2) == 0) && (strcmp(perdedor, t->partidas[j].player1) == 0) ||(strcmp(perdedor, t->partidas[j].player2) == 0))
		{
			slot = t->partidas[j].slot;
			encontrado =1;
		}
		if(encontrado == 0)
			j++;
	}
	t->partidas[j].enMarcha = 0;
	sprintf(consulta, "SELECT Jugador.ID FROM Jugador WHERE Jugador.Username='%s';", username);
	err = mysql_query(conn, consulta);
	if(err != 0)
	{
		printf("Ha habido un error con la base de datos creando la partida");
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return -1;
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if(row == NULL || row[0] == NULL)
	{
		return -1;
	}
	else
		IDGanador = atoi(row[0]);
	sprintf(consulta, "SELECT Jugador.ID FROM Jugador WHERE Jugador.Username='%s';", perdedor);
	err = mysql_query(conn, consulta);
	if(err != 0)
	{
		printf("Ha habido un error con la base de datos creando la partida");
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return -1;
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if(row == NULL || row[0] == NULL)
	{
		return -1;
	}
	else
		IDPerdedor = atoi(row[0]);
	sprintf(consulta, "UPDATE Partida SET Partida.FECHA=CURRENTTIMESTAMP AND Partida.Ganador_ID=%d WHERE Partida.ID=%d", IDGanador, slot);
	err = mysql_query(conn, consulta);
	if(err != 0)
	{
		printf("Ha habido un error con la base de datos finalizando la partida");
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return -1;
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if(row == NULL || row[0] == NULL)
	{
		return -1;
	}
	sprintf(consulta, "UPDATE Relaciones SET Relaciones.Kills=%d WHERE Relaciones.ID_Jugador=%d AND Relaciones.ID_Partida=%d", killsGanador, IDGanador, slot);
	err = mysql_query(conn, consulta);
	if(err != 0)
	{
		printf("Ha habido un error con la base de datos finalizando la partida");
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return -1;
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if(row == NULL || row[0] == NULL)
	{
		return -1;
	}
	sprintf(consulta, "UPDATE Relaciones SET Relaciones.Kills=%d WHERE Relaciones.ID_Jugador=%d AND Relaciones.ID_Partida=%d", killsPerdedor, IDPerdedor, slot);
	err = mysql_query(conn, consulta);
	if(err != 0)
	{
		printf("Ha habido un error con la base de datos finalizando la partida");
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return -1;
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if(row == NULL || row[0] == NULL)
	{
		return -1;
	}
	return 0;

}
int CrearSala(TablaPartidas *t, char n1[100], char n2[100], int s1, int s2, MYSQL*conn, MYSQL_RES*resultado,MYSQL_ROW row)
{
	int encontrado = 0;
	int j= 0;
	int sePuede = 0;
	while((j < t->num)&&encontrado == 0)
	{
		if(t->partidas[j].enMarcha == 0)
		{
			strcpy(t->partidas[j].player1, n1);
			strcpy(t->partidas[j].player2, n2);
			t->partidas[j].socket1 = s1;
			t->partidas[j].socket2 = s2;
			t->partidas[j].enMarcha = 1;
			encontrado = 1;
			sePuede = 1;
		}
		if(encontrado == 0)
		{
			j = j+1;
		}
	}
	if(encontrado == 0)
	{
		if(t->num <100)
		{
			strcpy(t->partidas[t->num].player1, n1);
			strcpy(t->partidas[t->num].player2, n2);
			t->partidas[t->num].socket1 = s1;
			t->partidas[t->num].socket2 = s2;
			t->partidas[t->num].enMarcha = 1;
			t->num++;
			sePuede = 1;
		}
		else
			return -1;
	}
	if(sePuede == 1)
	{
		int err ;
		char consulta[512];
		int siguienteID;
		strcpy(consulta, "SELECT max(ID) FROM Partida;");
		err = mysql_query(conn, consulta);
		if(err != 0)
		{
			printf("Ha habido un error con la base de datos creando la partida");
			return -2;
		}
		resultado = mysql_store_result(conn);
		row = mysql_fetch_row(resultado);
		if(row == NULL || row[0] == NULL)
		{
			siguienteID =1;
		}
		else
			siguienteID = atoi(row[0]) +1;
		if(encontrado==0)
			t->partidas[t->num].slot = siguienteID;
		else
			t->partidas[j].slot = siguienteID;
		printf("ID de la partida creada: %d", siguienteID);
		sprintf(consulta, "INSERT INTO Partida(ID) VALUES(%d);", siguienteID);
		err = mysql_query(conn, consulta);
		if(err != 0)
		{
			printf ("Error al consultar datos de la base %u %s\n",
					mysql_errno(conn), mysql_error(conn));
			return -2;
		}
		return siguienteID;
	}
}



int RegistrarPartidaParaJugadores(int slot, char player1[100], char player2[100], MYSQL*conn, MYSQL_RES*resultado, MYSQL_ROW row)
{
	int err;
	char consulta[512];
	int id1, id2, idRelaciones;
	int cont = 0;
	sprintf(consulta, "SELECT Jugador.ID FROM Jugador WHERE Jugador.Username='%s';", player1);
	err = mysql_query(conn, consulta);
	if(err != 0)
	{
		printf("Ha habido un error con la base de datos creando la partida");
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return -1;
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if(row == NULL || row[0] == NULL)
	{
		return -1;
	}
	else
		id1 = atoi(row[0]);
	sprintf(consulta, "SELECT Jugador.ID FROM Jugador WHERE Jugador.Username='%s';", player2);
	err = mysql_query(conn, consulta);
	if(err != 0)
	{
		printf("Ha habido un error con la base de datos creando la partida");
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return -1;
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if(row == NULL || row[0] == NULL)
	{
		return -1;
	}
	else
		id2 = atoi(row[0]);
	strcpy(consulta, "SELECT max(ID) FROM Relaciones;");
	err = mysql_query(conn, consulta);
	if(err != 0)
	{
		printf("Ha habido un error con la base de datos creando la partida");
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return -1;
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if(row == NULL || row[0] == NULL)
	{
		idRelaciones = 1;
	}
	else
		idRelaciones = atoi(row[0]) + 1;
	printf("ID RELACIONES: %d\n", idRelaciones); ////	QUITAR CUANDO SE RESUELVA
	int kills = 0;
	sprintf(consulta, "INSERT INTO Relaciones VALUES(%d, %d, %d, %d);",idRelaciones,slot,id1, kills);
	err = mysql_query(conn, consulta);
	if(err != 0)
	{
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return -1;
	}
	idRelaciones = idRelaciones + 1;
	sprintf(consulta, "INSERT INTO Relaciones VALUES(%d, %d, %d, %d);",idRelaciones,slot,id2,kills);
	err = mysql_query(conn, consulta);
	if(err != 0)
	{
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return -1;
	}
	return 0;
}


int Pon(ListaConectados *lista, char nombre [100], int socket)
{
	if (lista->num == 100)
	{return -1;}

	else 
	{
		int encontrado = 0;
		int j = 0;
		while((j< lista->num) && (encontrado == 0))
		{
			if(strcmp(lista->conectados[j].nombre, "0") == 0)
				encontrado = 1;
			if(encontrado == 0)
				j++;
		}
		if(encontrado == 0)
		{
			strcpy (lista->conectados[lista->num].nombre, nombre);
			lista->conectados[lista->num].socket = socket;	
			lista->num++;
		}
		else
		{
			strcpy(lista->conectados[j].nombre, nombre);
			lista->conectados[j].socket = socket;
		}

		return 0;
	}

}

int DameSocket (ListaConectados *lista, char nombre[100])
{
	int j =0;
	int encontrado =0;
	while((j<lista->num) && !encontrado)
	{
		if(strcmp(lista->conectados[j].nombre, nombre) == 0)
		{encontrado =1;}
		if (!encontrado)
		{j = j+1;}
	}

	if(encontrado==1)
	{return lista->conectados[j].socket;}
	else
	{return-1;}
}


int ConQuienHeJugado (char Username[80], char nombres[512], MYSQL*conn, MYSQL_RES*resultado, MYSQL_ROW row)
{
	char consulta[512];
	sprintf(consulta,"SELECT Jugador.Username FROM Jugador,Partida,Relaciones WHERE Jugador.Username!='%s' AND Jugador.ID=Relaciones.ID_Jugador AND Relaciones.ID_Partida=Partida.ID AND Partida.ID IN (SELECT Partida.ID FROM Jugador, Relaciones, Partida WHERE Jugador.Username='%s' AND Jugador.ID=Relaciones.ID_Jugador AND Partida.ID=Relaciones.ID_Partida);", Username, Username);
	int err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return -1; // No se ha podido hacer la consulta
	}
	resultado = mysql_store_result(conn); 
	row = mysql_fetch_row (resultado);

	if (row == NULL)
	{
		printf ("No se han obtenido datos en la consulta\n");
		return -2; // Consulta vacía
	}
	else
	{
		while(row != NULL)
		{
			sprintf(nombres, "%s%s$", nombres, row[0]);
			row = mysql_fetch_row(resultado);
		}
		return 1;
	}
}


int ResultadoPartidasConAlguien (char nombre1[100], char consult[512], MYSQL*conn, MYSQL_RES*resultado, MYSQL_ROW row)
{
	char consulta[512];
	int IDPartidas[100];
	int IDGanadores[100];
	int j=0;
	sprintf(consulta,"select Partida.ID from Partida, Jugador, Relaciones where Jugador.Username='%s' and Relaciones.ID_Jugador=Jugador.ID and Partida.ID=Relaciones.ID_Partida;", nombre1);
	int err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return -1; // No se ha podido hacer la consulta
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
	{
		printf ("No se han obtenido datos en la consulta de ID de Partidas\n");
		return -2; // Consulta vacía
	}
	else
	{
		while(row != NULL)
		{
			IDPartidas[j] = atoi(row[0]);
			row = mysql_fetch_row(resultado);
			j++;
		}

	}
	sprintf(consulta,"select Partida.Ganador_ID from Partida, Jugador, Relaciones where Jugador.Username='%s' and Relaciones.ID_Jugador=Jugador.ID and Partida.ID=Relaciones.ID_Partida;", nombre1);
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return -1; // No se ha podido hacer la consulta
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
	{
		printf ("No se han obtenido datos en la consulta del ID de los Ganadores\n");
		return -2; // Consulta vacía
	}
	else
	{
		j = 0;
		while(row != NULL)
		{
			IDGanadores[j] = atoi(row[0]);
			row = mysql_fetch_row(resultado);
			j++;
		}
	}
	int k = 0;
	while(k <j)
	{
		sprintf(consulta, "select Jugador.Username from Jugador where Jugador.ID=%d;",IDGanadores[k]);
		err=mysql_query (conn, consulta);
		if (err!=0) {
			printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
			return -1; // No se ha podido hacer la consulta
		}
		resultado = mysql_store_result(conn);
		row = mysql_fetch_row (resultado);
		if (row == NULL)
		{
			printf ("No se han obtenido datos en la consulta del Nombre de los Ganadores\n");
			return -2; // Consulta vacía
		}
		else
		{
			sprintf(consult, "%s%s$%dÂ¡", consult, row[0], IDPartidas[k]);
		}
		row = mysql_fetch_row(resultado);
		k++;
	}
	return 1;
}

int ConsultarPartidasEnUnPeriodo(char fecha1[100], char fecha2[100], char Partidas[512], MYSQL*conn, MYSQL_RES*resultado, MYSQL_ROW row)
{ 
	char consulta[512];
	sprintf( consulta, "SELECT Partida.ID FROM Partida WHERE Partida.FECHA BETWEEN '%s' AND '%s';", fecha1, fecha2);	
	int err=mysql_query (conn, consulta);
	if (err!=0) 
	{
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return -1; // No se ha podido hacer la consulta
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
	{
		printf ("No se han obtenido datos en la consulta\n");
		return -2; // Consulta vacía
	}
	else
	{
		while(row != NULL)
		{
			sprintf(Partidas, "%s%s/", Partidas, row[0]);
			row = mysql_fetch_row(resultado);
		}
		return 0;
	}
}



int LogIn (char username[80], char contrasenya[100], MYSQL*conn, MYSQL_RES*resultado, MYSQL_ROW row)
{ 
	char consulta[100];
	sprintf(consulta,"SELECT Jugador.Password FROM Jugador WHERE Jugador.Username='%s'", username);
	int err=mysql_query (conn, consulta);
	if (err!=0) 
	{
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		return -1; // No se ha podido hacer la consulta
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
	{
		printf ("No se han obtenido datos en la consulta\n");
		return -2; // Consulta vacía
	}
	else
	{
		char resultado[512];
		strcpy(resultado, row[0]);
		if(strcmp(contrasenya, resultado) == 0)
			return 0;
		else 
			return 1;

	}
	char respuesta[400];
}

//			COMPROBAR QUE EL NUEVO ELIMINAR FUNCIONA
int EliminarUsuario(char nomUsuario[100], MYSQL*conn, MYSQL_RES*resultado, MYSQL_ROW row)
{
	char consulta[512];
	int err;
	int IDUsuario;
	sprintf(consulta, "SELECT ID FROM Jugador WHERE Username='%s';", nomUsuario);
	err = mysql_query(conn, consulta);
	if(err != 0)
	{
		printf("Falla seleccionando el id del Jugador: %u %s\n", mysql_errno(conn), mysql_error(conn));
		return -1;
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	if (row == NULL)
	{
		printf ("No se han obtenido datos en la consulta\n");
		return -2;
	}
	else
	{
		IDUsuario = atoi(row[0]);
		sprintf(consulta, "SELECT ID_Partida FROM Relaciones WHERE ID_Jugador=%d", IDUsuario);
		err = mysql_query(conn, consulta);
		if(err != 0)
		{
			printf("Falla seleccionando el id de la partida: %u %s\n", mysql_errno(conn), mysql_error(conn));
			return -1;
		}
		resultado = mysql_store_result(conn);
		row = mysql_fetch_row(resultado);
		sprintf(consulta, "UPDATE Relaciones SET Relaciones.ID_Jugador=-1 WHERE Relaciones.ID_Jugador=%d;", IDUsuario);
		err = mysql_query(conn, consulta);
		if(err != 0)
		{
			printf("Falla borrando de la tabla Relaciones:  %u %s\n", mysql_errno(conn), mysql_error(conn));
			return -1;
		}
		resultado = mysql_store_result(conn);
		row = mysql_fetch_row(resultado);
		if(row ==NULL)
		{
			printf("Ha habido un error");
			return -1;
		}
		else
			return 0;
//		sprintf(consulta, "DELETE FROM Jugador WHERE ID=%d;", IDUsuario);
//		err = mysql_query(conn, consulta);
//		if(err != 0)
//		{
//			printf("Falla borrando de la tabla jugador: %u %s\n", mysql_errno(conn), mysql_error(conn));
//			return -1;
//		}
//		int j = 0;
//		int IDPartida;
//		while(row != NULL)
//		{
//			IDPartida = atoi(row[j]);
//			sprintf(consulta, "DELETE FROM Partida WHERE ID=%d;", IDPartida);
//			err = mysql_query(conn, consulta);
//			if(err != 0)
//			{
//				printf("Falla borrando de la tabla Partidas: %u %s\n", mysql_errno(conn), mysql_error(conn));
//				return -1;
//			}
//			j++;
//		}
//		return 0;
	}
}


int Insertar(char username[512], char password[90], MYSQL*conn, MYSQL_RES*resultado, MYSQL_ROW row)
{
	char consulta[100];
	int IDJugador;
	strcpy(consulta, "SELECT max(ID) FROM Jugador;");
	int err=mysql_query (conn, consulta);
	if (err!=0) 
	{
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		return -1; // No se ha podido hacer la consulta
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
	{
		printf ("No se han obtenido datos en la consulta\n");
		return -2; // Consulta vacía
	}
	else
	{
		IDJugador = atoi(row[0]) +1;
	}
	printf("IdD nuevo jugador registrado: %d\n", IDJugador);
	sprintf(consulta,"INSERT INTO Jugador (ID,username,password) VALUES ('%d','%s','%s');", IDJugador,username,password);


	// REALIZAMOS INSERCION
	err = mysql_query(conn, consulta);
	if(err != 0)
	{
		printf("Error al introducir datos en la base de datos: %u %s\n", mysql_errno(conn), mysql_error(conn));
	}
	return err;
}

int InvitarJugador(char invitado[100], ListaConectados milista ) // FunciÃ³n para invitar al otro jugador a la partida, devuelsve el socket del invitado
{
	int j = 0;
	int encontrado = 0;
	int s;
	while((j<milista.num) &&(encontrado == 0))
	{
		if(strcmp(milista.conectados[j].nombre, invitado) == 0)
		{
			encontrado = 1;
			s = milista.conectados[j].socket;
		}
		if(encontrado == 0)
		   j++;
	}
	if(encontrado == 0)
	{
		return -1;
	}
	else
	   return s;
}


int ComprobarSiYaEstaRegistrado(char usuario[100], MYSQL*conn, MYSQL_RES *resultado, MYSQL_ROW row) // Para evitar que se registren dos usuarios con el mismo nombre
{
	int err;
	char consulta[100];
	sprintf(consulta, "SELECT Jugador.ID FROM Jugador WHERE Jugador.username='%s';", usuario);
	err = mysql_query(conn, consulta);
	if(err != 0)
	{
		printf("Error al consultar la base de datos %u %s\n", mysql_errno(conn), mysql_error(conn));
		return -1;
	}
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	int resultado_login;
	if(row == NULL)
	{
		resultado_login = 0;
	}
	else
		resultado_login = 1;
	return resultado_login;
}



int ComprobarSiEstaConectado(ListaConectados l, char nombre[100])
{
	int encontrado = 0;
	int j = 0;
	while((j < l.num) && (encontrado == 0))
	{
		if(strcmp(l.conectados[j].nombre, nombre) == 0)
			encontrado = 1;
		if(encontrado == 0)
			j++;
	}
	return encontrado;
}




void *AtenderJugador (void *socket)
{
	int sock_conn;
	int *s;
	s = (int *) socket;
	sock_conn = *s;
	//		CONEXIÓN CON LA BASE DE DATOS
	MYSQL*conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;

	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexi\ufff3n: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexin
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "TFossa_BBDDJuego",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}


	char peticion[512];
	char respuesta[512];
	int ret;
	char username[512];
	int terminar = 0;
	while (terminar == 0)
	{
		ret = read(sock_conn, peticion, sizeof(peticion)); //read lee la peticion y devuelve el numero de bytes leidos
		peticion[ret] = '\0'; //se añade una marca de fin de string en peticion para que no lea lo que hay mas allá del mensaje
		//printf("Recibido\n");
		printf("Peticion de %s: %s\n",username, peticion);
		// INICIO DE LA OPERACIN DE DETERMINAR QUÉ ME PIDEN
		char *p = strtok(peticion, "/"); //separar el tipo de peticion del contenido
		int codigo = atoi(p); // asigna el tipo a codigo
		int numForm;
		p = strtok(NULL, "/");
		numForm = atoi(p);
		// DETERMINA QUE ME PIDEN Y PREPARA LA RESPUESTA
		if(codigo == 0) // DESCONECTAR
		{
			pthread_mutex_lock(&mutexLista);
			int j =0;
			char notificacion2[100];
			sprintf(notificacion2, "-2/%d/", numForm);
			char mensaje[100];
			while(j < milista.num)
			{
				if(strcmp(milista.conectados[j].nombre, username) == 0)
				{
					strcat(notificacion2, "eliminado/");
					strcpy(milista.conectados[j].nombre, "0");
					mensaje[0] = '\0';
					//sprintf(notificacion2, "%s%s/", notificacion2, milista.conectados[j].nombre);
				}
				else
				{
					sprintf(mensaje,"%s/", milista.conectados[j].nombre);
					strcat(notificacion2, mensaje);
					mensaje[0] = '\0';
					//sprintf(notificacion2, "%s%s/", notificacion2, milista.conectados[j].nombre);
				}
				j = j+1;
			}
			printf("%s\n ",notificacion2);
			for(j=0; j<milista.num; j++)
			{
				write(milista.conectados[j].socket, notificacion2, strlen(notificacion2));

			}
			notificacion2[0] = '\0';
			ListaConectados l;
			for(j = 0; j<milista.num; j++ )
			{
				if(strcmp(milista.conectados[j].nombre, "0") != 0)
				{
					int res = Pon(&l, milista.conectados[j].nombre,milista.conectados[j].socket);
				}
			}
			milista = l;
			pthread_mutex_unlock(&mutexLista);
			printf("*%s con socket %d se ha desconectado*\n", username, sock_conn);
			terminar = 1;
		}
		else if(codigo == 1) // REGISTRARSE
		{
			p = strtok(NULL, "/");
			strcpy(username, p);
			p = strtok(NULL, "/");
			char password[512];
			strcpy(password, p);
			int existeUsuario = ComprobarSiYaEstaRegistrado(username, conn, resultado, row);
			if(existeUsuario == 0)
			{
				err = Insertar(username, password, conn, resultado, row);
				respuesta[0] = '\0';
				if(err == 0)
				{
					sprintf(respuesta, "1/%d/si", numForm);
				}
				else
				   sprintf(respuesta, "1/%d/-2", numForm);
			}
			else
				sprintf(respuesta, "1/%d/-1", numForm);

			// FALTA PASAR EL RESULTADO DE LA CONSULTA AL CLIENT
		}
		else if(codigo == 2) // LOG IN
		{
			p = strtok(NULL, "/");
			strcpy(username, p);
			p = strtok(NULL, "/");
			char contrasenya[100];
			strcpy(contrasenya, p);

			printf("Codigo: %d, Nombre: %s, Contraseña: %s\n", codigo, username, contrasenya);
			int encontrado = ComprobarSiEstaConectado(milista, username);
			if(encontrado == 0)
			{
				err = LogIn(username,contrasenya, conn, resultado, row);
				respuesta[0] = '\0';
				if(err >= 0)
				{
					if(err == 0)
					{
						sprintf(respuesta, "2/%d/si", numForm);
						pthread_mutex_lock(&mutexLista);
						Pon(&milista,username,sock_conn);
						pthread_mutex_unlock(&mutexLista);
						int j =0;
						char notificacion2[100];
						sprintf(notificacion2, "-2/%d/", numForm);
						char mensaje[100];
						while(j < milista.num)
						{
							sprintf(mensaje,"%s/", milista.conectados[j].nombre);
							strcat(notificacion2, mensaje);
							mensaje[0] = '\0';
							j = j+1;
						}
						printf("%s\n ",notificacion2);
						for(j=0; j<milista.num; j++)
						{
							write(milista.conectados[j].socket, notificacion2, strlen(notificacion2));
						}
						notificacion2[0] = '\0';
						printf("*%s con socket %d se ha conectado*\n", username, sock_conn);
					}
					else
					   sprintf(respuesta, "2/%d/no", numForm);
				}
				else
				   sprintf(respuesta, "2/%d/-2", numForm);
			}
			else
				sprintf(respuesta, "2/%d/YaConectado", numForm);

		}
		else if(codigo == 3) // Jugadores con los que he jugado
		{
			char nombres[512];
			err = ConQuienHeJugado(username,nombres, conn, resultado, row);
			respuesta[0] = '\0';
			if(err > 0)
			{
				sprintf(respuesta, "3/%d/%s",numForm, nombres);
			}
			else
			   sprintf(respuesta, "3/%d/-2", numForm);
		}
		else if(codigo == 4) // 	Resultado de las partidas Jugadas
//Que me diga tambien con quien he jugado y las kills de la partida
		{
			char consulta[512];
			err =  ResultadoPartidasConAlguien(username,consulta, conn, resultado, row);
			respuesta[0] = '\0';
			if(err > 0)
			{
				sprintf(respuesta, "4/%d/%s",numForm,consulta);
			}
			else
			   sprintf(respuesta, "4/%d/-2",numForm);
		}
		else if(codigo == 5) // Partidas en un intervalo de tiempo
		{
			p = strtok(NULL, "/");
			char fecha1[100];
			strcpy(fecha1, p);
			p = strtok(NULL, "/");
			char fecha2[100];
			strcpy(fecha2, p);
			char Partidas[512];
			err =  ConsultarPartidasEnUnPeriodo(fecha1, fecha2, Partidas, conn, resultado, row);
			respuesta[0] = '\0';
			if(err == -2)
			{
				sprintf(respuesta, "5/%d/Err",numForm);
			}
			else
			   sprintf(respuesta, "5/%d/%s",numForm, Partidas);
		}
		else if(codigo == 6) // INVITACIÃ“N 
		{
			p = strtok(NULL, "/");
			char invitado[100];
			strcpy(invitado, p);
			if(strcmp(invitado, username) == 0)
			{
				sprintf(respuesta, "6/%d/NoPuedesAutoinvitarte", numForm);
			}
			else
			{
				int SocketInvitado = InvitarJugador(invitado, milista);
				respuesta[0] = '\0';
				if(SocketInvitado == -1)
					sprintf(respuesta, "6/%d/Error", numForm);
				else
				{
					sprintf(respuesta, "6/%d/Enviado",numForm);
					char notif[100];
					sprintf(notif, "-3/%d/%s",numForm, username);
					write(SocketInvitado, notif, strlen(notif));
					printf("NotificaciÃ³n a %s: %s\n",invitado, notif);
				}
			}

		}
		else if(codigo == 7) // ACEPTAR O RECHAZAR INVITACIÃ“N
		{
			p=strtok(NULL, "/");
			char resInvitacion[20];
			strcpy(resInvitacion, p);
			char nomInvitador[100];
			p=strtok(NULL, "/");
			strcpy(nomInvitador, p);
			int socketInvitador = DameSocket(&milista, nomInvitador);
			if(socketInvitador == sock_conn)
				printf("Â¡Â¡Â¡Estas cogiendo mal el socket!!!!\n");
			if(strcmp(resInvitacion, "No")== 0)
			{
				char notif[100];
				sprintf(notif, "-4/%d/No",numForm);
				printf("NotificaciÃ³n a %s: %s\n", nomInvitador, notif);
				if(socketInvitador == -1)
					printf("No se ha podido enviar la notificacion de respuesta a invitaciÃ³n\n");
				else
					write(socketInvitador, notif, strlen(notif));
			}
			else
			{
				int slot = CrearSala(&tPartidas, username, nomInvitador, sock_conn, socketInvitador, conn, resultado, row);
				if(slot < 0)
				{
					if(slot == -1)
					{
						printf("Error con la tabla de partidas\n");
					}
					else
						printf("Error insertando en la base de datos\n");
				}
				else
				{
					 // Introducir a los jugadores en la partida de la base de datos
					printf("Nuevo slot de partida %d\n", slot);
					int res = RegistrarPartidaParaJugadores(slot, username, nomInvitador, conn, resultado, row);
					char notif[100];
					if(res == -1)
					{
						printf("Ha habido un error registrando la partida en relaciones\n");
						sprintf(notif, "-4/%d/Err",numForm);
						printf("NotificaciÃ³n: %s\n", notif);
					}
					else
					{
						sprintf(notif, "-4/%d/Si",numForm);
						printf("NotificaciÃ³n: %s\n", notif);
					}
//					res = DameSocket(&milista,nombre);
					write(socketInvitador, notif, strlen(notif));
//					if(res == -1)
//						printf("No se ha podido enviar la notificacion de respuesta a invitaciÃ³n");
//					else
//					{

						//write(sock_conn, notif, strlen(notif));
//					}
				}
			}
		}
		else if(codigo == 8)	// CHAT
		{
			p = strtok(NULL, "/");
			char jugador2[100];
			strcpy(jugador2, p);
			int socket2 = DameSocket(&milista, jugador2);
			if(socket2 == sock_conn)
				printf("Â¡Â¡Â¡Estas cogiendo mal el socket!!!!\n");
			p = strtok(NULL, "/");
			char texto[512];
			strcpy(texto, p);
			char notif[800];
			sprintf(notif, "-5/%d/%s/", numForm, texto);
			write(socket2, notif, strlen(notif));
			printf("Notificacion a %s: %s", jugador2, notif);
			if(socket2 == -1)
			{
				printf("Ha habido un error con el chat\n");
			}
			else
			{

			}
		}
		else if(codigo == 9) // ELIMINAR USUARIO
// No borrar las partidas sinÃ³ cambiar el nombre
		{
			int err = EliminarUsuario(username, conn, resultado, row);
			if(err == 0)
			{
				sprintf(respuesta, "9/%d/Eliminado/", numForm);	
				pthread_mutex_lock(&mutexLista);
				int j =0;
				char notificacion2[100];
				sprintf(notificacion2, "-2/%d/", numForm);
				char mensaje[100];
				while(j < milista.num)
				{
					if(strcmp(milista.conectados[j].nombre, username) == 0)
					{
						strcat(notificacion2, "eliminado/");
						strcpy(milista.conectados[j].nombre, "0");
						mensaje[0] = '\0';
						//sprintf(notificacion2, "%s%s/", notificacion2, milista.conectados[j].nombre);
					}
					else
					{
						sprintf(mensaje,"%s/", milista.conectados[j].nombre);
						strcat(notificacion2, mensaje);
						mensaje[0] = '\0';
						//sprintf(notificacion2, "%s%s/", notificacion2, milista.conectados[j].nombre);
					}
					j = j+1;
				}
				printf("%s\n ",notificacion2);
				for(j=0; j<milista.num; j++)
				{
					write(milista.conectados[j].socket, notificacion2, strlen(notificacion2));

				}
				notificacion2[0] = '\0';
				ListaConectados l;
				for(j = 0; j<milista.num; j++ )
				{
					if(strcmp(milista.conectados[j].nombre, "0") != 0)
					{
						int res = Pon(&l, milista.conectados[j].nombre,milista.conectados[j].socket);
					}
				}
				milista = l;
				pthread_mutex_unlock(&mutexLista);
				printf("*El usuario %s ha sido eliminado*\n", username);
			}
			else
				sprintf(respuesta, "9/%d/Error/", numForm);
		}
		else if(codigo == 10) // ACTUALIZAR POSICION
		{
			p = strtok(NULL, "/");
			char jugador2[100];
			strcpy(jugador2, p);
			int socket2 = DameSocket(&milista, jugador2);
			if(socket2 == sock_conn)
				printf("Â¡Â¡Â¡Estas cogiendo mal el socket!!!!\n");
			p = strtok(NULL, "/");
			int posX;
			posX = atoi(p);
			p = strtok(NULL, "/");
			int posY;
			posY = atoi(p);
			p = strtok(NULL, "/");
			int tagFicha1;
			tagFicha1 = atoi(p);
			p = strtok(NULL, "/");
			int tagFichaMatada;
			tagFichaMatada = atoi(p);
			char notif[800];
			sprintf(notif, "-6/%d/%d/%d/%d/%d/", numForm,posX,posY,tagFicha1,tagFichaMatada);
			write(socket2, notif, strlen(notif));
			printf("Notificacion a %s: %s", jugador2, notif);
		}
		else if(codigo == 11) // FIN DE PARTIDA
		{
			p = strtok(NULL, "/");
			char perdedor[100];
			strcpy(perdedor, p);
			int socketPerdedor = DameSocket(&milista, perdedor);
			p = strtok(NULL, "/");
			int killsGanador = atoi(p);
			p = strtok(NULL, "/");
			int killsPerdedor = atoi(p);
			char notif[512];
			err = RegistrarFinPartida(&tPartidas, username, perdedor, killsGanador, killsPerdedor, conn, resultado, row);
			if(err < 0)
				printf("Error al acabar la partida");
		}
		else if(codigo == 12)
		{
			p = strtok(NULL, "/");
			char nombre[100];
			strcpy(nombre, p);
			int socket = DameSocket(&milista, nombre);
			char notif[100];
			sprintf(notif, "-7/%d/", numForm);
			printf("NotificaciÃ³n a %s: %s\n",nombre, notif);
			write(socket, notif, strlen(notif));
		}
		else
		{
			printf("Me ha llegado un codigo incorrecto");
		}
		if(codigo != 0)
		{
			if(respuesta[0] != '\0')
			{
				printf("Respuesta a %s: %s\n",username, respuesta);
				// ENVIAR LA RESPUESTA 
				write(sock_conn, respuesta, strlen(respuesta));
				respuesta[0] = '\0';
			}
		}
		if((codigo == 2)||(codigo == 0))
		{

		}
	}
	mysql_close (conn);
	// CERRAR LA CONEXIÓN
	close(sock_conn);
	//VUELVE A EMPEZAR EL BUCLE
}



int main(int argc, char *argv)
{

	char consulta[512];

	//		CONEXIÓN DEL SERVIDOR
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char respuesta[512];
	char peticion[512];
	int puerto = 50070;
	//		INICIALITZACIONS
	//Obrir el socket de escucha
	if((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
	{
		printf("Error creant el socket");
	}
	memset(&serv_adr, 0, sizeof(serv_adr)); //inicialitza a 0 el serv_adr
	serv_adr.sin_family = AF_INET;
	// INICIO DE LA ESTRUCTURA DE DATOS
	//asigna la ip del computador que ejecute el programa
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// asigna el puerto a utilizar
	serv_adr.sin_port = htons(puerto);
	// ASOCIAR AL SOCKET DE ESCUCHA LA ESTRUCTURA DE DATOS
	if(bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr))<0)
		printf("Error al bind");

	if(listen(sock_listen, 3) < 0)
		printf("Error al listen");//error si la cola de connexiones esperando a ser atendidas es mayor de 
	// INCIALIZAR THREADS
	contador = 0;
	pthread_t thread[100];
	i = 0;
	for(;;) //atiende solo 5 peticiones pero suele ser infinito
	{
		printf("escuchando\n");
		// el servidor esta parado hasta que alguien se conecte, y cuando pasa genera un socket diferente (de conexión)
		sock_conn = accept(sock_listen, NULL, NULL); //socket a través del cual se conecta con la máquina
		printf("He recibido conexion\n");
		sockets[i] = sock_conn; // socket que se usar para este jugador 
		pthread_create (&thread[i], NULL, AtenderJugador, &sockets[i]); // Crea el thread y le dice que tiene que hacer
		if(i==100)
			i=0;
		else
			i++;
	}
	return 0;
}

