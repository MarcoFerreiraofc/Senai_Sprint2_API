
-- 1. Criar o banco de dados chamado SENAI_HROADS_MANHA/SENAI_HROADS_TARDE (conforme o período)
CREATE DATABASE SENAI_HROADS_TARDE;
GO

USE SENAI_HROADS_TARDE;
GO

-- 2. Criar as tabelas no banco de dados
CREATE TABLE Classe
(
	idClasse INT PRIMARY KEY IDENTITY
	, NomeClasse VARCHAR(200) NOT NULL UNIQUE
);
GO

CREATE TABLE Personagem
(
	idPersonagem INT PRIMARY KEY IDENTITY
	, idClasse INT FOREIGN KEY REFERENCES Classe(idCLasse)
	, NomePersonagem VARCHAR(200) NOT NULL UNIQUE
	, VidaMaxima INT NOT NULL
	, ManaMaxima INT NOT NULL
	, DataCriacao DATE NOT NULL
	, DataAtualizacao DATE NOT NULL
);
GO

CREATE TABLE TipoHabilidade
(
	idTipoHabilidade INT PRIMARY KEY IDENTITY
	, TipoHabilidade VARCHAR(200) NOT NULL UNIQUE
);
GO

CREATE TABLE Habilidade
(
	idHabilidade INT PRIMARY KEY IDENTITY
	, idTipoHabilidade INT FOREIGN KEY REFERENCES TipoHabilidade(idTipoHabilidade) NOT NULL
	, NomeHabilidade VARCHAR(200) NOT NULL UNIQUE 
);
GO

CREATE TABLE HabilidadesClasse
(
	idClasse INT FOREIGN KEY REFERENCES Classe(idCLasse) NOT NULL
	, idHabilidade INT FOREIGN KEY REFERENCES Habilidade(idHabilidade) NOT NULL
);
GO

CREATE TABLE TiposUsuario
(
	idTipoUsuario INT PRIMARY KEY IDENTITY
	, Titulo VARCHAR(200) NOT NULL UNIQUE
);
GO

CREATE TABLE USUARIO
(
	idUsuario INT PRIMARY KEY IDENTITY
	, email VARCHAR(200) NOT NULL UNIQUE
	, senha VARCHAR (200) NOT NULL
	, idTipoUsuario INT FOREIGN KEY REFERENCES TiposUsuario(idTipoUsuario)
);