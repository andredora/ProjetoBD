-- adicionar o chapeu
CREATE OR ALTER PROCEDURE AddChapeu
    @Nome VARCHAR(60),
    @Quantidade INT,
    @End_Loja VARCHAR(60),
    @Universidade VARCHAR(60)
AS
BEGIN
    DECLARE @LetraLoja CHAR(1);
    DECLARE @NovoID VARCHAR(6);
    DECLARE @IDExistente CHAR(6);
    DECLARE @IDBase VARCHAR(5);
    DECLARE @Count INT;
    DECLARE @Exists INT;

    -- Inicializar o contador
    SET @Count = 1;

    -- Obter a letra da loja
    SELECT @LetraLoja = Letra FROM Loja WHERE Endereco = @End_Loja;

    IF @LetraLoja IS NULL
    BEGIN
        RAISERROR('Endere�o da loja n�o encontrado.', 16, 1);
        RETURN;
    END

    -- Gerar o ID base
    SET @IDBase = 'A' + @LetraLoja + 'C';

    WHILE 1 = 1
    BEGIN
        -- Calcular o pr�ximo ID
        SET @NovoID = @IDBase + RIGHT('000' + CAST(@Count AS VARCHAR(3)), 3);

        -- Verificar se o ID j� existe
        SELECT @Exists = COUNT(*) FROM Artigo_Academico WHERE ID = @NovoID;

        -- Se o ID n�o existir, sair do loop
        IF @Exists = 0
            BREAK;

        -- Incrementar o contador
        SET @Count = @Count + 1;
    END

    -- Inserir no Artigo_Academico
    INSERT INTO Artigo_Academico (ID, Nome, Quantidade, End_Loja)
    VALUES (@NovoID, @Nome, @Quantidade, @End_Loja);

    -- Inserir no Chapeu
    INSERT INTO Chapeu (ID, Universidade)
    VALUES (@NovoID, @Universidade);
END;
GO


-- adicionar emblema
CREATE OR ALTER PROCEDURE AddEmblema
    @Nome VARCHAR(60),
    @Quantidade INT,
    @End_Loja VARCHAR(60),
    @Forma VARCHAR(16),
    @Tipo VARCHAR(16)
AS
BEGIN
    DECLARE @LetraLoja CHAR(1);
    DECLARE @NovoID VARCHAR(6);
    DECLARE @Exists INT;
    DECLARE @Contador INT;
    DECLARE @IDBase VARCHAR(5);
	
	
	SET @Contador = 1;
    -- Obter a letra da loja
    SELECT @LetraLoja = Letra FROM Loja WHERE Endereco = @End_Loja;

    IF @LetraLoja IS NULL
    BEGIN
        RAISERROR('Endere�o da loja n�o encontrado.', 16, 1);
        RETURN;
    END

    -- Gerar o ID base
    SET @IDBase = 'A' + @LetraLoja + 'E';

    WHILE 1 = 1
    BEGIN
        -- Calcular o pr�ximo ID
        SET @NovoID = @IDBase + RIGHT('000' + CAST(@Contador AS VARCHAR(3)), 3);

        -- Verificar se o ID j� existe
        SELECT @Exists = COUNT(*) FROM Artigo_Academico WHERE ID = @NovoID;

        -- Se o ID n�o existir, sair do loop
        IF @Exists = 0
            BREAK;

        -- Incrementar o contador
        SET @Contador = @Contador + 1;
    END

    -- Inserir no Artigo_Academico
    INSERT INTO Artigo_Academico (ID, Nome, Quantidade, End_Loja)
    VALUES (@NovoID, @Nome, @Quantidade, @End_Loja);

    -- Inserir no Emblema
    INSERT INTO Emblema (ID, Forma, Tipo)
    VALUES (@NovoID, @Forma, @Tipo);
END;
GO

-- adicionar pin
CREATE OR ALTER PROCEDURE AddPin
    @Nome VARCHAR(60),
    @Quantidade INT,
    @End_Loja VARCHAR(60),
    @Tipo VARCHAR(16)
