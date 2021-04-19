CREATE DATABASE inlock_games_tarde;
GO

USE inlock_games_tarde;
GO

CREATE TABLE Estudio
(
	idEstudio INT PRIMARY KEY IDENTITY
	, nomeEstudio VARCHAR (200)
);
GO

CREATE TABLE TipoUsuario
(
	idTipoUsuario INT PRIMARY KEY IDENTITY
	, Titulo VARCHAR (200)
);
GO

CREATE TABLE Jogo
(
	idJogo INT PRIMARY KEY IDENTITY
	, nomeJogo VARCHAR(200)
	, descricao VARCHAR(300)
	, dataLançamento DATE
	, valor MONEY
	, idEstudio INT FOREIGN KEY REFERENCES Estudio(idEstudio)
);
GO

CREATE TABLE Usuario
(
	idUsuario INT PRIMARY KEY IDENTITY
	, email VARCHAR(200)
	, senha VARCHAR(200)
	, idTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario (idTipoUsuario)
);
GO