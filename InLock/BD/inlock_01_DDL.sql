-- DDL

CREATE DATABASE inlock_games_tarde;
GO

USE inlock_games_tarde;
GO

CREATE TABLE estudios(
	idEstudio INT PRIMARY KEY IDENTITY,
	nomeEstudio VARCHAR(250) NOT NULL
);
GO

CREATE TABLE jogos(
	idJogo INT PRIMARY KEY IDENTITY,
	nomeJogo VARCHAR(250) NOT NULL,
	descricao VARCHAR(250) NOT NULL,
	dataLancamento DATE NOT NULL,
	valor SMALLMONEY NOT NULL,
	idEstudio INT FOREIGN KEY REFERENCES estudios(idEstudio)
);
GO

CREATE TABLE tipoUsuarios(
	idTipoUsuario INT PRIMARY KEY IDENTITY,
	permissao VARCHAR(250) UNIQUE NOT NULL
);
GO

CREATE TABLE usuarios(
	idUsuario INT PRIMARY KEY IDENTITY,
	email VARCHAR(250) UNIQUE NOT NULL,
	senha VARCHAR(250) NOT NULL,
	idTipoUsuario INT FOREIGN KEY REFERENCES tipoUsuarios(idTipoUsuario)
);
GO