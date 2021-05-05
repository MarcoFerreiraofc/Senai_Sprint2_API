-- DQL

USE SPMG_DBFIRST;
GO

SELECT * FROM TipoUsuarios;

SELECT * FROM Usuarios

SELECT * FROM Pacientes;

SELECT * FROM Medicos;

SELECT * FROM Especialidades;

SELECT * FROM Clinicas;

SELECT * FROM Situacoes;

SELECT * FROM Consultas;


-- IN�CIO FUNCIONALIDADES:

	-- aqui mostrar� as contas(seus emails) com seus "cargos"(admistrador, m�dico e paciente);
	SELECT permissao AS TipoUsuario, email AS Email FROM tipoUsuarios
	INNER JOIN usuarios
	ON tipoUsuarios.idTipoUsuario = usuarios.idTipoUsuario;
	GO
	

	-- aqui ser� informado o paciente, data do agendamento e qual m�dico ir� atender a consulta (o m�dico possuir� sua determinada especialidade);
	SELECT nomePaciente AS Paciente, nomeMedico AS M�dico, especialidade AS Especialidade, dataConsulta AS DiaAgendamento, horaConsulta AS HoraAgendamento, situacao AS Situa��o FROM Consultas
	INNER JOIN Pacientes
	ON Consultas.idPaciente = Pacientes.idPaciente
	INNER JOIN Medicos
	ON Consultas.idMedico = Medicos.idMedico
	INNER JOIN Especialidades
	ON Especialidades.idEspecialidade = Medicos.idEspecialidade
	INNER JOIN Situacoes
	ON Consultas.idSituacao = Situacoes.idSituacao;
	GO


	-- aqui dever� informar os dados da cl�nica (como endere�o, hor�rio de funcionamento, CNPJ, nome fantasia e raz�o social);
	SELECT nomeFantasia, razaoSocial, cnpj, endereco, horarioAbertura, horarioFechamento FROM Clinicas;
	GO


	-- aqui o m�dico poder� ver os agendamentos (consultas) associados a ele;
	SELECT nomeMedico AS M�dico, nomePaciente AS Paciente, descricao AS Descri��o, dataConsulta AS DataAgendamento, horaConsulta AS HoraAgendamento, situacao AS Agendamento FROM Medicos
	INNER JOIN Consultas
	ON Medicos.idMedico = Consultas.idMedico
	INNER JOIN Pacientes
	ON Consultas.idPaciente = Pacientes.idPaciente
	INNER JOIN Situacoes
	ON Consultas.idSituacao = Situacoes.idSituacao
	WHERE Medicos.idMedico = 2; -- Roberto Possarle
	GO


	-- aqui o paciente poder� visualizar suas pr�prias consultas;
	SELECT nomePaciente AS Paciente, nomeMedico AS M�dico, descricao AS Descri��o, dataConsulta AS DataAgendamento, horaConsulta AS HoraAgendamento, situacao AS Agendamento FROM Medicos
	INNER JOIN Consultas
	ON Medicos.idMedico = Consultas.idMedico
	INNER JOIN Pacientes
	ON Consultas.idPaciente = Pacientes.idPaciente
	INNER JOIN Situacoes
	ON Consultas.idSituacao = Situacoes.idSituacao
	WHERE Pacientes.idPaciente = 7; -- Mariana
	GO


	-- aqui temos um simulador de login b�sico;
	SELECT permissao AS TipoUsuario, email AS Emails, senha AS Senhas FROM Usuarios
	INNER JOIN TipoUsuarios
	ON Usuarios.idTipoUsuario = TipoUsuarios.idTipoUsuario
	WHERE email = 'adm@adm.com' AND senha = 'adm123';
	GO


