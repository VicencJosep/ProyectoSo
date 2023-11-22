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



typedef struct
{
	char nombre[20];
	int socket;
}Conectado;

typedef struct
{
	Conectado conectados [100];
	int num; 
}ListaConectados;

ListaConectados milista;


int Pon(ListaConectados *lista, char nombre [20], int socket)
{
	if (lista->num == 100)
	{return -1;}

	else 
	{
		strcpy (lista->conectados[lista->num].nombre, nombre);
		lista->conectados[lista->num].socket = socket;	
		lista->num++;
		return 0;
	}
		
}

int DameSocket (ListaConectados *lista, char nombre[20])
{
	int j =0;
	int encontrado =0;
	while((j<lista->num) && !encontrado)
	{
		if(strcmp(lista->conectados[j].nombre, nombre))
		{encontrado =1;}
		
		if (!encontrado)
		{j = j+1;}
	}

	if(encontrado==1)
	{return lista->conectados[j].socket;}
	else
	{return-1;}
}


int Query1 (char entorno[80], MYSQL*conn, MYSQL_RES*resultado, MYSQL_ROW row)
{ 
	char consulta[100];
	sprintf(consulta,"SELECT Partida.ID FROM Partida WHERE Partida.Entorno='%s'", entorno);
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
		char resultado[512];
		strcpy(resultado, row[0]);
		int ID = atoi(resultado);
		return ID;
	}	
}


int Query2 (char nombre1[100], char nombre2[100], char fecha[100], MYSQL*conn, MYSQL_RES*resultado, MYSQL_ROW row)
{
	char consulta[100];
	sprintf(consulta,"SELECT Partida.Dificultad FROM Partida, Relaciones, Jugador WHERE Jugador.Username='%s' AND Jugador.ID=Relaciones.ID_Jugador AND Relaciones.ID_Partida=Partida.ID AND Partida.FECHA='%s' AND Partida.ID IN(SELECT Partida.ID FROM Partida, Relaciones, Jugador WHERE Jugador.Username='%s' AND Jugador.ID=Relaciones.ID_Jugador AND Relaciones.ID_Partida=Partida.ID AND Partida.FECHA='%s')", nombre1, fecha, nombre2, fecha );
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
		char resultado[512];
		strcpy(resultado, row[0]);
		int dificultad = atoi(resultado);
		return dificultad;
	}	
}

int Query3 (int dificultad, MYSQL*conn, MYSQL_RES*resultado, MYSQL_ROW row)
{ 
	char consulta[100];
	sprintf( consulta, "SELECT Relaciones.Kills FROM Relaciones, Partida WHERE Partida.Dificultad=%u AND Partida.ID=Relaciones.ID_Partida",dificultad);	
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
		char resultado[512];
		strcpy(resultado, row[0]);
		int kills = atoi(resultado);
		return kills;
	}	
}



