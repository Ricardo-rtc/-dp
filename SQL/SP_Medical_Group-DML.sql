USE SPMEDICAL;
GO

INSERT INTO Endereco (rua,numero,cidade,estado,cep)
VALUES ('Av. Barão de Limeira','532','São Paulo','SP','02011-970'),
	   ('Rua Estado de Israel','240','São Paulo','SP', '04022-000'),
	   ('Av. Paulista','1578','São Paulo','SP','01310-200'),
	   ('Av. Ibirapuera','2927','São Paulo','SP','04029-200'),
	   ('R. Vitória', '120','Barueri','SP','06402-030'),
	   ('R. Ver. Geraldo de Camargo','66','Ribeirão Pires','SP','09405-380'),
	   ('Alameda dos Arapanés','945','São Paulo','SP','04524-001'),
	   ('R. São Antônio','232','Barueri','SP','06407-140');
GO

INSERT INTO Clinica(idEndereco,nomeFantasia,cnpj,razaoSocial )
VALUES ('1','Clinica Possarle','86.400.902/0001-30','SP Medical Group');
GO

INSERT INTO Especialidade(tituloEspecialidade)
VALUES ('Acupuntura'), ('Anestesiologia'), ('Angiologia'),('Cardiologia'),
		('Cirurgia Cardiovascular'),('Cirurgia da Mão'),('Cirurgia do Aparelho Digestivo'),
		('Cirurgia Geral'), ('Cirurgia Pediátrica'),('Cirurgia Plástica'),('Cirurgia Torácica'),
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
('1','João','joao@hotmail.com','joao123'),
('1','Bruno','bruno@gmail.com','bruno123'),
('1','Mariana','mariana@outlook.com','mariana123');
GO

	   



SELECT * FROM Endereco;
SELECT * FROM Clinica;
SELECT * FROM Especialidade;
SELECT * FROM TipoUsuario;
SELECT * FROM Usuario

