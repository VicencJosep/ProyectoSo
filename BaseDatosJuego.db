//mysql -u root -p
DROP DATABASE IF EXISTS Juego;
CREATE DATABASE Juego;
USE Juego;
CREATE TABLE Jugador(
    ID INTEGER PRIMARY KEY NOT NULL,
    Username TEXT NOT NULL,
    Password TEXT NOT NULL
    )ENGINE = InnoDB;
CREATE TABLE Partidas(
    ID INTEGER PRIMARY KEY NOT NULL,
    Dificultad INTEGER NOT NULL,
    Entorno TEXT NOT NULL,
    FECHA TEXT NOT NULL,
    Ganador TEXT NOT NULL
    )ENGINE = InnoDB;
CREATE TABLE Relaciones(                                                    
     ID INTEGER PRIMARY KEY NOT NULL,
    ID_Partida INTEGER NOT NULL,
    ID_Jugador INTEGER NOT NULL,
    FOREIGN KEY (ID_Jugador) REFERENCES Jugador(ID),                          
    FOREIGN KEY (ID_Partida) REFERENCES Partidas(ID),                           
    Kills INTEGER NOT NULL
    )ENGINE = InnoDB; 
INSERT INTO  Jugador VALUES(1, 'Alicia', '1234');
INSERT INTO  Jugador VALUES(2, 'Hugo', '1234');
INSERT INTO  Jugador VALUES(3, 'Vicenç', '1234');
INSERT INTO Partidas VALUES(1, 2, 'Claro', '11111', 'Alicia');
INSERT INTO Partidas VALUES(2, 1, 'Oscuro', '11111','Alicia');
INSERT INTO Partidas VALUES(3, 3, 'Claro', '112321', 'Hugo');
INSERT INTO Relaciones VALUES(1, 2, 1, 3);
INSERT INTO Relaciones VALUES(2, 2, 2, 2);
INSERT INTO Relaciones VALUES(3, 1, 3, 4);