int LogIn (char username[80], char contrasenya[100], MYSQL*conn, MYSQL_RES*resultado, MYSQL_ROW row)
{ 
	char consulta[100];
	sprintf(consulta,"SELECT Jugador.Password FROM Jugador WHERE Jugador.Username='%s'", username);
	//sprintf(consulta,"SELECT Jugador.Password FROM Jugador WHERE Jugador.Username='%s' AND Jugador.ID", username);
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

int Insertar(char username[512], char password[90], MYSQL*conn, MYSQL_RES*resultado, MYSQL_ROW row)
{
	char consulta[100];
	int cont = 0;
	strcpy(consulta,"SELECT*FROM Jugador");
	//sprintf(consulta,"SELECT Jugador.Password FROM Jugador WHERE Jugador.Username='%s' AND Jugador.ID", username);
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
		while (row !=NULL) 
		{
			cont++;
			// obtenemos la siguiente fila
			row = mysql_fetch_row (resultado);
		}		
		
	}
	cont++;
	printf("%d\n", cont);
	sprintf(consulta,"INSERT INTO Jugador (ID,username,password) VALUES ('%d','%s','%s');", cont,username,password);


	// REALIZAMOS INSERCION
	err = mysql_query(conn, consulta);
	if(err != 0)
	{
		printf("Error al introducir datos en la base de datos: %u %s\n", mysql_errno(conn), mysql_error(conn));
	}
	return err;
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
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "TFossa_BBDDJuego",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}

	
	//conn = *param->conn;
	//resultado = *param->resultado;
	
	char peticion[512];
	char respuesta[512];
	int ret;
	
	
	int terminar = 0;
	while (terminar == 0)
	{
		ret = read(sock_conn, peticion, sizeof(peticion)); //read lee la peticion y devuelve el numero de bytes leidos
		peticion[ret] = '\0'; //se añade una marca de fin de string en peticion para que no lea lo que hay mas allá del mensaje
		//printf("Recibido\n");
		printf("Peticion: %s\n",peticion);
		// INICIO DE LA OPERACIN DE DETERMINAR QUÉ ME PIDEN
		char *p = strtok(peticion, "/"); //separar el tipo de peticion del contenido
		int codigo = atoi(p); // asigna el tipo a codigo
		
		// DETERMINA QUE ME PIDEN Y PREPARA LA RESPUESTA
		if(codigo == 0)
		{
			terminar = 1;
		}
		else if(codigo == 1) // REGISTRARSE
		{
			p = strtok(NULL, "/");
			char username[512];
			strcpy(username, p);
			p = strtok(NULL, "/");
			char password[512];
			strcpy(password, p);
			//printf("Código: %d, Nombre: %s, Contraseña: %s\n", codigo, username, password);
			err = Insertar(username, password, conn, resultado, row);
			respuesta[0] = '\0';
			if(err == 0)
			{
				strcpy(respuesta, "1/si");
			}
			else
			   strcpy(respuesta, "1/-2");
			// FALTA PASAR EL RESULTADO DE LA CONSULTA AL CLIENTE
			
		}
		else if(codigo == 2) // LOG IN
		{
			p = strtok(NULL, "/");
			char username[100];
			strcpy(username, p);
			p = strtok(NULL, "/");
			char contrasenya[100];
			strcpy(contrasenya, p);
			//printf("Codigo: %d, Nombre: %s, Contraseña: %s\n", codigo, username, contrasenya);
			err = LogIn(username,contrasenya, conn, resultado, row);
			respuesta[0] = '\0';
			if(err >= 0)
			{
				if(err == 0)
				{
					strcpy(respuesta, "2/si");
					Pon(&milista,username,sock_conn);
					int j =0;
					
				}
				else
				   strcpy(respuesta, "2/no");
			}
			else
			   strcpy(respuesta, "2/-2");
		}
		else if(codigo == 3) // QUERY 1
		{
			p = strtok(NULL, "/");
			char entorno[100];
			strcpy(entorno, p);
			printf("Codigo: %d, Entorno: %s\n", codigo, entorno);
			err = Query1(entorno, conn, resultado, row);
			respuesta[0] = '\0';
			if(err > 0)
			{
				sprintf(respuesta, "3/%d", err);
			}
			else 
			   strcpy(respuesta, "3/-2");
		}
		else if(codigo == 4) // 	QUERY 2
		{
			char nombre1[100];
			char nombre2[100];
			char fecha[100];
			p = strtok(NULL, "/");
			strcpy(nombre1, p);
			p = strtok(NULL, "/");
			strcpy(nombre2, p);
			p = strtok(NULL, "/");
			strcpy(fecha, p);
			printf("Codigo: %d, Nombre1: %s, Nombre2: %s, Fecha: %s\n", codigo, nombre1, nombre2, fecha);
			err = Query2(nombre1, nombre2, fecha, conn, resultado, row);
			respuesta[0] = '\0';
			if(err > 0)
			{
				sprintf(respuesta, "4/%d", err);
			}	
			else
			   strcpy(respuesta, "4/-2");
		}
		else if(codigo == 5) // QUERY 3 
		{			
			p = strtok(NULL, "/");
			int dificultad;
			dificultad = atoi(p);
			err = Query3(dificultad, conn, resultado, row);
			respuesta[0] = '\0';
			if(err > 0)
			{
				sprintf(respuesta, "5/%d", err);
			}	
			else
			   strcpy(respuesta, "5/-2");		
		}
		else//	LISTA DE CONECTADOS
		{	
		
		}
		
		if(codigo != 0)
		{
			printf("Respuesta: %s\n", respuesta);
			// ENVIAR LA RESPUESTA 
			write(sock_conn, respuesta, strlen(respuesta));
		}
		
		if((codigo ==1)|| (codigo == 2) || (codigo == 3)|| (codigo == 4)|| (codigo == 5))
		{
			pthread_mutex_lock(&mutex);
			contador = contador +1;
			pthread_mutex_unlock(&mutex);
			//Notificar a todos los clientes conectados
			char notificacion1[20];
			sprintf(notificacion1, "-1/%d", contador);
			int j =0;
			char notificacion2[20];
			strcpy(notificacion2, "-2");
			printf("Nombre dentro del ltimo if :%s , j : %d, NUMERO:%d\n",milista.conectados[0].nombre,j,milista.num);
			while(j < i)
			{
				sprintf(notificacion2,"%s/%s",notificacion2, milista.conectados[j].nombre);
				
	
				
				
				//printf("Nombre dentro del bucle:%s",milista.conectados[j].nombre);
				j = j+1;
			}
			printf("%s\n ",notificacion2);
			for(j=0; j<i; j++)
			{
				//write(sockets[j], notificacion1, strlen(notificacion1));
				write(sockets[j], notificacion2, strlen(notificacion2));
			}
/*			for(j=0; j<i; j++)*/
/*			{*/
/*				write(sockets[j], notificacion1, strlen(notificacion1));*/
				//write(sockets[j], notificacion2, strlen(notificacion2));
/*			}*/
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
	int puerto = 9060;
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
		i++;
	
	}
	
	return 0;	

}
