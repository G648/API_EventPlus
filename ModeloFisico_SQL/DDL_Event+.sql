-- Criando o DDL

--[1] Criar banco de dados 
--[2] Criar tabelas

DROP DATABASE [Event+_Manha];

CREATE DATABASE [Event+_Manha];

USE [Event+_Manha];

CREATE TABLE TipoUsuario
(
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	TituloTipoUsuario VARCHAR (255) NOT NULL UNIQUE
);

CREATE TABLE Instituicao
(
	IdInstituicao INT PRIMARY KEY IDENTITY,
	NomeInstituicao VARCHAR (255) NOT NULL,
	CNPJ CHAR (14) NOT NULL UNIQUE,
	EnderecoInstituicao VARCHAR (255) NOT NULL
);


CREATE TABLE TipoDeEvento
(
	IdTipoDeEvento INT PRIMARY KEY IDENTITY,
	TituloTipoEvento VARCHAR (255) NOT NULL UNIQUE
);

CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario),
	NomeUsuario VARCHAR (255) NOT NULL,
	EmailUsuario VARCHAR (50) NOT NULL UNIQUE,
	SenhaUsuario VARCHAR (25)  NOT NULL
);

CREATE TABLE Evento
(
	IdEvento INT PRIMARY KEY IDENTITY,
	IdTipoDeEvento INT FOREIGN KEY REFERENCES TipoDeEvento(IdTipoDeEvento),
	IdInstituicao INT FOREIGN KEY REFERENCES Instituicao(IdInstituicao),
	NomeEvento VARCHAR (255) NOT NULL,
	DescricaoEvento VARCHAR (255),
	DataEvento DATE NOT NULL,
	HoraEvento TIME NOT NULL
);

CREATE TABLE PresencaEvento
(
	IdPresencaEvento INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento),
	SituacaoEvento BIT DEFAULT(0)
);
--BIT == valor booleano

CREATE TABLE Comentario
(
	IdComentarioEvento INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento),
	DescricaoComentario VARCHAR (255),
	Exibe BIT DEFAULT(0)
);
