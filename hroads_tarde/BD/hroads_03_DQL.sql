USE SENAI_HROADS_TARDE;

-- 6. Selecionar todos os personagens
SELECT * FROM Personagem;

-- 7. Selecionar todos as classes
SELECT * FROM Classe;

-- 8. Selecionar somente o nome das classes
SELECT Nome_da_Classe FROM Classe;

-- 9. Selecionar todas as habilidades
SELECT * FROM Habilidade;

-- 10. Realizar a contagem de quantas habilidades estão cadastradas
SELECT COUNT(idHabilidade) AS Numero_de_Habilidades_Cadastradas FROM Habilidade;

-- 11. Selecionar somente os id’s das habilidades classificando-os por ordem crescente
SELECT idHabilidade FROM Habilidade
ORDER BY idHabilidade ASC;

-- 12. Selecionar todos os tipos de habilidades
SELECT * FROM Tipo_de_Habilidade;

-- 13. Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte
SELECT Habilidade.Nome_Habilidade, Tipo_de_Habilidade.Tipo_de_Habilidade FROM Habilidade
INNER JOIN Tipo_de_Habilidade
ON Habilidade.idTipoHabilidade = Tipo_de_Habilidade.idTipoHabilidade;

-- 14. Selecionar todos os personagens e suas respectivas classes
SELECT Personagem.Nome_do_Personagem, Classe.Nome_da_Classe FROM Personagem
INNER JOIN Classe
ON Personagem.idClasse = Classe.idClasse;

-- 15. Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência em personagens)
SELECT Personagem.Nome_do_Personagem, Classe.Nome_da_Classe FROM Personagem
RIGHT JOIN Classe
ON Classe.idClasse = Personagem.idClasse
ORDER BY Personagem.Nome_do_Personagem DESC;

-- 16. Selecionar todas as classes e suas respectivas habilidades
SELECT Classe.Nome_da_Classe, Habilidade.Nome_Habilidade FROM Classe
LEFT JOIN Habilidades_da_Classe
ON Classe.idClasse = Habilidades_da_Classe.idClasse
LEFT JOIN Habilidade
ON Habilidades_da_Classe.idHabilidade = Habilidade.idHabilidade;

-- 17. Selecionar todas as habilidades e suas classes (somente as que possuem correspondência)
SELECT Habilidade.Nome_Habilidade, Classe.Nome_da_Classe FROM Habilidade
LEFT JOIN Habilidades_da_Classe
ON Habilidade.idHabilidade = Habilidades_da_Classe.idHabilidade
LEFT JOIN Classe
ON Habilidades_da_Classe.idClasse = Classe.idClasse;

-- 18. Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência)
SELECT Habilidade.Nome_Habilidade, Classe.Nome_da_Classe FROM Habilidade
RIGHT JOIN Habilidades_da_Classe
ON Habilidade.idHabilidade = Habilidades_da_Classe.idHabilidade
RIGHT JOIN Classe
ON Habilidades_da_Classe.idClasse = Classe.idClasse
ORDER BY Nome_Habilidade DESC;