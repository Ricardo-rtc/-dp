USE SPMEDICAL_R;
GO

SELECT * FROM Clinica;
SELECT * FROM Consulta;
SELECT * FROM Endereco;
SELECT * FROM Especialidade;
SELECT * FROM Medico;
SELECT * FROM Paciente;
SELECT * FROM Situacao;
SELECT * FROM TipoUsuario;
SELECT * FROM Usuario;

	SELECT nomePaciente,dataConsulta,situacao, tituloEspecialidade, nomeMed
	FROM Situacao S,Clinica W, Medico M,Paciente P,Especialidade E
	RIGHT JOIN Consulta C
	ON C.idMedico = C.idMedico

	SELECT c.idConsulta, p.nomePaciente, m.nomeMed, e.tituloEspecialidade, c.dataConsulta, s.situacao
	FROM Consulta C
	INNER JOIN Medico M
	ON C.idMedico = M.idMedico
	INNER JOIN Especialidade E
	ON E.idEspecialidade = m.idEspecialidade
	INNER JOIN Paciente P
	ON p.idPaciente = c.idPaciente
	INNER JOIN Situacao S 
	ON S.idSituacao = c.idSituacao