AS
BEGIN
    DECLARE @LetraLoja CHAR(1);
    DECLARE @NovoID VARCHAR(6);
    DECLARE @Exists INT;
    DECLARE @Contador INT = 1;
    DECLARE @IDBase VARCHAR(5);

    -- Obter a letra da loja
    SELECT @LetraLoja = Letra FROM Loja WHERE Endereco = @End_Loja;

    IF @LetraLoja IS NULL
    BEGIN
        RAISERROR('Endere�o da loja n�o encontrado.', 16, 1);
        RETURN;
    END

    -- Gerar o ID base
    SET @IDBase = 'A' + @LetraLoja + 'P';

    WHILE 1 = 1
    BEGIN
        -- Calcular o pr�ximo ID
        SET @NovoID = @IDBase + RIGHT('000' + CAST(@Contador AS VARCHAR(3)), 3);

        -- Verificar se o ID j� existe
        SELECT @Exists = COUNT(*) FROM Artigo_Academico WHERE ID = @NovoID;

        -- Se o ID n�o existir, sair do loop
        IF @Exists = 0
            BREAK;

        -- Incrementar o contador
        SET @Contador = @Contador + 1;
    END

    -- Inserir no Artigo_Academico
    INSERT INTO Artigo_Academico (ID, Nome, Quantidade, End_Loja)
    VALUES (@NovoID, @Nome, @Quantidade, @End_Loja);

    -- Inserir no Pin
    INSERT INTO Pin (ID, Tipo)
    VALUES (@NovoID, @Tipo);
END;
GO

-- adicionar pasta
CREATE OR ALTER PROCEDURE AddPasta
    @Nome VARCHAR(60),
    @Quantidade INT,
    @End_Loja VARCHAR(60),
    @Universidade VARCHAR(32)
AS
BEGIN
    DECLARE @LetraLoja CHAR(1);
    DECLARE @NovoID VARCHAR(6);
    DECLARE @Exists INT;
    DECLARE @Contador INT = 1;
    DECLARE @IDBase VARCHAR(5);

    -- Obter a letra da loja
    SELECT @LetraLoja = Letra FROM Loja WHERE Endereco = @End_Loja;

    IF @LetraLoja IS NULL
    BEGIN
        RAISERROR('Endere�o da loja n�o encontrado.', 16, 1);
        RETURN;
    END

    -- Gerar o ID base
    SET @IDBase = 'A' + @LetraLoja + 'T';

    WHILE 1 = 1
    BEGIN
        -- Calcular o pr�ximo ID
        SET @NovoID = @IDBase + RIGHT('000' + CAST(@Contador AS VARCHAR(3)), 3);

           -- Verificar se o ID j� existe
        SELECT @Exists = COUNT(*) FROM Artigo_Academico WHERE ID = @NovoID;

        -- Se o ID n�o existir, sair do loop
        IF @Exists = 0
            BREAK;

        -- Incrementar o contador
        SET @Contador = @Contador + 1;
    END

    -- Inserir no Artigo_Academico
    INSERT INTO Artigo_Academico (ID, Nome, Quantidade, End_Loja)
    VALUES (@NovoID, @Nome, @Quantidade, @End_Loja);

   -- Inserir na Pasta
    INSERT INTO Pasta (ID, Universidade)
    VALUES (@NovoID, @Universidade);
END;
GO



-- adicionar NO
CREATE OR ALTER PROCEDURE AddNo
    @Nome VARCHAR(60),
    @Quantidade INT,
    @End_Loja VARCHAR(60),
    @Cor1 VARCHAR(16),
    @Cor2 VARCHAR(16),
    @Tipo VARCHAR(16)
AS
BEGIN
    DECLARE @LetraLoja CHAR(1);
    DECLARE @NovoID VARCHAR(6);
    DECLARE @Exists INT;
    DECLARE @Contador INT = 1;
    DECLARE @IDBase VARCHAR(5);
	

    -- Obter a letra da loja
    SELECT @LetraLoja = Letra FROM Loja WHERE Endereco = @End_Loja;

    IF @LetraLoja IS NULL
    BEGIN
        RAISERROR('Endere�o da loja n�o encontrado.', 16, 1);
        RETURN;
    END

    -- Gerar o ID base
    SET @IDBase = 'A' + @LetraLoja + 'N';

    WHILE 1 = 1
    BEGIN
        -- Calcular o pr�ximo ID
        SET @NovoID = @IDBase + RIGHT('000' + CAST(@Contador AS VARCHAR(3)), 3);

        -- Verificar se o ID j� existe
        SELECT @Exists = COUNT(*) FROM Artigo_Academico WHERE ID = @NovoID;

        -- Se o ID n�o existir, sair do loop
        IF @Exists = 0
            BREAK;

        -- Incrementar o contador
        SET @Contador = @Contador + 1;
    END

    -- Verificar se o contador ultrapassou o limite
    IF @Contador > 999
    BEGIN
        RAISERROR('N�o foi poss�vel gerar um novo ID. Limite atingido.', 16, 1);
        RETURN;
    END

    -- Inserir no Artigo_Academico
    INSERT INTO Artigo_Academico (ID, Nome, Quantidade, End_Loja)
    VALUES (@NovoID, @Nome, @Quantidade, @End_Loja);

    -- Inserir no NoA
    INSERT INTO NoA (ID, Cor1, Cor2, Tipo)
    VALUES (@NovoID, @Cor1, @Cor2, @Tipo);
