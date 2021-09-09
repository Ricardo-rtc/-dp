USE SPMEDICAL;
GO

INSERT INTO Endereco (rua,numero,cidade,estado,cep)
VALUES ('Av. Bar�o de Limeira','532','S�o Paulo','SP','02011-970'),
	   ('Rua Estado de Israel','240','S�o Paulo','SP', '04022-000'),
	   ('Av. Paulista','1578','S�o Paulo','SP','01310-200'),
	   ('Av. Ibirapuera','2927','S�o Paulo','SP','04029-200'),
	   ('R. Vit�ria', '120','Barueri','SP','06402-030'),
	   ('R. Ver. Geraldo de Camargo','66','Ribeir�o Pires','SP','09405-380'),
	   ('Alameda dos Arapan�s','945','S�o Paulo','SP','04524-001'),
	   ('R. S�o Ant�nio','232','Barueri','SP','06407-140');
GO

INSERT INTO Clinica(idEndereco,nomeFantasia,cnpj,razaoSocial )
VALUES ('1','Clinica Possarle','86.400.902/0001-30','SP Medical Group');
GO

INSERT INTO Especialidade(tituloEspecialidade)
VALUES ('Acupuntura'), ('Anestesiologia'), ('Angiologia'),('Cardiologia'),
		('Cirurgia Cardiovascular'),('Cirurgia da M�o'),('Cirurgia do Aparelho Digestivo'),
		('Cirurgia Geral'), ('Cirurgia Pedi�trica'),('Cirurgia Pl�stica'),('Cirurgia Tor�cica'),
		('Cirurgia Vascular'),('Dermatologia'),('Radioterapia'),('Urologia'),('Pediatria'),('Psiquiatria');
GO

INSERT INTO TipoUsuario(tituloTipoUsuario)
VALUES ('user'),('adm'),('medico');
GO

INSERT INTO Usuario(idTipoUsuario,nomeUsuario,email,senha)
VALUES ('1','Ligia','ligia@gmail.com','ligia123'),
('1','Alexandre','alexandre@gmail.com','alexandre123'),
('1','Fernando','fernando@gmail.com','fernando123'),
('1','Henrique','henrique@gmail.com','henrique123'),
('1','Jo�o','joao@hotmail.com','joao123'),
('1','Bruno','bruno@gmail.com','bruno123'),
('1','Mariana','mariana@outlook.com','mariana123');
GO

	   



SELECT * FROM Endereco;
SELECT * FROM Clinica;
SELECT * FROM Especialidade;
SELECT * FROM TipoUsuario;
SELECT * FROM Usuario

