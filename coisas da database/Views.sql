CREATE VIEW ArtigosAcademicoView AS
SELECT ID, Nome
FROM Artigo_Academico;

CREATE VIEW ArtigosPapelariaView AS
SELECT ID, Nome
FROM Artigo_Papelaria;

CREATE VIEW EmblemaDetalhesview AS
SELECT ID, Forma, Tipo 
FROM Emblema;

CREATE VIEW PinDetalhes AS
SELECT ID, Tipo
FROM Pin;

CREATE VIEW PastaDetalhes AS
SELECT ID, Universidade
FROM Pasta;

CREATE VIEW ChapeuDetalhes AS
SELECT ID, Universidade
FROM Chapeu;

CREATE VIEW NoDetalhes AS
SELECT ID, Tipo, Cor1, Cor2
FROM NoA;

CREATE VIEW ArtigoPapelariaDetalhesView AS
SELECT ID, Marca, Quantidade, End_Loja
FROM Artigo_Papelaria;

CREATE VIEW CanetaDetalhesView AS
SELECT ID, Tipo, Cor
FROM Caneta;

CREATE VIEW LapisDetalhesView AS
SELECT ID, Dureza
FROM Lapis;