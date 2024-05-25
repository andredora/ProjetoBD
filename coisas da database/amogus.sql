drop procedure GetChapeuDetalhes;
drop procedure GetEmblemaDetalhes;
drop procedure GetNoDetalhes;
drop procedure GetPastaDetalhes;
drop procedure GetPinDetalhes;

-- Stored procedure para obter detalhes de Emblemas
CREATE PROCEDURE GetEmblemaDetalhes
    @id CHAR(6)
AS
BEGIN
    SELECT Forma, Tipo 
    FROM Emblema
    WHERE ID = @id;
END;

-- Stored procedure para obter detalhes de Pins
CREATE PROCEDURE GetPinDetalhes
    @id CHAR(6)
AS
BEGIN
    SELECT Tipo 
    FROM Pin
    WHERE ID = @id;
END;

-- Stored procedure para obter detalhes de Pastas
CREATE PROCEDURE GetPastaDetalhes
    @id CHAR(6)
AS
BEGIN
    SELECT Tipo 
    FROM Pasta
    WHERE ID = @id;
END;

-- Stored procedure para obter detalhes de Chapeus
CREATE PROCEDURE GetChapeuDetalhes
    @id CHAR(6)
AS
BEGIN
    SELECT Universidade 
    FROM Chapeu
    WHERE ID = @id;
END;

-- Stored procedure para obter detalhes de Nós
CREATE PROCEDURE GetNoDetalhes
    @id CHAR(6)
AS
BEGIN
    SELECT Tipo, Cor1, Cor2 
    FROM NoA
    WHERE ID = @id;
END;