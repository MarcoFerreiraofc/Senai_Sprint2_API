USE SENAI_HROADS_TARDE;
GO

-- 3. Inserir os registros conforme descrição no próprio texto (classes, habilidades, tipos de habilidades e personagens)
INSERT INTO Classe (NomeClasse)
VALUES	('Barbaro')
		, ('Cruzado')
		, ('Caçadora de Demônios')
		, ('Monge')
		, ('Necromante')
		, ('Feiticeiro')
		, ('Arcanista')
;
GO

INSERT INTO Personagem (idClasse, NomePersonagem, VidaMaxima, ManaMaxima, DataCriacao, DataAtualizacao)
VALUES	(1, 'DeuBug', 100, 80, '18/01/2019', '02/03/2021')
		, (4, 'BitBug', 70, 100, '17/03/2016', '02/03/2021')
		, (7, 'Fer8', 75, 60, '18/03/2018', '02/03/2021')
;
GO

INSERT INTO TipoHabilidade (TipoHabilidade)
VALUES	('Ataque')
		, ('Defesa')
		, ('Cura')
		, ('Magia')
;
GO

INSERT INTO Habilidade (idTipoHabilidade, NomeHabilidade)
VALUES	(1, 'Lança Mortal')
		, (2, 'Escudo Supremo')
		, (3, 'Recuperar Vida')
;
GO

INSERT INTO HabilidadesClasse (idClasse, idHabilidade)
VALUES	(1, 1)
		, (1, 2)
		, (2, 2)
		, (3, 1)
		, (4, 3)
		, (4, 2)
		, (6, 3)
;
GO
		

-- 4. Atualizar o nome do personagem Fer8 para Fer7
UPDATE Personagem 
SET NomePersonagem = 'Fer7'
WHERE idPersonagem = 3
;
GO

-- 5. Atualizar o nome da classe de Necromante para Necromancer
UPDATE Classe
SET NomeClasse = 'Necromancer'
WHERE idClasse = 5
;
GO