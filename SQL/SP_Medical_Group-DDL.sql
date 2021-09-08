CREATE DATABASE SPMEDICAL;
GO

USE SPMEDICAL;
GO

CREATE TABLE Endereco(	
	idEndereco INT PRIMARY KEY IDENTITY,
	rua VARCHAR(500),
	numero INT,
	cidade VARCHAR(100),
	estado VARCHAR(100),
	cep INT
);
GO

CREATE TABLE Clinica(
	idClinica INT PRIMARY KEY IDENTITY,
	idEndereco INT FOREIGN KEY REFERENCES Endereco(idEndereco),
	nomeFantasia VARCHAR(200),
	cnpj INT,
	razaoSocial VARCHAR(200)
);
GO

CREATE TABLE Especialidade(
	idEspecialidade INT PRIMARY KEY IDENTITY,
	tituloEspecialidade VARCHAR(100)
);
GO

CREATE TABLE TipoUsuario(
	idTipoUsuario INT PRIMARY KEY IDENTITY,
	tituloTipoUsuario VARCHAR(100)
);
GO

CREATE TABLE Usuario(
	idUsuario INT PRIMARY KEY IDENTITY,
	idTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(idTipoUsuario),
	nomeUsuario VARCHAR(200),
	email VARCHAR(200),
	senha VARCHAR(100)
);
GO

CREATE TABLE Medico(
	idMedico INT PRIMARY KEY IDENTITY, 
	idClinica INT FOREIGN KEY REFERENCES Clinica(idClinica),
	idEspecialidade INT FOREIGN KEY REFERENCES Especialidade(idEspecialidade),
	idUsuario INT FOREIGN KEY REFERENCES Usuario(idUsuario),
	nomeMed VARCHAR(200),
	crm INT
);
GO

CREATE TABLE Paciente(
	idPaciente INT PRIMARY KEY IDENTITY,
	idEndereco INT FOREIGN KEY REFERENCES Endereco(idEndereco), 
	idUsuario INT FOREIGN KEY REFERENCES Usuario(idUsuario),
	nomePaciente VARCHAR(200),
	rg INT,
	cpf INT, 
	dataNasc DATE,
	telefone INT
);
GO

CREATE TABLE Situacao(
	idSituacao INT PRIMARY KEY IDENTITY,
	situacao VARCHAR(50),
);
GO

CREATE TABLE Consulta(
	idConsulta INT PRIMARY KEY IDENTITY,
	idMedico INT FOREIGN KEY REFERENCES Medico(idMedico),
	idSituacao INT FOREIGN KEY REFERENCES Situacao(idSituacao),
	idPaciente INT FOREIGN KEY REFERENCES Paciente(idPaciente),
	dataConsulta DATETIME,
	descricaoConsulta VARCHAR(500)
);
GO