-- CAPACIDADES E CRIT�RIOS:

	-- aqui mostra a quantidade de usu�rios cadastrados;
	SELECT COUNT (Usuarios.idUsuario) AS QtdUsuarios FROM Usuarios;
	GO


	-- aqui converte a data de nascimento dos usu�rios para o formato (mm-dd-yyyy) na exibi��o;
	SELECT nomePaciente AS Nomes, CONVERT (VARCHAR, dataNascimento, 101) AS DataNascimento FROM Pacientes; -- o 101 � meio que o "id" de convers�o de data pra cada pa�s, por exemplo, esse 101 � o padr�o de data dos EUA
	GO


	-- aqui foi calculado a idade dos pacientes a partir da data de nascimento; || 8766 � o n�mero de horas que tem um ano
	SELECT nomePaciente AS Nomes, DATEDIFF(HOUR, dataNascimento,GETDATE())/8766 AS Idades FROM Pacientes;
	GO


	-- aqui foi criado um evento para que a idade do usu�rio seja calculada todos os dias;
	SELECT Pacientes.nomePaciente, Pacientes.dataNascimento,
	CASE -- esse CASE funciona tipo um if no C#, caso a primeira condi��o for atendida, vai retornar tal "valor"
	WHEN DATEPART(MONTH, Pacientes.dataNascimento) <= DATEPART(MONTH, GETDATE()) -- o DATEPART retorna uma parte espec�fica de uma data
	AND DATEPART(DAY, Pacientes.dataNascimento) <= DATEPART(DAY, GETDATE())
	THEN (DATEDIFF(YEAR, Pacientes.dataNascimento,GETDATE())) -- o DATEDIFF retorna a diferen�a entre duas datas
	ELSE (DATEDIFF(YEAR, Pacientes.dataNascimento,GETDATE())) - 1 -- caso nenhuma das outras condi��es forem verdadeiras, o ELSE retorna um valor
	END AS IdadeAtual
	FROM Pacientes
	WHERE Pacientes.idPaciente = 7
	GO


	-- aqui foi criado um evento para que a idade do usu�rio seja calculada todos os anos;
	SELECT Pacientes.nomePaciente, Pacientes.dataNascimento,
	DATEDIFF(YEAR, Pacientes.dataNascimento,GETDATE()) AS IdadeAtual
	FROM Pacientes;
	GO


	-- FUN��O
		-- aqui foi criado uma fun��o para retornar a quantidade de m�dicos de uma determinada especialidade;
		CREATE FUNCTION QntdMedicos(@idEspecialidade VARCHAR(200)) -- vai ser tipo um m�todo, o @idEspecialidade vai ser um "atributo" vazio pra pegar outro valor depois
		RETURNS INT -- no final vai ser retornado um valor INT
		AS -- como
		BEGIN -- in�cio
			DECLARE @qntd AS INT -- vai ser declarado um outro "atributo" INT vazio pra pegar o resultado final
			SET @qntd = -- vai "setar" dentro de @qntd
			(
			SELECT COUNT(nomeMedico) FROM Medicos -- vai contar os nomes dos m�dicos
			INNER JOIN Especialidades -- vai relacionar os nomes dos m�dicos com as especialidades
			ON Medicos.idEspecialidade = Especialidades.idEspecialidade
			WHERE Especialidades.especialidade = @idEspecialidade -- isso vai ocorrer onde o tituloEspecialidade for igual ao "atributo" @idEspecialidade
			)
			RETURN @qntd -- no fim vai retornar o valor com todas as informa��es
		END -- fim
		GO
		SELECT qntd = dbo.QntdMedicos('Psiquiatria'); -- vai exibir o valor do dbo.QntdMedicos('ESPECIALIDADE'), s� que com o nome do atributo onde foi reunido todas os dados, que � o @qntd
		GO
		SELECT dbo.QntdMedicos('Psiquiatria') AS QuantidadeMedicos; -- mesma coisa do de cima, mas com outro nome na tabela
		GO


	-- STORED PROCEDURE

		-- aqui foi criado uma fun��o para que retorne a idade do usu�rio a partir de uma determinada stored procedure;
		-- calcular a idade de todos os usu�rios
		CREATE PROCEDURE CalcularIdadeTodos
		AS
		SELECT Pacientes.nomePaciente, Pacientes.dataNascimento,
		DATEDIFF(YEAR, Pacientes.dataNascimento,GETDATE()) AS IdadeAtual
		FROM Pacientes;
		GO
		-- aqui executa o stored procedure "CalcularIdade"
		EXECUTE CalcularIdadeTodos;
		GO


		-- aqui foi criado uma fun��o para que retorne a idade do usu�rio a partir de uma determinada stored procedure;
		-- calcular a idade de um usu�rio espec�fico
		CREATE PROCEDURE CalcularIdadeEspecifica(@nomePaciente VARCHAR(100))
		AS
		SELECT Pacientes.nomePaciente, Pacientes.dataNascimento,
		DATEDIFF(YEAR, Pacientes.dataNascimento,GETDATE()) AS IdadeAtual
		FROM Pacientes
		WHERE Pacientes.nomePaciente = @nomePaciente;
		GO
		-- aqui executa o stored procedure "CalcularIdade" pelo nome do paciente:
		EXECUTE CalcularIdadeEspecifica @nomePaciente = 'Mariana';
		GO