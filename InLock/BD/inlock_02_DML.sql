USE inlock_games_tarde;
GO

INSERT INTO TipoUsuario (Titulo)
VALUES	('Administrador')
		, ('Cliente')
;
GO

INSERT INTO Usuario ( email, senha, idTipoUsuario)
VALUES	('admin@admin.com', 'admin', 1)
		, ('cliente@cliente.com', 'cliente', 2)
;
GO

INSERT INTO Estudio (nomeEstudio)
VALUES	('Blizzard')
		, ('Rockstar Studios')
		, ('Squase Enix')
;
GO

INSERT INTO Jogo (nomeJogo, dataLan�amento, descricao, valor, idEstudio)
VALUES	('Diablo 3', '15 maio 2012', '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�', 99, 1)
		, ('Red Dead Redemption II', '26 outubro 2018', 'jogo eletr�nico de a��o-aventura western', 120, 2)
;
GO