END;
GO


-- adicionar um lapis
CREATE OR ALTER PROCEDURE AddLapis
    @Nome VARCHAR(60),
    @Quantidade INT,
	@Marca VARCHAR(60),
    @End_Loja VARCHAR(60),
    @Dureza VARCHAR(2)
	
AS
BEGIN
    DECLARE @LetraLoja CHAR(1);
    DECLARE @NovoID VARCHAR(6);
    DECLARE @IDExistente CHAR(6);
    DECLARE @IDBase VARCHAR(5);
    DECLARE @Count INT;
    DECLARE @Exists INT;

    -- Inicializar o contador
    SET @Count = 1;

    -- Obter a letra da loja
    SELECT @LetraLoja = Letra FROM Loja WHERE Endereco = @End_Loja;

    IF @LetraLoja IS NULL
    BEGIN
        RAISERROR('Endere�o da loja n�o encontrado.', 16, 1);
        RETURN;
    END

    -- Gerar o ID base
    SET @IDBase = 'P' + @LetraLoja + 'L';

    WHILE 1 = 1
    BEGIN
        -- Calcular o pr�ximo ID
        SET @NovoID = @IDBase + RIGHT('000' + CAST(@Count AS VARCHAR(3)), 3);

        -- Verificar se o ID j� existe
        SELECT @Exists = COUNT(*) FROM Artigo_Papelaria WHERE ID = @NovoID;

        -- Se o ID n�o existir, sair do loop
        IF @Exists = 0
            BREAK;

        -- Incrementar o contador
        SET @Count = @Count + 1;
    END

    -- Inserir no Artigo
    INSERT INTO Artigo_Papelaria (ID, Nome, Quantidade, Marca, End_Loja)
    VALUES (@NovoID, @Nome, @Quantidade, @Marca, @End_Loja);

    -- Inserir no Lapis
    INSERT INTO Lapis (ID, Dureza)
    VALUES (@NovoID, @Dureza);
END;
GO




	-- adicionar uma caneta
CREATE OR ALTER PROCEDURE AddCaneta
    @Nome VARCHAR(60),
    @Quantidade INT,
	@Marca VARCHAR(60),
    @End_Loja VARCHAR(60),
    @Cor VARCHAR(16),
	@Tipo VARCHAR(30)
	
AS
BEGIN
    DECLARE @LetraLoja CHAR(1);
    DECLARE @NovoID VARCHAR(6);
    DECLARE @IDExistente CHAR(6);
    DECLARE @IDBase VARCHAR(5);
    DECLARE @Count INT;
    DECLARE @Exists INT;

    -- Inicializar o contador
    SET @Count = 1;

    -- Obter a letra da loja
    SELECT @LetraLoja = Letra FROM Loja WHERE Endereco = @End_Loja;

    IF @LetraLoja IS NULL
    BEGIN
        RAISERROR('Endere�o da loja n�o encontrado.', 16, 1);
        RETURN;
    END

    -- Gerar o ID base
    SET @IDBase = 'P' + @LetraLoja + 'C';

    WHILE 1 = 1
    BEGIN
        -- Calcular o pr�ximo ID
        SET @NovoID = @IDBase + RIGHT('000' + CAST(@Count AS VARCHAR(3)), 3);

        -- Verificar se o ID j� existe
        SELECT @Exists = COUNT(*) FROM Artigo_Papelaria WHERE ID = @NovoID;

        -- Se o ID n�o existir, sair do loop
        IF @Exists = 0
            BREAK;

        -- Incrementar o contador
        SET @Count = @Count + 1;
    END

    -- Inserir no Artigo
    INSERT INTO Artigo_Papelaria (ID, Nome, Quantidade, Marca, End_Loja)
    VALUES (@NovoID, @Nome, @Quantidade, @Marca, @End_Loja);

    -- Inserir na caneta
    INSERT INTO Caneta (ID, Tipo, Cor)
    VALUES (@NovoID, @Tipo, @Cor);
END;
GO

--adicionar traje
CREATE OR ALTER PROCEDURE AddTraje
    @Nome VARCHAR(60),
    @End_Loja VARCHAR(60)
