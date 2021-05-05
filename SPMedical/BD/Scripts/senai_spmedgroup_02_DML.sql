-- DML

USE SPMG_DBFIRST;
GO


INSERT INTO TipoUsuarios(permissao)
VALUES	('Administrador'),
		('M�dico'),
		('Paciente');
GO



INSERT INTO Usuarios(idTipoUsuario, email, senha)
VALUES	(2, 'ricardo.lemos@spmedicalgroup.com.br', 'ricardo123'),
		(2, 'roberto.possarle@spmedicalgroup.com.br', 'possarle123'),
		(2, 'helena.souza@spmedicalgroup.com.br', 'helena123'),
		(3, 'ligia@gmail.com', 'ligia123'),
		(3, 'alexandre@gmail.com', 'alexandre123'),
		(3, 'fernando@gmail.com', 'fernando123'),
		(3, 'henrique@gmail.com', 'henrique123'),
		(3, 'joao@gmail.com', 'joao123'),
		(3, 'bruno@gmail.com', 'bruno123'),
		(3, 'mariana@outlook.com', 'mariana123'),
		(1, 'adm@adm.com', 'adm123'),
		(2, 'lucas@lucas.com', 'lucas123');
GO



INSERT INTO Especialidades(especialidade)
VALUES	('Acupuntura'),
		('Anestesiologia'),
		('Angiologia'),
		('Cardiologia'),
		('Cirurgia Cardiovascular'),
		('Cirurgia de M�o'),
		('Cirurgia do Aparelho Digestivo'),
		('Cirurgia Geral'),
		('Cirurgia Pedi�trica'),
		('Cirurgia Pl�stica'),
		('Cirurgia Tor�cica'),
		('Cirurgia Vascular'),
		('Dermatologia'),
		('Radioterapia'),
		('Urologia'),
		('Pediatria'),
		('Psiquiatria');
GO



INSERT INTO Clinicas(cnpj, nomeFantasia, razaoSocial, endereco, horarioAbertura, horarioFechamento)
VALUES	('86400902000130', 'Cl�nica Possarle', 'SP Medical Group', 'Av. Bar�o Limeira, 532, S�o Paulo, SP', '7:00', '23:00');
GO



INSERT INTO Pacientes(idUsuario, nomePaciente, cpf, rg, dataNascimento, telefonePaciente, endereco)
VALUES	(4, 'Ligia', '94839859000', '435225435', '03/10/1983', '1134567654', 'Rua Estado de Israel 240,�S�o Paulo, Estado de S�o Paulo, 04022-000'),
		(5, 'Alexandre', '73556944057', '326543457', '03/07/2001', '11987656543', 'Av. Paulista, 1578 - Bela Vista, S�o Paulo - SP, 01310-200'),
		(6, 'Fernando', '16839338002', '546365253', '10/10/1978', '11972084453', 'Av. Ibirapuera - Indian�polis, 2927,  S�o Paulo - SP, 04029-200'),
		(7, 'Henrique', '14332654765', '543663625', '13/10/1985', '1134566543', 'R. Vit�ria, 120 - Vila Sao Jorge, Barueri - SP, 06402-030'),
		(8, 'Jo�o', '91305348010', '325444441', '27/08/75', '1176566377', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeir�o Pires - SP, 09405-380'),
		(9, 'Bruno', '79799299004', '545662667', '21/03/1972', '11954368769', 'Alameda dos Arapan�s, 945 - Indian�polis, S�o Paulo - SP, 04524-001'),
		(10, 'Mariana', '13771913039', '545662668', '05/03/2018', '', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');
GO



INSERT INTO Medicos(idUsuario, idEspecialidade, idClinica, nomeMedico, crm)
VALUES	(1, 2, 1, 'Ricardo Lemos', '54356SP'),
		(2, 17, 1, 'Roberto Possarle', '53452SP'),
		(3, 16, 1, 'Helena Strada', '65463SP'),
		(12, 17, 1, 'Lucas Apolin�rio', '12345SP');
GO



INSERT INTO Situacoes(situacao)
VALUES	('Realizada'),
		('Cancelada'),
		('Agendada');
GO



INSERT INTO Consultas(idMedico, idPaciente, idSituacao, dataConsulta, horaConsulta, descricao)
VALUES	(3, 7, 1, '20/01/2020', '15:00', 'Paciente com bronquite.'),
		(2, 2, 2, '06/01/2020', '10:00', 'Paciente com crises de ansiedade.'),
		(2, 3, 1, '07/02/2020', '11:00', 'Paciente com problemas sociais.'),
		(2, 2, 1, '06/02/2018', '10:00', 'Paciente com depress�o.'),
		(1, 4, 2, '07/02/2019', '11:00', 'Paciente verificando se tem alguma alergia � anestesia.');
GO



-- aqui temos o teste do comando DEFAULT, que � pra mostra no DQL 'n�o', na coluna de solicitacaoExame
INSERT INTO Consultas(idMedico, idPaciente, idSituacao, dataConsulta, horaConsulta)
VALUES	(3, 7, 3, '08/03/2020', '15:00'),
		(1, 4, 3, '09/03/2020', '11:00');
GO



-- aqui foi atualizado os registros que n�o possuem data de nascimento conforme especificado pelo cliente;
UPDATE Pacientes
SET Pacientes.dataNascimento = '01/10/1983'
WHERE Pacientes.idPaciente = 1;