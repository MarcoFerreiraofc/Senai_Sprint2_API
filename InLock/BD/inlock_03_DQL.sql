-- DQL

USE inlock_games_tarde;
GO

SELECT * FROM usuarios;

SELECT * FROM estudios;

SELECT * FROM jogos;

SELECT nomeJogo, descricao, dataLancamento, valor, nomeEstudio FROM jogos
INNER JOIN estudios
ON jogos.idEstudio = estudios.idEstudio;

SELECT nomeEstudio, nomeJogo, descricao, dataLancamento, valor FROM estudios
LEFT JOIN jogos
ON estudios.idEstudio = jogos.idEstudio;

SELECT email, senha, permissao FROM usuarios
INNER JOIN tipoUsuarios
ON usuarios.idTipoUsuario = tipoUsuarios.idTipoUsuario
WHERE email = 'admin@admin.com' AND senha = 'admin';

SELECT nomeJogo, descricao, dataLancamento, valor FROM jogos
WHERE jogos.idJogo = 1;

SELECT nomeEstudio FROM estudios
WHERE estudios.idEstudio = 1;