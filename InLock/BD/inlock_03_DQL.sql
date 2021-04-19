USE inlock_games_tarde;
GO


--Listar todos os usu�rios
SELECT * FROM Usuario;
GO

SELECT * FROM TipoUsuario;
GO


--Listar todos os usu�rios
SELECT * FROM Estudio;
GO

--Listar todos os jogos
SELECT * FROM Jogo;
GO


--Listar todos os jogos e seus respectivos est�dios
SELECT J.nomeJogo, J.descricao, J.dataLan�amento, FORMAT (J.valor, 'c', 'pt-br') , E.nomeEstudio AS Estudio FROM Jogo AS J
INNER JOIN Estudio AS E
ON J.idEstudio = E.idEstudio
;
GO

--Buscar e trazer na lista todos os est�dios com os respectivos jogos
SELECT E.idEstudio, E.nomeEstudio, J.nomeJogo FROM Estudio AS E
LEFT JOIN Jogo AS J
ON J.idEstudio = E.idEstudio
WHERE E.idEstudio = 1
;
GO

--Buscar um usu�rio por e-mail e senha
SELECT * FROM Usuario
WHERE email = 'admin@admin.com' AND senha = 'admin'
;
GO


--Buscar um jogo por idJogo
SELECT * FROM Jogo
WHERE idJogo = 1
;
GO

--Buscar um est�dio por idEstudio
SELECT * FROM Estudio
WHERE idEstudio = 1
;
GO