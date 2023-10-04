//Incluir esta libreriￂﾭa para poder hacer las llamadas en shiva2.upc.es
#include <my_global.h>
#include <mysql.h>
#include <string.h>
#include <stdlib.h>
#include <stdio.h>
int main(int argc, char *argv)
{
    MYSQLconn;
    int err;
    // Estructura especial para almacenar resultados de consultas 
    MYSQL_RES *resultado;
    MYSQL_ROW row;

    //Creamos una conexion al servidor MYSQL 
    conn = mysql_init(NULL);
    if (conn==NULL) {
        printf ("Error al crear la conexi￳n: %u %s\n", 
                mysql_errno(conn), mysql_error(conn));
        exit (1);
    }
    //inicializar la conexin
    conn = mysql_real_connect (conn, "localhost","root", "mysql", "Juego",0, NULL, 0);
    if (conn==NULL) {
        printf ("Error al inicializar la conexion: %u %s\n", 
                mysql_errno(conn), mysql_error(conn));
        exit (1);
    }
   char consulta[80]
   strcpy( consulta, "SELECT Kills FROM Relaciones,Jugadores,Partidas WHERE Relaciones.Dificultad=”1” AND Relaciones.ID = Jugadores.ID AND Partidas.Dificultad= “Dificil”);



    err=mysql_query (conn, consulta);
    if (err!=0) {
        printf ("Error al consultar datos de la base %u %s\n",
                mysql_errno(conn), mysql_error(conn));
        exit (1);
    }


    if (row == NULL)
        printf ("No se han obtenido datos en la consulta\n");
    else
        while (row !=NULL) {
            // la columna 0 contiene el nombre del jugador
            printf ("%s\n", row[0]);
            // obtenemos la siguiente fila
            row = mysql_fetch_row (resultado);
    }

    mysql_close (conn);
    exit(0);
}