AS
BEGIN
    DECLARE @NewID CHAR(6);
    DECLARE @Count INT;
    DECLARE @Exists INT;

    -- Inicializar o contador
    SET @Count = 1;

    -- Loop para encontrar um ID dispon�vel
    WHILE 1 = 1
    BEGIN
        -- Calcular o pr�ximo ID
        SET @NewID = 'T' + RIGHT('0000' + CAST(@Count AS VARCHAR(5)), 5);

        -- Verificar se o ID j� existe
        SELECT @Exists = COUNT(*) FROM Traje WHERE ID = @NewID;

        -- Se o ID n�o existir, sair do loop
        IF @Exists = 0
            BREAK;

        -- Incrementar o contador
        SET @Count = @Count + 1;
    END

    -- Inserir o novo traje
    INSERT INTO Traje (ID, Nome, Num_Acessorios, Num_Pecas, Completo, End_Loja)
    VALUES (@NewID, @Nome, 0, 0, 0, @End_Loja);
END;
GO

--procedure para comprar peca e ela ser adicionada ao traje
-- ela depois � adicionada por causa do trigger
CREATE OR ALTER PROCEDURE ComprarPeca
    @IDPECA VARCHAR(6),
    @IDTRAJE VARCHAR(6)
AS
BEGIN
    INSERT INTO peca_do_traje_comprada (ID_peca, ID_traje)
    VALUES (@IDPECA, @IDTRAJE);

END;
GO
--procedure para ocmprar um artigo academico e adicionar ao traje
-- ele depois � adicionado por causa do trigger
CREATE OR ALTER PROCEDURE ComprarArtigo
    @IDARTIGO VARCHAR(6),
    @IDTRAJE VARCHAR(6)
AS
BEGIN
    -- Inserir no Artigo_Papelaria
    INSERT INTO artigo_academico_comprado (ID_artigo, ID_traje)
    VALUES (@IDARTIGO, @IDTRAJE);

END;
GO

CREATE OR ALTER PROCEDURE GetArtigosPorLoja
    @EnderecoLoja NVARCHAR(255)
AS
BEGIN
    SELECT * 
    FROM Artigo_Academico
    WHERE end_loja = @EnderecoLoja;
END
GO

CREATE OR ALTER PROCEDURE GetPapelariaPorLoja
    @EnderecoLoja NVARCHAR(255)
AS
BEGIN
    SELECT * 
    FROM Artigo_Papelaria
    WHERE end_loja = @EnderecoLoja;
END
GO

CREATE OR ALTER PROCEDURE GetLojasPapelaria
AS
BEGIN
    SELECT DISTINCT End_Loja FROM Artigo_Papelaria;
END
GO


CREATE OR ALTER PROCEDURE GetLojasAcademico
AS
BEGIN
    SELECT DISTINCT End_Loja FROM Artigo_Academico;
END
GO

-- Stored procedure para pesquisar artigos de papelaria
CREATE OR ALTER PROCEDURE PesquisarArtigosPapelaria
    @nome NVARCHAR(255)
AS
BEGIN
    SELECT ID, Nome FROM Artigo_Papelaria WHERE Nome LIKE '%' + @nome + '%'
END
GO


---- PARA DELETAR
CREATE OR ALTER PROCEDURE DeleteArtigo
    @IDARTIGO VARCHAR(6)
AS
BEGIN
    delete from artigo_academico where id=@IDARTIGO
END;
GO
-- depois o trigger trata de remover do traje (se for o caso)



CREATE OR ALTER PROCEDURE DeletePapelaria
    @IDPAPEL VARCHAR(6)
AS
BEGIN
    delete from artigo_papelaria where id=@IDPAPEL
END;
GO



CREATE OR ALTER PROCEDURE DeletePeca
    @IDPECA VARCHAR(6)
AS
BEGIN
    delete from peca_do_traje where id=@IDPECA
END;
GO
-- depois o trigger trata de remover do traje (se for o caso)



CREATE PROCEDURE AlterarPecaDoTraje 
    @pecaID CHAR(6),
    @novoNome VARCHAR(60),
    @novoTamanho VARCHAR(3),
    @novaUniversidade VARCHAR(32),
    @novaQuantidade INT,
    @novoGenero VARCHAR(1)
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE Peca_do_Traje
    SET Nome = @novoNome,
        Tamanho = @novoTamanho,
        Universidade = @novaUniversidade,
        Quantidade = @novaQuantidade,
        Genero = @novoGenero
    WHERE ID = @pecaID;
END;
GO