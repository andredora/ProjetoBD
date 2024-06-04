CREATE OR ALTER TRIGGER trg_delete_Traje
ON Traje
INSTEAD OF DELETE
AS
BEGIN
    DELETE FROM Peca_do_Traje_Comprada
    WHERE ID_Traje IN (SELECT ID FROM DELETED);

    DELETE FROM Artigo_Academico_Comprado
    WHERE ID_Traje IN (SELECT ID FROM DELETED);

    DELETE FROM Traje WHERE ID IN (SELECT ID FROM DELETED);
END;
GO

-- TRIGGERS MEGA GOSTOSOES

CREATE OR ALTER TRIGGER trg_add_remove_peca
ON peca_do_traje_comprada
AFTER INSERT, DELETE
AS
BEGIN
    DECLARE @ID_Traje CHAR(6);
    DECLARE @ID_Peca CHAR(6);

    -- insert case
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        SELECT @ID_Traje = ID_Traje, @ID_Peca = ID_Peca FROM inserted;

        -- Increment Num_Pecas in Traje 
        UPDATE Traje
        SET Num_Pecas = Num_Pecas + 1
        WHERE ID = @ID_Traje;

        -- Decrement Quantidade in Peca_do_Traje 
        UPDATE Peca_do_Traje
        SET Quantidade = Quantidade - 1
        WHERE ID = @ID_Peca;
    END

    -- delete case
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        SELECT @ID_Traje = ID_Traje, @ID_Peca = ID_Peca FROM deleted;

        -- Decrement Num_Pecas in Traje 
        UPDATE Traje
        SET Num_Pecas = Num_Pecas - 1
        WHERE ID = @ID_Traje;

        -- Increment Quantidade in Peca_do_Traje 
        UPDATE Peca_do_Traje
        SET Quantidade = Quantidade + 1
        WHERE ID = @ID_Peca;
    END
END;
GO


CREATE OR ALTER TRIGGER trg_add_remove_acessorio
ON artigo_academico_comprado
AFTER INSERT, DELETE
AS
BEGIN
    DECLARE @ID_Traje CHAR(6);
    DECLARE @ID_Artigo CHAR(6);

    -- insert case
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        SELECT @ID_Traje = ID_Traje, @ID_Artigo = ID_Artigo FROM inserted;

        -- Increment Num_Acessorios in Traje 
        UPDATE Traje
        SET Num_Acessorios = Num_Acessorios + 1
        WHERE ID = @ID_Traje;

        -- Decrement Quantidade in Artigo_Academico 
        UPDATE Artigo_Academico
        SET Quantidade = Quantidade - 1
        WHERE ID = @ID_Artigo;
    END

    -- delete case
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        SELECT @ID_Traje = ID_Traje, @ID_Artigo = ID_Artigo FROM deleted;

        -- Decrement Num_Acessorios in Traje 
        UPDATE Traje
        SET Num_Acessorios = Num_Acessorios - 1
        WHERE ID = @ID_Traje;

        -- Increment Quantidade in Artigo_Academico 
        UPDATE Artigo_Academico
        SET Quantidade = Quantidade + 1
        WHERE ID = @ID_Artigo;
    END
END;
GO


CREATE OR ALTER TRIGGER trg_delete_traje_artigos
ON Traje
AFTER DELETE
AS
BEGIN
    DECLARE @ID_Traje CHAR(6);

    SELECT @ID_Traje = ID FROM deleted;

    IF @@ROWCOUNT > 0
    BEGIN
        UPDATE Artigo_Academico
        SET Quantidade = Quantidade + 1
        FROM Artigo_Academico_Comprado AS AAC
        INNER JOIN Artigo_Academico AS AA ON AAC.ID_Artigo = AA.ID
        WHERE AAC.ID_Traje = @ID_Traje;

  
    END;
END;
GO

CREATE OR ALTER TRIGGER trg_delete_traje_peca
ON Traje
AFTER DELETE
AS
BEGIN
    DECLARE @ID_Traje CHAR(6);

    SELECT @ID_Traje = ID FROM deleted;

    IF @@ROWCOUNT > 0
    BEGIN
        UPDATE Peca_Do_Traje
        SET Quantidade = Quantidade + 1
        FROM Peca_Do_Traje_Comprada AS PDTC 
        INNER JOIN Peca_Do_Traje AS PDT ON PDTC.ID_Peca = PDT.ID
        WHERE PDTC.ID_Traje = @ID_Traje;

    END;
END;