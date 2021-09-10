USE SPMEDICAL_R;
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
('1','Mariana','mariana@outlook.com','mariana123'),
('2','Saulo','saulo@hotmail.com','saulo123'),
('3','Ricardo Lemos','ricardo.lemos@spmedicalgroup.com.br','lemos123'),
('3','Roberto Possarle','roberto.possarle@spmedicalgroup.com.br','possarle123'),
('3','Helena Strada','helena.souza@spmedicalgroup.com.br','strada123');
GO

INSERT INTO Medico(idClinica,idEspecialidade,idUsuario,nomeMed,crm)
VALUES ('1','2','9','Ricardo Lemos','54356-SP'),('1','17','10','Roberto Possarle','53452-SP'),
	   ('1','16','11','Helena Strada','65463-SP');
GO

INSERT INTO Paciente(idEndereco,idUsuario,nomePaciente,rg,cpf,dataNasc,telefone)
VALUES ('2','1','Ligia','435.225.43-5','948.398.590-00','1983/10/13','11 3456-7654'),
('3','2','Alexandre','326.543.45-7','735.569.440-57','2001-07-23','11 98765-6543'),
('4','3','Fernando','546.365.25-3',	'168.393.380-02','1978-10-10','11 97208-4453'),
('5','4','Henrique','543.663.62-5',	'14332654765','1985-10-13',	'11 3456-6543'),
('6','5','João','532.544.44-1','913.053.480.10','1975-08-27','11 7656-6377'),
('7','6','Bruno','545.662.66-7','797.992.990-04','1972-03-21','11 95436-8769'),
('8','7','Mariana','545.662.66-8','137.719.130-39','2018-03-05','11 97453-1274');
GO

INSERT INTO Situacao(situacao)
VALUES ('Agendada'),('Realizada'),('Cancelada');
GO

INSERT INTO Consulta(idMedico,idSituacao,idPaciente,dataConsulta)
VALUES ('3','2','7','2020-01-20 15:00'),
	   ('2','3','2','2020-01-06 10:00'),
	   ('2','2','3','2020-02-07 11:00'),
	   ('2','2','2','2018-02-06 10:00'),
	   ('1','3','4','2019-02-07 11:00'),
	   ('3','1','7','2020-03-08 15:00'),
	   ('1','1','4','2020-03-09 11:00');
GO



SELECT * FROM Endereco;
SELECT * FROM Clinica;
SELECT * FROM Especialidade;
SELECT * FROM TipoUsuario;
SELECT * FROM Usuario;
SELECT * FROM Medico;
SELECT * FROM Paciente;
SELECT * FROM Situacao;
SELECT * FROM Consulta;

	


