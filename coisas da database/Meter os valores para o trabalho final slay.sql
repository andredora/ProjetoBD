insert into Loja (endereco, nome, telefone) values
('Rachel Street, N.o 2, Aveiro', 'Rachel Trajes Inc.', 988123987),
('Rua do Silencio, N.o 4, Aveiro', 'Trajes Rikka e Etc', 982738182);



/*
CREATE TABLE Peca_do_Traje (
ID CHAR(6) PRIMARY KEY ,
	Nome VARCHAR(30) NOT NULL,
	Tamanho VARCHAR(3) NOT NULL,
	Tipo VARCHAR(3) NOT NULL,
	End_Loja VARCHAR(60) FOREIGN KEY REFERENCES Loja (Endereco),
	Genero VARCHAR(1) NOT NULL,
*/


insert into Peca_Do_Traje (ID, Nome, Tamanho, Universidade, End_Loja, Quantidade, Genero) values
-- ('Rachel Street, N.o 2, Aveiro', 'Rachel Trajes Inc.', 988123987)
('PT0001', 'Calcas', '36', 'Universidade De Aveiro', 'Rachel Street, N.o 2, Aveiro', 10, 'M'),
('PT0002', 'Calcas', '38', 'Universidade De Aveiro', 'Rachel Street, N.o 2, Aveiro', 9, 'M'),
('PT0003', 'Calcas', '40', 'Universidade De Aveiro', 'Rachel Street, N.o 2, Aveiro', 7, 'M'),
('PT0004', 'Saia', '36', 'Universidade De Aveiro', 'Rachel Street, N.o 2, Aveiro', 2, 'F'),
('PT0005', 'Saia', '38', 'Universidade De Aveiro', 'Rachel Street, N.o 2, Aveiro', 8, 'F'),
('PT0006', 'Saia', '40', 'Universidade De Aveiro', 'Rachel Street, N.o 2, Aveiro', 5, 'F'),
('PT0007', 'Camisa Masculina', 'S', 'Geral', 'Rachel Street, N.o 2, Aveiro', 20, 'M'),
('PT0008', 'Camisa Masculina', 'M', 'Geral', 'Rachel Street, N.o 2, Aveiro', 15, 'M'),
('PT0009', 'Camisa Masculina', 'L', 'Geral', 'Rachel Street, N.o 2, Aveiro', 7, 'M'),
('PT0010', 'Camisa Feminina', 'S', 'Geral', 'Rachel Street, N.o 2, Aveiro', 12, 'F'),
('PT0011', 'Camisa Feminina', 'M', 'Geral', 'Rachel Street, N.o 2, Aveiro', 20, 'F'),
('PT0012', 'Camisa Feminina', 'L', 'Geral', 'Rachel Street, N.o 2, Aveiro', 36, 'F'),
('PT0013', 'Casaco Masculino', '36', 'Universidade De Aveiro', 'Rachel Street, N.o 2, Aveiro', 11, 'M'),
('PT0014', 'Casaco Masculino', '38', 'Universidade De Aveiro', 'Rachel Street, N.o 2, Aveiro', 9, 'M'),
('PT0015', 'Casaco Masculino', '40', 'Universidade De Aveiro', 'Rachel Street, N.o 2, Aveiro', 7, 'M'),
('PT0016', 'Casaco Feminino', '36', 'Universidade De Aveiro', 'Rachel Street, N.o 2, Aveiro', 12, 'F'),
('PT0017', 'Casaco Feminino', '38', 'Universidade De Aveiro', 'Rachel Street, N.o 2, Aveiro', 13, 'F'),
('PT0018', 'Casaco Feminino', '40', 'Universidade De Aveiro', 'Rachel Street, N.o 2, Aveiro', 12, 'F'),
('PT0019', 'Colete Masculino', '36', 'Universidade De Aveiro', 'Rachel Street, N.o 2, Aveiro', 10, 'M'),
('PT0020', 'Colete Masculino', '38', 'Universidade De Aveiro', 'Rachel Street, N.o 2, Aveiro', 9, 'M'),
('PT0021', 'Colete Masculino', '40', 'Universidade De Aveiro', 'Rachel Street, N.o 2, Aveiro', 8, 'M'),
('PT0022', 'Colete Feminino', '36', 'Universidade De Aveiro', 'Rachel Street, N.o 2, Aveiro', 9, 'F'),
('PT0023', 'Colete Feminino', '38', 'Universidade De Aveiro', 'Rachel Street, N.o 2, Aveiro', 8, 'F'),
('PT0024', 'Colete Feminino', '40', 'Universidade De Aveiro', 'Rachel Street, N.o 2, Aveiro', 17, 'F'),
('PT0025', 'Gravata', 'UNQ', 'Universidade de Aveiro', 'Rachel Street, N.o 2, Aveiro', 20, 'M'),
('PT0026', 'Laco', 'UNQ', 'Universidade de Aveiro', 'Rachel Street, N.o 2, Aveiro', 15, 'F'),
('PT0027', 'Meias Pretas', '39', 'Geral', 'Rachel Street, N.o 2, Aveiro', 63, 'M'),
('PT0028', 'Meias Pretas', '41', 'Geral', 'Rachel Street, N.o 2, Aveiro', 44, 'M'),
('PT0029', 'Collants', 'S', 'Universidade de Aveiro', 'Rachel Street, N.o 2, Aveiro', 41, 'F'),
('PT0030', 'Collants', 'M', 'Universidade de Aveiro', 'Rachel Street, N.o 2, Aveiro', 23, 'F'),
('PT0031', 'Collants', 'L', 'Universidade de Aveiro', 'Rachel Street, N.o 2, Aveiro', 33, 'F'),
('PT0032', 'Gabao', 'S', 'Universidade de Aveiro', 'Rachel Street, N.o 2, Aveiro', 31, 'N'),
('PT0033', 'Gabao', 'L', 'Universidade de Aveiro', 'Rachel Street, N.o 2, Aveiro', 30, 'N'),
('PT0034', 'Calcas', '36', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 11, 'M'),
('PT0035', 'Calcas', '38', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 12, 'M'),
('PT0036', 'Calcas', '40', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 3, 'M'),
('PT0037', 'Saia', '36', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 4, 'F'),
('PT0038', 'Saia', '38', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 5, 'F'),
('PT0039', 'Saia', '40', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 6, 'F'),
('PT0040', 'Casaco Masculino', '36', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 1, 'M'),
('PT0041', 'Casaco Masculino', '38', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 14, 'M'),
('PT0042', 'Casaco Masculino', '40', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 3, 'M'),
('PT0043', 'Casaco Feminino', '36', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 7, 'F'),
('PT0044', 'Casaco Feminino', '38', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 10, 'F'),
('PT0045', 'Casaco Feminino', '40', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 2, 'F'),
('PT0046', 'Colete Masculino', '36', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 3, 'M'),
('PT0047', 'Colete Masculino', '38', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 4, 'M'),
('PT0048', 'Colete Masculino', '40', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 5, 'M'),
('PT0049', 'Batina', '36', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 6, 'M'),
('PT0050', 'Batina', '38', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 7, 'M'),
('PT0051', 'Batina', '40', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 8, 'M'),
('PT0052', 'Gravata', 'UNQ', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 7, 'N'),
('PT0053', 'Collants', 'S', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 13, 'F'),
('PT0054', 'Collants', 'M', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 14, 'F'),
('PT0055', 'Collants', 'L', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 15, 'F'),
('PT0056', 'Capa', 'S', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 6, 'N'),
('PT0057', 'Capa', 'M', 'Universidade Do Porto', 'Rachel Street, N.o 2, Aveiro', 8, 'N'),
--('Rua do Silencio, N.o 4, Aveiro', 'Trajes Rikka e Etc', 9827'38'1821)
('PT0058', 'Calcas', '36', 'Universidade De Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 22, 'M'),
('PT0059', 'Calcas', '38', 'Universidade De Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 12, 'M'),
('PT0060', 'Calcas', '40', 'Universidade De Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 17, 'M'),
('PT0061', 'Saia', '36', 'Universidade De Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 12, 'F'),
('PT0062', 'Saia', '38', 'Universidade De Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 18, 'F'),
('PT0063', 'Saia', '40', 'Universidade De Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 15, 'F'),
('PT0064', 'Camisa Masculina', 'S', 'Geral', 'Rua do Silencio, N.o 4, Aveiro', 19, 'M'),
('PT0065', 'Camisa Masculina', 'M', 'Geral', 'Rua do Silencio, N.o 4, Aveiro', 41, 'M'),
('PT0066', 'Camisa Masculina', 'L', 'Geral', 'Rua do Silencio, N.o 4, Aveiro', 17, 'M'),
('PT0067', 'Camisa Feminina', 'S', 'Geral', 'Rua do Silencio, N.o 4, Aveiro', 22, 'F'),
('PT0068', 'Camisa Feminina', 'M', 'Geral', 'Rua do Silencio, N.o 4, Aveiro', 23, 'F'),
('PT0069', 'Camisa Feminina', 'L', 'Geral', 'Rua do Silencio, N.o 4, Aveiro', 36, 'F'),
('PT0070', 'Casaco Masculino', '36', 'Universidade De Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 18, 'M'),
('PT0071', 'Casaco Masculino', '38', 'Universidade De Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 11, 'M'),
('PT0072', 'Casaco Masculino', '40', 'Universidade De Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 17, 'M'),
('PT0073', 'Casaco Feminino', '36', 'Universidade De Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 19, 'F'),
('PT0074', 'Casaco Feminino', '38', 'Universidade De Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 19, 'F'),
('PT0075', 'Casaco Feminino', '40', 'Universidade De Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 18, 'F'),
('PT0076', 'Colete Masculino', '36', 'Universidade De Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 19, 'M'),
('PT0077', 'Colete Masculino', '38', 'Universidade De Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 19, 'M'),
('PT0078', 'Colete Masculino', '40', 'Universidade De Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 18, 'M'),
('PT0079', 'Colete Feminino', '36', 'Universidade De Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 20, 'F'),
('PT0080', 'Colete Feminino', '38', 'Universidade De Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 12, 'F'),
('PT0081', 'Colete Feminino', '40', 'Universidade De Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 22, 'F'),
('PT0082', 'Gravata', 'UNQ', 'Universidade de Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 40, 'M'),
('PT0083', 'Laco', 'UNQ', 'Universidade de Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 25, 'F'),
('PT0084', 'Meias Pretas', '39', 'Geral', 'Rua do Silencio, N.o 4, Aveiro', 50, 'M'),
('PT0085', 'Meias Pretas', '41', 'Geral', 'Rua do Silencio, N.o 4, Aveiro', 45, 'M'),
('PT0086', 'Collants', 'S', 'Universidade de Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 44, 'F'),
('PT0087', 'Collants', 'M', 'Universidade de Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 30, 'F'),
('PT0088', 'Collants', 'L', 'Universidade de Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 45, 'F'),
('PT0089', 'Gabao', 'S', 'Universidade de Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 50, 'N'),
('PT0090', 'Gabao', 'M', 'Universidade de Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 44, 'N'),
('PT0091', 'Gabao', 'L', 'Universidade de Aveiro', 'Rua do Silencio, N.o 4, Aveiro', 33, 'N');


/*
CREATE TABLE Artigo_Academico (
	ID CHAR(6) PRIMARY KEY ,
	Nome VARCHAR(30) NOT NULL,
	Quantidade int NOT NULL,
	End_Loja VARCHAR(60) FOREIGN KEY REFERENCES Loja (Endereco),

)
*/

insert into Artigo_Academico (ID, Nome, Quantidade, End_Loja) values
-- emblemas rachel street (ARE - ARTIGO RACHEL EMBLEMA)
-- tipo: universidades (1 - 2)
('ARE001', 'Emblema Universidade de Aveiro', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE002', 'Emblema Universidade do Porto', 100, 'Rachel Street, N.o 2, Aveiro'),
-- tipo: aauav (3)
('ARE003', 'Emblema Aauav', 100, 'Rachel Street, N.o 2, Aveiro'),
-- tipo: cursos (4 -21)
('ARE004', 'Emblema Engenharia Mecanica', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE005', 'Emblema Engenharia Informatica', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE006', 'Emblema Engenharia Civil', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE007', 'Emblema Engenharia Biomedica', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE008', 'Emblema Engenharia de Materiais', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE009', 'Emblema Engenharia e Gestao Industrial', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE010', 'Emblema Engenharia do Ambiente', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE011', 'Emblema Engenharia Quimica', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE012', 'Emblema Linguas e Relacoes Empresariais', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE013', 'Emblema Economia', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE014', 'Emblema Gestao', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE015', 'Emblema Biologia', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE016', 'Emblema Geologia', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE017', 'Emblema Matematica', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE018', 'Emblema Fisica', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE019', 'Emblema Quimica', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE020', 'Emblema Ciencias Biomedicas', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE021', 'Emblema Biotecnologia', 100, 'Rachel Street, N.o 2, Aveiro'),
-- tipo séries e desenhos animados (22 - 47)
('ARE022', 'Emblema Naruto', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE023', 'Emblema One Piece', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE024', 'Emblema Dragon Ball', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE025', 'Emblema Pokemon', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE026', 'Emblema Digimon', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE027', 'Emblema Bart Simpson', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE028', 'Emblema Homer Simpson', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE029', 'Emblema Marge Simpson', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE030', 'Emblema Lisa Simpson', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE031', 'Emblema Monstro das Bolachas', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE032', 'Emblema Pato Donald', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE033', 'Emblema Mickey Mouse', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE034', 'Emblema Minnie Mouse', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE035', 'Emblema Pateta', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE036', 'Emblema Rick and Morty', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE037', 'Emblema Powerpuff Girls', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE038', 'Emblema Euphoria', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE039', 'Emblema Game of Thrones', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE040', 'Emblema Breaking Bad: Jesse', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE041', 'Emblema Breaking Bad: Walter', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE042', 'Emblema Breaking Bad: Better Call Saul', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE043', 'Emblema FRIENDS', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE044', 'Emblema The Office', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE045', 'Emblema The Big Bang Theory', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE046', 'Emblema The 100', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE047', 'Emblema Stranger Things', 100, 'Rachel Street, N.o 2, Aveiro'),
-- tipo: super herois (48 - 62)
('ARE048', 'Emblema Batman', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE049', 'Emblema Super Homem', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE050', 'Emblema Mulher Maravilha', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE051', 'Emblema Flash', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE052', 'Emblema Aquaman', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE053', 'Emblema Lanterna Verde', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE054', 'Emblema Capitao America', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE055', 'Emblema Homem de Ferro', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE056', 'Emblema Hulk', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE057', 'Emblema Thor', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE058', 'Emblema Viuva Negra', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE059', 'Emblema Joker', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE060', 'Emblema Harley Quinn', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE061', 'Emblema Deadpool', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE062', 'Emblema Homem Aranha', 100, 'Rachel Street, N.o 2, Aveiro'),
-- tipo: comida (63 - 66)
('ARE063', 'Emblema Batata Frita', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE064', 'Emblema Hamburguer', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE065', 'Emblema Pizza', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE066', 'Emblema Sushi', 100, 'Rachel Street, N.o 2, Aveiro'),
-- tipo: harry potter	(67 - 73)
('ARE067', 'Emblema Gryffindor', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE068', 'Emblema Slytherin', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE069', 'Emblema Hufflepuff', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE070', 'Emblema Ravenclaw', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE071', 'Emblema Hogwarts', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE072', 'Emblema Harry Potter', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE073', 'Emblema Hermione', 100, 'Rachel Street, N.o 2, Aveiro'),
-- tipo: animais (74 - 81)
('ARE074', 'Emblema Gato', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE075', 'Emblema Cao', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE076', 'Emblema Peixe', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE077', 'Emblema Borboleta', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE078', 'Emblema Coelho', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE079', 'Emblema Vaca', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE080', 'Emblema Cavalo', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE081', 'Emblema Porco', 100, 'Rachel Street, N.o 2, Aveiro'),
-- tipo: signos (82 - 93)
('ARE082', 'Emblema Carneiro', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE083', 'Emblema Touro', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE084', 'Emblema Gemeos', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE085', 'Emblema Caranguejo', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE086', 'Emblema Leao', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE087', 'Emblema Virgem', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE088', 'Emblema Balanca', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE089', 'Emblema Escorpiao', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE090', 'Emblema Sagitario', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE091', 'Emblema Capricornio', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE092', 'Emblema Aquario', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE093', 'Emblema Peixes', 100, 'Rachel Street, N.o 2, Aveiro'),
-- tipo: cidades (94 - 112)
('ARE094', 'Emblema Aveiro', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE095', 'Emblema Beja', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE096', 'Emblema Braga', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE097', 'Emblema Bragança', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE098', 'Emblema Castelo Branco', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE099', 'Emblema Coimbra', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE100', 'Emblema Evora', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE101', 'Emblema Faro', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE102', 'Emblema Guarda', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE103', 'Emblema Leiria', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE104', 'Emblema Lisboa', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE105', 'Emblema Portalegre', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE106', 'Emblema Porto', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE107', 'Emblema Santarem', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE108', 'Emblema Setubal', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE109', 'Emblema Viana do Castelo', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE110', 'Emblema Vila Real', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE111', 'Emblema Viseu', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE112', 'Emblema Ribeira de Pena', 100, 'Rachel Street, N.o 2, Aveiro'),
-- tipo: paises e regioes (113 - 118)
('ARE113', 'Emblema Portugal', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE114', 'Emblema Espanha', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE115', 'Emblema Franca', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE116', 'Emblema Acores', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE117', 'Emblema Madeira', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE118', 'Emblema Brasil', 100, 'Rachel Street, N.o 2, Aveiro'),
-- tipo: familia (119 - 130)
('ARE119', 'Emblema da Mae', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE120', 'Emblema do Pai', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE121', 'Emblema da Irma', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE122', 'Emblema do Irmao', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE123', 'Emblema dos Avos', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE124', 'Emblema dos Tios', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE125', 'Emblema dos Primos', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE126', 'Emblema dos Sobrinhos', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE127', 'Emblema do Patrao', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE128', 'Emblema da Patroa', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE129', 'Emblema do Pedaco', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARE130', 'Emblema da Pedaco', 100, 'Rachel Street, N.o 2, Aveiro'),
-- pins rachel street (ARP - ARTIGO RACHEL PIN)
-- tipo: universidades (1-2)
('ARP001', 'Pin Universidade de Aveiro', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP002', 'Pin Universidade do Porto', 100, 'Rachel Street, N.o 2, Aveiro'),
-- tipo: aauav (3)
('ARP003', 'Pin Aauav', 100, 'Rachel Street, N.o 2, Aveiro'),
-- tipo: cursos (4 -21)
('ARP004', 'Pin Engenharia Mecanica', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP005', 'Pin Engenharia Informatica', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP006', 'Pin Engenharia Civil', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP007', 'Pin Engenharia Biomedica', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP008', 'Pin Engenharia de Materiais', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP009', 'Pin Engenharia e Gestao Industrial', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP010', 'Pin Engenharia do Ambiente', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP011', 'Pin Engenharia Quimica', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP012', 'Pin Linguas e Relacoes Empresariais', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP013', 'Pin Economia', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP014', 'Pin Gestao', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP015', 'Pin Biologia', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP016', 'Pin Geologia', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP017', 'Pin Matematica', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP018', 'Pin Fisica', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP019', 'Pin Quimica', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP020', 'Pin Ciencias Biomedicas', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP021', 'Pin Biotecnologia', 100, 'Rachel Street, N.o 2, Aveiro'),
--tipo: clubes (22 - 24)
('ARP022', 'Pin Benfica', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP023', 'Pin Sporting', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP024', 'Pin Porto', 100, 'Rachel Street, N.o 2, Aveiro'),
--tipo: animais (25-29)
('ARP025', 'Pin Gato', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP026', 'Pin Cao', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARP027', 'Pin Cavalo',  100, 'Rachel Street, N.o 2, Aveiro'),
('ARP028', 'Pin Tubarao',  100, 'Rachel Street, N.o 2, Aveiro'),
('ARP029', 'Pin Tigre',  100, 'Rachel Street, N.o 2, Aveiro'),
--tipo: jogos (30-32)
('ARP030', 'Pin Among Us',  100, 'Rachel Street, N.o 2, Aveiro'),
('ARP031', 'Pin Morgana',  100, 'Rachel Street, N.o 2, Aveiro'),
('ARP032', 'Pin City Skylines',  100, 'Rachel Street, N.o 2, Aveiro'),
-- Pastas rachel street (ART - ARTIGO RACHEL pasTas)
-- universidade: aveiro (1-3)
('ART001', 'Pasta Pele Fina Universidade de Aveiro', 100, 'Rachel Street, N.o 2, Aveiro'),
('ART002', 'Pasta Pele Grossa Universidade de Aveiro', 100, 'Rachel Street, N.o 2, Aveiro'),
('ART003', 'Pasta Premium Universidade de Aveiro', 100, 'Rachel Street, N.o 2, Aveiro'),
-- universidade: porto (4-6)
('ART004', 'Pasta Pele Fina Universidade do Porto', 100, 'Rachel Street, N.o 2, Aveiro'),
('ART005', 'Pasta Pele Grossa Universidade do Porto', 100, 'Rachel Street, N.o 2, Aveiro'),
('ART006', 'Pasta Premium Universidade do Porto', 100, 'Rachel Street, N.o 2, Aveiro'),
-- Chapeus rachel street (ARC - ARTIGO RACHEL CHAPEU)
-- universidade: aveiro (1-3)
('ARC001', 'Chapeu Masculino Universidade de Aveiro', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARC002', 'Chapeu com fita Masculino Universidade de Aveiro', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARC003', 'Chapeu Feminino Universidade de Aveiro', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARC004', 'Chapeu com fita Feminino Universidade de Aveiro', 100, 'Rachel Street, N.o 2, Aveiro'),
-- universidade: porto (4-6)
('ARC005', 'Chapeu Masculino Universidade do Porto', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARC006', 'Chapeu com fita Masculino Universidade do Porto', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARC007', 'Chapeu Feminino Universidade do Porto', 100, 'Rachel Street, N.o 2, Aveiro'),
('ARC008', 'Chapeu com fita Feminino Universidade do Porto', 100, 'Rachel Street, N.o 2, Aveiro'),
-- Nos rachel street (ARN - ARTIGO RACHEL NOS)
-- tipo: coxim redondo (1-3)
('ARN001', 'No Coxim Redondo Verde', 100, 'Rachel Street, N.o 2, Aveiro'), -- cor1: verde , cor2: null
('ARN002', 'No Coxim Redondo Castanho', 100, 'Rachel Street, N.o 2, Aveiro'), -- cor1: castanho , cor2: null
('ARN003', 'No Coxim Redondo Branco Cru', 100, 'Rachel Street, N.o 2, Aveiro'), -- cor1: branco , cor2: null
-- tipo : azelha (4-21)
('ARN004', 'No Engenharia Informatica', 100, 'Rachel Street, N.o 2, Aveiro'), -- cor1: tijolo , cor2: verde
('ARN005', 'No Engenharia Mecanica', 100, 'Rachel Street, N.o 2, Aveiro'), -- cor1: tijolo , cor2: cinzento
('ARN006', 'No Engenharia Civil', 100, 'Rachel Street, N.o 2, Aveiro'), -- cor1: tijolo , cor2: castanho
('ARN007', 'No Engenharia Biomedica', 100, 'Rachel Street, N.o 2, Aveiro'), -- cor1: tijolo , cor2: vermelho
('ARN008', 'No Engenharia de Materiais', 100, 'Rachel Street, N.o 2, Aveiro'), -- cor1: tijolo , cor2: vermelho
('ARN009', 'No Engenharia e Gestao Industrial', 100, 'Rachel Street, N.o 2, Aveiro'), -- cor1: tijolo , cor2: cinzento escuro
('ARN010', 'No Engenharia do Ambiente', 100, 'Rachel Street, N.o 2, Aveiro'), -- cor1: tijolo , cor2: roxo
('ARN011', 'No Engenharia Quimica', 100, 'Rachel Street, N.o 2, Aveiro'), -- cor1: tijolo , cor2: branco
('ARN012', 'No Linguas e Relacoes Empresariais', 100, 'Rachel Street, N.o 2, Aveiro'), -- cor1: azul escuro , cor2: vermelho
('ARN013', 'No Economia', 100, 'Rachel Street, N.o 2, Aveiro'), -- cor1: vermelho , cor2: branco
('ARN014', 'No Gestao', 100, 'Rachel Street, N.o 2, Aveiro'), -- cor1: preto , cor2: vermelho
('ARN015', 'No Biologia', 100, 'Rachel Street, N.o 2, Aveiro'), -- cor1: azul claro , cor2: null
('ARN016', 'No Geologia', 100, 'Rachel Street, N.o 2, Aveiro'), -- cor1: rosa claro , cor2: null
('ARN017', 'No Matematica', 100, 'Rachel Street, N.o 2, Aveiro'), -- cor1: azul claro , cor2: null
('ARN018', 'No Fisica', 100, 'Rachel Street, N.o 2, Aveiro'), -- cor1: azul claro , cor2: null
('ARN019', 'No Quimica', 100, 'Rachel Street, N.o 2, Aveiro'), -- cor1: azul claro , cor2: null
('ARN020', 'No Ciencias Biomedicas', 100, 'Rachel Street, N.o 2, Aveiro'), -- cor1: azul claro , cor2: amarelo
('ARN021', 'No Biotecnologia', 100, 'Rachel Street, N.o 2, Aveiro'); -- cor1: azul claro , cor2: null

/*

CREATE TABLE Emblemas (
	ID CHAR(6) NOT NULL PRIMARY KEY REFERENCES Artigo_Academico (ID) ,
	Forma VARCHAR(16) NOT NULL,
	Tipo VARCHAR (16) NOT NULL,
)

*/

-- emblemas rachel street (ARE - ARTIGO RACHEL EMBLEMA)
-- tipo: universidades (1 - 2)
-- tipo: aauav (3)
-- tipo: cursos (4 -21)
-- tipo séries e desenhos animados (22 - 47)
-- tipo: super herois (48 - 62)
-- tipo: comida (63 - 66)
-- tipo: harry potter	(67 - 73)
-- tipo: animais (74 - 81)
-- tipo: signos (82 - 93)
-- tipo: cidades (94 - 112)
-- tipo: paises e regioes (113 - 118)
-- tipo: familia (119 - 130)


insert into Emblema (ID, Forma, Tipo) values
('ARE001', 'Redondo', 'Universidade'),
('ARE002', 'Redondo', 'Universidade'),
('ARE003', 'Brasao', 'Aauav'),
('ARE004', 'Brasao', 'Cursos'),
('ARE005', 'Brasao', 'Cursos'),
('ARE006', 'Brasao', 'Cursos'),
('ARE007', 'Brasao', 'Cursos'),
('ARE008', 'Brasao', 'Cursos'),
('ARE009', 'Brasao', 'Cursos'),
('ARE010', 'Brasao', 'Cursos'),
('ARE011', 'Brasao', 'Cursos'),
('ARE012', 'Brasao', 'Cursos'),
('ARE013', 'Brasao', 'Cursos'),
('ARE014', 'Brasao', 'Cursos'),
('ARE015', 'Brasao', 'Cursos'),
('ARE016', 'Brasao', 'Cursos'),
('ARE017', 'Brasao', 'Cursos'),
('ARE018', 'Brasao', 'Cursos'),
('ARE019', 'Brasao', 'Cursos'),
('ARE020', 'Brasao', 'Cursos'),
('ARE021', 'Brasao', 'Cursos'),
('ARE022', 'Redondo', 'Series'),
('ARE023', 'Especial', 'Series'),
('ARE024', 'Especial', 'Series'),
('ARE025', 'Especial', 'Series'),
('ARE026', 'Redondo', 'Series'),
('ARE027', 'Redondo', 'Series'),
('ARE028', 'Redondo', 'Series'),
('ARE029', 'Brasao', 'Series'),
('ARE030', 'Redondo', 'Series'),
('ARE031', 'Brasao', 'Series'),
('ARE032', 'Especial', 'Series'),
('ARE033', 'Especial', 'Series'),
('ARE034', 'Especial', 'Series'),
('ARE035', 'Redondo', 'Series'),
('ARE036', 'Redondo', 'Series'),
('ARE037', 'Especial', 'Series'),
('ARE038', 'Redondo', 'Series'),
('ARE039', 'Redondo', 'Series'),
('ARE040', 'Brasao', 'Series'),
('ARE041', 'Brasao', 'Series'),
('ARE042', 'Especial', 'Series'),
('ARE043', 'Especial', 'Series'),
('ARE044', 'Especial', 'Series'),
('ARE045', 'Especial', 'Series'),
('ARE046', 'Redondo', 'Series'),
('ARE047', 'Redondo', 'Series'),
('ARE048', 'Redondo', 'Super Herois'),
('ARE049', 'Brasao', 'Super Herois'),
('ARE050', 'Especial', 'Super Herois'),
('ARE051', 'Especial', 'Super Herois'),
('ARE052', 'Especial', 'Super Herois'),
('ARE053', 'Especial', 'Super Herois'),
('ARE054', 'Redondo', 'Super Herois'),
('ARE055', 'Redondo', 'Super Herois'),
('ARE056', 'Especial', 'Super Herois'),
('ARE057', 'Especial', 'Super Herois'),
('ARE058', 'Especial', 'Super Herois'),
('ARE059', 'Especial', 'Super Herois'),
('ARE060', 'Redondo', 'Super Herois'),
('ARE061', 'Redondo', 'Super Herois'),
('ARE062', 'Brasao', 'Super Herois'),
('ARE063', 'Redondo', 'Comida'),
('ARE064', 'Especial', 'Comida'),
('ARE065', 'Redondo', 'Comida'),
('ARE066', 'Especial', 'Comida'),
('ARE067', 'Especial', 'Harry Potter'),
('ARE068', 'Especial', 'Harry Potter'),
('ARE069', 'Especial', 'Harry Potter'),
('ARE070', 'Especial', 'Harry Potter'),
('ARE071', 'Redondo', 'Harry Potter'),
('ARE072', 'Especial', 'Harry Potter'),
('ARE073', 'Brsao', 'Harry Potter'),
('ARE074', 'Especial', 'Animais'),
('ARE075', 'Redondo', 'Animais'),
('ARE076', 'Redondo', 'Animais'),
('ARE077', 'Especial', 'Animais'),
('ARE078', 'Especial', 'Animais'),
('ARE079', 'Redondo', 'Animais'),
('ARE080', 'Redondo', 'Animais'),
('ARE081', 'Redondo', 'Animais'),
('ARE082', 'Especial', 'Signos'),
('ARE083', 'Especial', 'Signos'),
('ARE084', 'Especial', 'Signos'),
('ARE085', 'Especial', 'Signos'),
('ARE086', 'Especial', 'Signos'),
('ARE087', 'Especial', 'Signos'),
('ARE088', 'Especial', 'Signos'),
('ARE089', 'Especial', 'Signos'),
('ARE090', 'Especial', 'Signos'),
('ARE091', 'Especial', 'Signos'),
('ARE092', 'Especial', 'Signos'),
('ARE093', 'Especial', 'Signos'),
('ARE094', 'Brasao', 'Cidades'),
('ARE095', 'Brasao', 'Cidades'),
('ARE096', 'Brasao', 'Cidades'),
('ARE097', 'Brasao', 'Cidades'),
('ARE098', 'Brasao', 'Cidades'),
('ARE099', 'Brasao', 'Cidades'),
('ARE100', 'Brasao', 'Cidades'),
('ARE101', 'Brasao', 'Cidades'),
('ARE102', 'Brasao', 'Cidades'),
('ARE103', 'Brasao', 'Cidades'),
('ARE104', 'Brasao', 'Cidades'),
('ARE105', 'Brasao', 'Cidades'),
('ARE106', 'Brasao', 'Cidades'),
('ARE107', 'Brasao', 'Cidades'),
('ARE108', 'Brasao', 'Cidades'),
('ARE109', 'Brasao', 'Cidades'),
('ARE110', 'Brasao', 'Cidades'),
('ARE111', 'Brasao', 'Cidades'),
('ARE112', 'Brasao', 'Cidades'),
('ARE113', 'Bandeira', 'Paises e Regioes'),
('ARE114', 'Bandeira', 'Paises e Regioes'),
('ARE115', 'Bandeira', 'Paises e Regioes'),
('ARE116', 'Brasao', 'Paises e Regioes'),
('ARE117', 'Brasao', 'Paises e Regioes'),
('ARE118', 'Brasao', 'Paises e Regioes'),
('ARE119', 'Especial', 'Familia'),
('ARE120', 'Especial', 'Familia'),
('ARE121', 'Especial', 'Familia'),
('ARE122', 'Especial', 'Familia'),
('ARE123', 'Redondo', 'Familia'),
('ARE124', 'Redondo', 'Familia'),
('ARE125', 'Especial', 'Familia'),
('ARE126', 'Especial', 'Familia'),
('ARE127', 'Especial', 'Familia'),
('ARE128', 'Redondo', 'Familia'),
('ARE129', 'Redondo', 'Familia'),
('ARE130', 'Redondo', 'Familia');

-- Pins rachel street (ARP - ARTIGO RACHEL PIN)
-- tipo: universidades (1-2)
-- tipo: aauav (3)
-- tipo: cursos (4 -21)
-- tipo: clubes (22 - 24)
-- tipo: animais (25-29)
-- tipo: jogos (30-32)

/*
CREATE TABLE Pins (
	ID CHAR(6) NOT NULL PRIMARY KEY REFERENCES Artigo_Academico (ID) ,
	Tipo VARCHAR (16) NOT NULL,
)
*/

insert into Pin (ID, Tipo) values
('ARP001', 'Tacha'),
('ARP002', 'Tacha'),
('ARP003', 'Tacha'),
('ARP004', 'Alfinete'),
('ARP005', 'Alfinete'),
('ARP006', 'Alfinete'),
('ARP007', 'Alfinete'),
('ARP008', 'Alfinete'),
('ARP009', 'Alfinete'),
('ARP010', 'Alfinete'),
('ARP011', 'Alfinete'),
('ARP012', 'Alfinete'),
('ARP013', 'Alfinete'),
('ARP014', 'Alfinete'),
('ARP015', 'Alfinete'),
('ARP016', 'Tacha'),
('ARP017', 'Alfinete'),
('ARP018', 'Alfinete'),
('ARP019', 'Alfinete'),
('ARP020', 'Alfinete'),
('ARP021', 'Alfinete'),
('ARP022', 'Tacha'),
('ARP023', 'Tacha'),
('ARP024', 'Tacha'),
('ARP025', 'Tacha'),
('ARP026', 'Alfinete'),
('ARP027', 'Alfinete'),
('ARP028', 'Tacha'),
('ARP029', 'Tacha'),
('ARP030', 'Alfinete'),
('ARP031', 'Tacha'),
('ARP032', 'Tacha');

/*
CREATE TABLE Pastas (
	ID CHAR(6) NOT NULL PRIMARY KEY REFERENCES Artigo_Academico (ID) ,
	Universidade VARCHAR (32) NOT NULL,
)
*/

-- Pastas rachel street (ART - ARTIGO RACHEL pasTas)
-- universidade: aveiro (1-3)
-- universidade: porto (4-6)

insert into Pasta (ID, Universidade) values
('ART001', 'Universidade de Aveiro'),
('ART002', 'Universidade de Aveiro'),
('ART003', 'Universidade de Aveiro'),
('ART004', 'Universidade do Porto'),
('ART005', 'Universidade do Porto'),
('ART006', 'Universidade do Porto');

/*
CREATE TABLE Chapeus (
	ID CHAR(6) NOT NULL PRIMARY KEY REFERENCES Artigo_Academico (ID) ,
	Universidade VARCHAR (32) NOT NULL,
	Genero VARCHAR (16) NOT NULL,	
)
*/

-- Chapeus rachel street (ARC - ARTIGO RACHEL CHAPEU)
-- universidade: aveiro (1-3)
-- universidade: porto (4-6)

insert into Chapeu (ID, Universidade, Genero) values
('ARC001', 'Universidade de Aveiro', 'Masculino'),
('ARC002', 'Universidade de Aveiro', 'Masculino'),
('ARC003', 'Universidade de Aveiro', 'Feminino'),
('ARC004', 'Universidade do Porto', 'Masculino'),
('ARC005', 'Universidade do Porto', 'Masculino'),
('ARC006', 'Universidade do Porto', 'Feminino'),
('ARC007', 'Universidade do Porto', 'Feminino');

/*
CREATE TABLE Nos (
	ID CHAR(6) NOT NULL PRIMARY KEY REFERENCES Artigo_Academico (ID) ,
	Cor1 VARCHAR (16) NOT NULL,
	Cor2 VARCHAR (16),
	Tipo VARCHAR (16) NOT NULL,
)
*/

-- Nos rachel street (ARN - ARTIGO RACHEL NOS)
-- tipo: coxim redondo (1-3)
-- tipo : azelha (4-21)

insert into NoA (ID, Cor1, Cor2, Tipo) values
('ARN001', 'Verde', NULL, 'Coxim Redondo'),
('ARN002', 'Castanho', NULL, 'Coxim Redondo'),
('ARN003', 'Branco Cru', NULL, 'Coxim Redondo'),
('ARN004', 'Tijolo', 'Verde', 'Azelha'),
('ARN005', 'Tijolo', 'Cinzento', 'Azelha'),
('ARN006', 'Tijolo', 'Castanho', 'Azelha'),
('ARN007', 'Tijolo', 'Vermelho', 'Azelha'),
('ARN008', 'Tijolo', 'Vermelho', 'Azelha'),
('ARN009', 'Tijolo', 'Cinzento Escuro', 'Azelha'),
('ARN010', 'Tijolo', 'Roxo', 'Azelha'),
('ARN011', 'Tijolo', 'Branco', 'Azelha'),
('ARN012', 'Azul Escuro', 'Vermelho', 'Azelha'),
('ARN013', 'Vermelho', 'Branco', 'Azelha'),
('ARN014', 'Preto', 'Vermelho', 'Azelha'),
('ARN015', 'Azul Claro', NULL, 'Azelha'),
('ARN016', 'Rosa Claro', NULL, 'Azelha'),
('ARN017', 'Azul Claro', NULL, 'Azelha'),
('ARN018', 'Azul Claro', NULL, 'Azelha'),
('ARN019', 'Azul Claro', NULL, 'Azelha'),
('ARN020', 'Azul Claro', 'Amarelo', 'Azelha'),
('ARN021', 'Azul Claro', NULL, 'Azelha');





-- 
--
--						=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
--						=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
--						=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
--						=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
--						=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
--						=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
--						=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

insert into Artigo_Academico (ID, Nome, Quantidade, End_Loja) values

-- emblemas rua do silencio (ASE - ARTIGO SILENCIO EMBLEMA)
-- tipo: universidades (1 - 2)
('ASE001', 'Emblema Universidade de Aveiro', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE002', 'Emblema Universidade do Porto', 100, 'Rua do Silencio, N.o 4, Aveiro'),
-- tipo: aauav (3)
('ASE003', 'Emblema Aauav', 100, 'Rua do Silencio, N.o 4, Aveiro'),
-- tipo: cursos (4 -21)
('ASE004', 'Emblema Engenharia Mecanica', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE005', 'Emblema Engenharia Informatica', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE006', 'Emblema Engenharia Civil', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE007', 'Emblema Engenharia Biomedica', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE008', 'Emblema Engenharia de Materiais', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE009', 'Emblema Engenharia e Gestao Industrial', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE010', 'Emblema Engenharia do Ambiente', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE011', 'Emblema Engenharia Quimica', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE012', 'Emblema Linguas e Relacoes Empresariais', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE013', 'Emblema Economia', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE014', 'Emblema Gestao', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE015', 'Emblema Biologia', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE016', 'Emblema Geologia', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE017', 'Emblema Matematica', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE018', 'Emblema Fisica', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE019', 'Emblema Quimica', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE020', 'Emblema Ciencias Biomedicas', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE021', 'Emblema Biotecnologia', 100, 'Rua do Silencio, N.o 4, Aveiro'),
-- tipo: clash royale (22 - 27)
('ASE022', 'Emblema Cavaleiro', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE023', 'Emblema Princesa', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE024', 'Emblema Corredor', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE025', 'Emblema Tronco', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE026', 'Emblema Gigante', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE027', 'Emblema Heheheha', 100, 'Rua do Silencio, N.o 4, Aveiro'),
-- tipo: harry potter	(28 - 32)
('ASE028', 'Emblema Gryffindor', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE029', 'Emblema Slytherin', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE030', 'Emblema Hufflepuff', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE031', 'Emblema Ravenclaw', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE032', 'Emblema Hogwarts', 100, 'Rua do Silencio, N.o 4, Aveiro'),
-- tipo: animais (33 - 36)
('ASE033', 'Emblema Tubarao', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE034', 'Emblema Chiuaua', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE035', 'Emblema Serra da Estrela', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE036', 'Emblema Crocodilo', 100, 'Rua do Silencio, N.o 4, Aveiro'),
-- tipo: signos (37 - 48)
('ASE037', 'Emblema Carneiro', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE038', 'Emblema Touro', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE039', 'Emblema Gemeos', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE040', 'Emblema Caranguejo', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE041', 'Emblema Leao', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE042', 'Emblema Virgem', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE043', 'Emblema Balanca', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE044', 'Emblema Escorpiao', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE045', 'Emblema Sagitario', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE046', 'Emblema Capricornio', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE047', 'Emblema Aquario', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE048', 'Emblema Peixes', 100, 'Rua do Silencio, N.o 4, Aveiro'),
-- tipo: cidades (49)
('ASE049', 'Emblema Aveiro', 100, 'Rua do Silencio, N.o 4, Aveiro'),
-- tipo: paises e regioes (50 -51)
('ASE050', 'Emblema Portugal', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASE051', 'Emblema Acores', 100, 'Rua do Silencio, N.o 4, Aveiro'),
-- pins rua do silencio street (ASP - ARTIGO SILENCIO PIN)
-- tipo: universidades (1-2)
('ASP001', 'Pin Universidade de Aveiro', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASP002', 'Pin Universidade do Porto', 100, 'Rua do Silencio, N.o 4, Aveiro'),
-- tipo: aauav (3)
('ASP003', 'Pin Aauav', 100, 'Rua do Silencio, N.o 4, Aveiro'),
-- tipo: cursos (4 -8)
('ASP004', 'Pin Engenharia Mecanica', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASP005', 'Pin Engenharia Informatica', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASP006', 'Pin Engenharia Civil', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASP007', 'Pin Engenharia Biomedica', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASP008', 'Pin Biotecnologia', 100, 'Rua do Silencio, N.o 4, Aveiro'),
--tipo: clubes (9 - 11)
('ASP009', 'Pin Benfica', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASP010', 'Pin Sporting', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASP011', 'Pin Porto', 100, 'Rua do Silencio, N.o 4, Aveiro'),
--tipo: jogos (12 -14)
('ASP012', 'Pin Brawl Stars',  100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASP013', 'Pin Word of Warcraft',  100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASP014', 'Pin Overwatch',  100, 'Rua do Silencio, N.o 4, Aveiro'),
-- Pastas rua do silencio (AST - ARTIGO SILENCIO pasTas)
-- universidade: aveiro (1-3)
('AST001', 'Pasta Pele Fina Universidade de Aveiro', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('AST002', 'Pasta Pele Grossa Universidade de Aveiro', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('AST003', 'Pasta Premium Universidade de Aveiro', 100, 'Rua do Silencio, N.o 4, Aveiro'),
-- universidade: porto (4-6)
('AST004', 'Pasta Pele Fina Universidade do Porto', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('AST005', 'Pasta Pele Grossa Universidade do Porto', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('AST006', 'Pasta Premium Universidade do Porto', 100, 'Rua do Silencio, N.o 4, Aveiro'),
-- Chapeus rua do silencio (ASC - ARTIGO SILENCIO CHAPEU)
-- universidade: aveiro (1-3)
('ASC001', 'Chapeu Masculino Universidade de Aveiro', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASC002', 'Chapeu com fita Masculino Universidade de Aveiro', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASC003', 'Chapeu Feminino Universidade de Aveiro', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASC004', 'Chapeu com fita Feminino Universidade de Aveiro', 100, 'Rua do Silencio, N.o 4, Aveiro'),
-- universidade: porto (4-6)
('ASC005', 'Chapeu Masculino Universidade do Porto', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASC006', 'Chapeu com fita Masculino Universidade do Porto', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASC007', 'Chapeu Feminino Universidade do Porto', 100, 'Rua do Silencio, N.o 4, Aveiro'),
('ASC008', 'Chapeu com fita Feminino Universidade do Porto', 100, 'Rua do Silencio, N.o 4, Aveiro'),
-- Nos rua do silencio (ASN - ARTIGO SILENCIO NOS)
-- tipo: coxim redondo (1-3)
('ASN001', 'No Coxim Redondo Verde', 100, 'Rua do Silencio, N.o 4, Aveiro'), -- cor1: verde , cor2: null
('ASN002', 'No Coxim Redondo Castanho', 100, 'Rua do Silencio, N.o 4, Aveiro'), -- cor1: castanho , cor2: null
('ASN003', 'No Coxim Redondo Branco Cru', 100, 'Rua do Silencio, N.o 4, Aveiro'), -- cor1: branco , cor2: null
-- tipo : azelha (4-21)
('ASN004', 'No Engenharia Informatica', 100, 'Rua do Silencio, N.o 4, Aveiro'), -- cor1: tijolo , cor2: verde
('ASN005', 'No Engenharia Mecanica', 100, 'Rua do Silencio, N.o 4, Aveiro'), -- cor1: tijolo , cor2: cinzento
('ASN006', 'No Engenharia Civil', 100, 'Rua do Silencio, N.o 4, Aveiro'), -- cor1: tijolo , cor2: castanho
('ASN007', 'No Engenharia Biomedica', 100, 'Rua do Silencio, N.o 4, Aveiro'), -- cor1: tijolo , cor2: vermelho
('ASN008', 'No Engenharia de Materiais', 100, 'Rua do Silencio, N.o 4, Aveiro'), -- cor1: tijolo , cor2: vermelho
('ASN009', 'No Engenharia e Gestao Industrial', 100, 'Rua do Silencio, N.o 4, Aveiro'), -- cor1: tijolo , cor2: cinzento escuro
('ASN010', 'No Engenharia do Ambiente', 100, 'Rua do Silencio, N.o 4, Aveiro'), -- cor1: tijolo , cor2: roxo
('ASN011', 'No Engenharia Quimica', 100, 'Rua do Silencio, N.o 4, Aveiro'), -- cor1: tijolo , cor2: branco
('ASN012', 'No Linguas e Relacoes Empresariais', 100, 'Rua do Silencio, N.o 4, Aveiro'), -- cor1: azul escuro , cor2: vermelho
('ASN013', 'No Economia', 100, 'Rua do Silencio, N.o 4, Aveiro'), -- cor1: vermelho , cor2: branco
('ASN014', 'No Gestao', 100, 'Rua do Silencio, N.o 4, Aveiro'), -- cor1: preto , cor2: vermelho
('ASN015', 'No Biologia', 100, 'Rua do Silencio, N.o 4, Aveiro'), -- cor1: azul claro , cor2: null
('ASN016', 'No Geologia', 100, 'Rua do Silencio, N.o 4, Aveiro'), -- cor1: rosa claro , cor2: null
('ASN017', 'No Matematica', 100, 'Rua do Silencio, N.o 4, Aveiro'), -- cor1: azul claro , cor2: null
('ASN018', 'No Fisica', 100, 'Rua do Silencio, N.o 4, Aveiro'), -- cor1: azul claro , cor2: null
('ASN019', 'No Quimica', 100, 'Rua do Silencio, N.o 4, Aveiro'), -- cor1: azul claro , cor2: null
('ASN020', 'No Ciencias Biomedicas', 100, 'Rua do Silencio, N.o 4, Aveiro'), -- cor1: azul claro , cor2: amarelo
('ASN021', 'No Biotecnologia', 100, 'Rua do Silencio, N.o 4, Aveiro'); -- cor1: azul claro , cor2: null

--ACABOU

/*

CREATE TABLE Emblemas (
	ID CHAR(6) NOT NULL PRIMARY KEY REFERENCES Artigo_Academico (ID) ,
	Forma VARCHAR(16) NOT NULL,
	Tipo VARCHAR (16) NOT NULL,
)


CREATE TABLE Pastas (
	ID CHAR(6) NOT NULL PRIMARY KEY REFERENCES Artigo_Academico (ID) ,
	Universidade VARCHAR (32) NOT NULL,
)

CREATE TABLE Chapeus (
	ID CHAR(6) NOT NULL PRIMARY KEY REFERENCES Artigo_Academico (ID) ,
	Universidade VARCHAR (32) NOT NULL,
	Genero VARCHAR (16) NOT NULL,	
)

CREATE TABLE Nos (
	ID CHAR(6) NOT NULL PRIMARY KEY REFERENCES Artigo_Academico (ID) ,
	Cor1 VARCHAR (16) NOT NULL,
	Cor2 VARCHAR (16),
	Tipo VARCHAR (16) NOT NULL,
)

*/
-- emblemas rua do silencio (ASE - ARTIGO SILENCIO EMBLEMA)
-- tipo: universidades (1 - 2)
-- tipo: aauav (3)
-- tipo: cursos (4 -21)
-- tipo: clash royale (22 - 27)
-- tipo: harry potter	(28 - 32)
-- tipo: animais (33 - 36)
-- tipo: signos (37 - 48)
-- tipo: cidades (49)
-- tipo: paises e regioes (50 -51)

insert into Emblema (ID, Forma, Tipo) values
('ASE001', 'Redondo', 'Universidade'),
('ASE002', 'Redondo', 'Universidade'),
('ASE003', 'Brasao', 'AAUAV'),
('ASE004', 'Brasao', 'Cursos'),
('ASE005', 'Brasao', 'Cursos'),
('ASE006', 'Brasao', 'Cursos'),
('ASE007', 'Brasao', 'Cursos'),
('ASE008', 'Brasao', 'Cursos'),
('ASE009', 'Brasao', 'Cursos'),
('ASE010', 'Brasao', 'Cursos'),
('ASE011', 'Brasao', 'Cursos'),
('ASE012', 'Brasao', 'Cursos'),
('ASE013', 'Brasao', 'Cursos'),
('ASE014', 'Brasao', 'Cursos'),
('ASE015', 'Brasao', 'Cursos'),
('ASE016', 'Brasao', 'Cursos'),
('ASE017', 'Brasao', 'Cursos'),
('ASE018', 'Brasao', 'Cursos'),
('ASE019', 'Brasao', 'Cursos'),
('ASE020', 'Brasao', 'Cursos'),
('ASE021', 'Brasao', 'Cursos'),
('ASE022', 'Especial', 'Clash Royale'),
('ASE023', 'Especial', 'Clash Royale'),
('ASE024', 'Redondo', 'Clash Royale'),
('ASE025', 'Especial', 'Clash Royale'),
('ASE026', 'Redondo', 'Clash Royale'),
('ASE027', 'Redondo', 'Clash Royale'),
('ASE028', 'Especial', 'Harry Potter'),
('ASE029', 'Especial', 'Harry Potter'),
('ASE030', 'Especial', 'Harry Potter'),
('ASE031', 'Especial', 'Harry Potter'),
('ASE032', 'Redondo', 'Harry Potter'),
('ASE033', 'Redondo', 'Animais'),
('ASE034', 'Especial', 'Animais'),
('ASE035', 'Redondo', 'Animais'),
('ASE036', 'Redondo', 'Animais'),
('ASE037', 'Especial', 'Signos'),
('ASE038', 'Especial', 'Signos'),
('ASE039', 'Especial', 'Signos'),
('ASE040', 'Especial', 'Signos'),
('ASE041', 'Especial', 'Signos'),
('ASE042', 'Especial', 'Signos'),
('ASE043', 'Especial', 'Signos'),
('ASE044', 'Especial', 'Signos'),
('ASE045', 'Especial', 'Signos'),
('ASE046', 'Especial', 'Signos'),
('ASE047', 'Especial', 'Signos'),
('ASE048', 'Especial', 'Signos'),
('ASE049', 'Brasao', 'Cidades'),
('ASE050', 'Bandeira', 'Paises e Regioes'),
('ASE051', 'Brasao', 'Paises e Regioes');

/*
CREATE TABLE Pins (
	ID CHAR(6) NOT NULL PRIMARY KEY REFERENCES Artigo_Academico (ID) ,
	Tipo VARCHAR (16) NOT NULL,
)
*/

-- pins rua do silencio street (ASP - ARTIGO SILENCIO PIN)
-- tipo: universidades (1-2)
-- tipo: aauav (3)
-- tipo: cursos (4 -8)
--tipo: clubes (9 - 11)
--tipo: jogos (12 -14)

insert into Pin (ID, Tipo) values
('ASP001', 'Tacha'),
('ASP002', 'Tacha'),
('ASP003', 'Tacha'),
('ASP004', 'Alfinete'),
('ASP005', 'Alfinete'),
('ASP006', 'Alfinete'),
('ASP007', 'Alfinete'),
('ASP008', 'Alfinete'),
('ASP009', 'Tacha'),
('ASP010', 'Tacha'),
('ASP011', 'Tacha'),
('ASP012', 'Tacha'),
('ASP013', 'Alfinete'),
('ASP014', 'Tacha');

/*
CREATE TABLE Pastas (
	ID CHAR(6) NOT NULL PRIMARY KEY REFERENCES Artigo_Academico (ID) ,
	Universidade VARCHAR (32) NOT NULL,
)
*/

-- Pastas rua do silencio (AST - ARTIGO SILENCIO pasTas)
-- universidade: aveiro (1-3)
-- universidade: porto (4-6)

insert into Pasta (ID, Universidade) values
('AST001', 'Universidade de Aveiro'),
('AST002', 'Universidade de Aveiro'),
('AST003', 'Universidade de Aveiro'),
('AST004', 'Universidade do Porto'),
('AST005', 'Universidade do Porto'),
('AST006', 'Universidade do Porto');

/*
CREATE TABLE Chapeus (
	ID CHAR(6) NOT NULL PRIMARY KEY REFERENCES Artigo_Academico (ID) ,
	Universidade VARCHAR (32) NOT NULL,
	Genero VARCHAR (16) NOT NULL,	
)
*/

-- Chapeus rua do silencio (ASC - ARTIGO SILENCIO CHAPEU)
-- universidade: aveiro (1-3)
-- universidade: porto (4-6)

insert into Chapeu (ID, Universidade, Genero) values
('ASC001', 'Universidade de Aveiro', 'Masculino'),
('ASC002', 'Universidade de Aveiro', 'Masculino'),
('ASC003', 'Universidade de Aveiro', 'Feminino'),
('ASC004', 'Universidade do Porto', 'Masculino'),
('ASC005', 'Universidade do Porto', 'Masculino'),
('ASC006', 'Universidade do Porto', 'Feminino'),
('ASC007', 'Universidade do Porto', 'Feminino');

/*
CREATE TABLE Nos (
	ID CHAR(6) NOT NULL PRIMARY KEY REFERENCES Artigo_Academico (ID) ,
	Cor1 VARCHAR (16) NOT NULL,
	Cor2 VARCHAR (16),
	Tipo VARCHAR (16) NOT NULL,
)
*/

-- Nos rua do silencio (ASN - ARTIGO SILENCIO NOS)
-- tipo: coxim redondo (1-3)
-- tipo : azelha (4-21)

insert into NoA (ID, Cor1, Cor2, Tipo) values
('ASN001', 'Verde', NULL, 'Coxim Redondo'),
('ASN002', 'Castanho', NULL, 'Coxim Redondo'),
('ASN003', 'Branco Cru', NULL, 'Coxim Redondo'),
('ASN004', 'Tijolo', 'Verde', 'Azelha'),
('ASN005', 'Tijolo', 'Cinzento', 'Azelha'),
('ASN006', 'Tijolo', 'Castanho', 'Azelha'),
('ASN007', 'Tijolo', 'Vermelho', 'Azelha'),
('ASN008', 'Tijolo', 'Vermelho', 'Azelha'),
('ASN009', 'Tijolo', 'Cinzento Escuro', 'Azelha'),
('ASN010', 'Tijolo', 'Roxo', 'Azelha'),
('ASN011', 'Tijolo', 'Branco', 'Azelha'),
('ASN012', 'Azul Escuro', 'Vermelho', 'Azelha'),
('ASN013', 'Vermelho', 'Branco', 'Azelha'),
('ASN014', 'Preto', 'Vermelho', 'Azelha'),
('ASN015', 'Azul Claro', NULL, 'Azelha'),
('ASN016', 'Rosa Claro', NULL, 'Azelha'),
('ASN017', 'Azul Claro', NULL, 'Azelha'),
('ASN018', 'Azul Claro', NULL, 'Azelha'),
('ASN019', 'Azul Claro', NULL, 'Azelha'),
('ASN020', 'Azul Claro', 'Amarelo', 'Azelha'),
('ASN021', 'Azul Claro', NULL, 'Azelha');




-- CREATE TABLE Artigo_Papelaria (
-- ID CHAR(6) PRIMARY KEY ,
-- Nome VARCHAR(30) NOT NULL,
-- Marca VARCHAR(30) NOT NULL,
-- Quantidade int NOT NULL,
-- End_Loja VARCHAR(60) FOREIGN KEY REFERENCES Loja (Endereco),
-- )

insert into traje (id, nome, num_acessorios,  num_pecas, completo,  End_Loja) values
('T0001', 'andre dora', 6, 3, 0, 'Rua do Silencio, N.o 4, Aveiro');



insert into Artigo_Papelaria(id, Nome, Marca, Quantidade, End_Loja) values
-- CANETAS rachel street (PRC - PAPELARIA RACHEL CANETA)
-- tipo: Gel (1-8)
('PRC001', 'Caneta de Gel Preta', 'BYK', 130,'Rachel Street, N.o 2, Aveiro' ),
('PRC002', 'Caneta de Gel Vermelha', 'BYK', 120,'Rachel Street, N.o 2, Aveiro' ),
('PRC003', 'Caneta de Gel Verde', 'Rotstring', 10,'Rachel Street, N.o 2, Aveiro' ),
('PRC004', 'Caneta de Gel Azul', 'BYK', 40,'Rachel Street, N.o 2, Aveiro' ),
('PRC005', 'Caneta de Gel Amarela', 'BYK', 50,'Rachel Street, N.o 2, Aveiro' ),
('PRC006', 'Caneta de Gel Roxa', 'BYK', 99,'Rachel Street, N.o 2, Aveiro' ),
('PRC007', 'Caneta de Gel Preta', 'Mapet', 125,'Rachel Street, N.o 2, Aveiro' ),
('PRC008', 'Caneta de Gel Azul', 'Rotstring', 111,'Rachel Street, N.o 2, Aveiro' ),

-- tipo: Esferográfica (9-15)
('PRC009', 'Esferografica Preta', 'BYK', 132, 'Rachel Street, N.o 2, Aveiro'),
('PRC010', 'Esferografica Verde', 'BYK', 96, 'Rachel Street, N.o 2, Aveiro'),
('PRC011', 'Esferografica Azul', 'BYK', 58, 'Rachel Street, N.o 2, Aveiro'),
('PRC012', 'Esferografica Vermelha', 'Rotstring', 98, 'Rachel Street, N.o 2, Aveiro'),
('PRC013', 'Esferografica Preta', 'Mapet', 23, 'Rachel Street, N.o 2, Aveiro'),
('PRC014', 'Esferografica Vermelha', 'Mapet', 41, 'Rachel Street, N.o 2, Aveiro'),
('PRC015', 'Esferografica Azul', 'Mapet', 98, 'Rachel Street, N.o 2, Aveiro'),

-- tipo: Ponta fina (16-23)
('PRC016', 'Caneta de Ponta Fina Preta', 'BYK', 132, 'Rachel Street, N.o 2, Aveiro'),
('PRC017', 'Caneta de Ponta Fina Verde', 'BYK', 96, 'Rachel Street, N.o 2, Aveiro'),
('PRC018', 'Caneta de Ponta Fina Vermelha', 'BYK', 98, 'Rachel Street, N.o 2, Aveiro'),
('PRC019', 'Caneta de Ponta Fina Preta', 'Mapet', 23, 'Rachel Street, N.o 2, Aveiro'),
('PRC020', 'Caneta de Ponta Fina Vermelha', 'Mapet', 41, 'Rachel Street, N.o 2, Aveiro'),
('PRC021', 'Caneta de Ponta Fina Preta', 'Rotstring', 98, 'Rachel Street, N.o 2, Aveiro'),
('PRC022', 'Caneta de Ponta Fina Roxa', 'Rotstring', 98, 'Rachel Street, N.o 2, Aveiro'),
('PRC023', 'Caneta de Ponta Fina Amarela', 'Rotstring', 98, 'Rachel Street, N.o 2, Aveiro'),

-- Lapis rachel street (PRL - PAPELARIA RACHEL Lapis)
-- tipo: HB (24-26)
('PRL001', 'Lapis HB', 'BYK', 42, 'Rachel Street, N.o 2, Aveiro'),
('PRL002', 'Lapis HB', 'Mapet', 65, 'Rachel Street, N.o 2, Aveiro'),
('PRL003', 'Lapis HB', 'Rotstring', 32, 'Rachel Street, N.o 2, Aveiro'),
-- tipo:4B (27-29)
('PRL004', 'Lapis 4B', 'BYK', 23, 'Rachel Street, N.o 2, Aveiro'),
('PRL005', 'Lapis 4B', 'Mapet', 65, 'Rachel Street, N.o 2, Aveiro'),
('PRL006', 'Lapis 4B', 'Rotstring', 42, 'Rachel Street, N.o 2, Aveiro'),
-- tipo:2B (30-32)
('PRL007', 'Lapis 2B', 'BYK', 43, 'Rachel Street, N.o 2, Aveiro'),
('PRL008', 'Lapis 2B', 'Mapet', 35, 'Rachel Street, N.o 2, Aveiro'),
('PRL009', 'Lapis 2B', 'Rotstring', 12, 'Rachel Street, N.o 2, Aveiro'),

-- CANETAS Rua do Silencio (PRC - PAPELARIA SILENCIO CANETA)
-- tipo: Gel (1-8)
('PSC001', 'Caneta de Gel Preta', 'BYK', 130,'Rua do Silencio, N.o 4, Aveiro' ),
('PSC002', 'Caneta de Gel Vermelha', 'BYK', 120,'Rua do Silencio, N.o 4, Aveiro' ),
('PSC003', 'Caneta de Gel Verde', 'Rotstring', 10,'Rua do Silencio, N.o 4, Aveiro' ),
('PSC004', 'Caneta de Gel Azul', 'BYK', 40,'Rua do Silencio, N.o 4, Aveiro' ),
('PSC005', 'Caneta de Gel Amarela', 'BYK', 50,'Rua do Silencio, N.o 4, Aveiro' ),
('PSC006', 'Caneta de Gel Roxa', 'BYK', 99,'Rua do Silencio, N.o 4, Aveiro' ),
('PSC007', 'Caneta de Gel Preta', 'Mapet', 125,'Rua do Silencio, N.o 4, Aveiro' ),
('PSC008', 'Caneta de Gel Azul', 'Rotstring', 111,'Rua do Silencio, N.o 4, Aveiro' ),

-- tipo: Esferográfica (9-15)
('PSC009', 'Esferografica Preta', 'BYK', 132, 'Rua do Silencio, N.o 4, Aveiro'),
('PSC010', 'Esferografica Verde', 'BYK', 96, 'Rua do Silencio, N.o 4, Aveiro'),
('PSC011', 'Esferografica Azul', 'BYK', 58, 'Rua do Silencio, N.o 4, Aveiro'),
('PSC012', 'Esferografica Vermelha', 'Rotstring', 98, 'Rua do Silencio, N.o 4, Aveiro'),
('PSC013', 'Esferografica Preta', 'Mapet', 23, 'Rua do Silencio, N.o 4, Aveiro'),
('PSC014', 'Esferografica Vermelha', 'Mapet', 41, 'Rua do Silencio, N.o 4, Aveiro'),
('PSC015', 'Esferografica Azul', 'Mapet', 98, 'Rua do Silencio, N.o 4, Aveiro'),

-- tipo: Ponta fina (16-23)
('PSC016', 'Caneta de Ponta Fina Preta', 'BYK', 132, 'Rua do Silencio, N.o 4, Aveiro'),
('PSC017', 'Caneta de Ponta Fina Verde', 'BYK', 96, 'Rua do Silencio, N.o 4, Aveiro'),
('PSC018', 'Caneta de Ponta Fina Vermelha', 'BYK', 98, 'Rua do Silencio, N.o 4, Aveiro'),
('PSC019', 'Caneta de Ponta Fina Preta', 'Mapet', 23, 'Rua do Silencio, N.o 4, Aveiro'),
('PSC020', 'Caneta de Ponta Fina Vermelha', 'Mapet', 41, 'Rua do Silencio, N.o 4, Aveiro'),
('PSC021', 'Caneta de Ponta Fina Preta', 'Rotstring', 98, 'Rua do Silencio, N.o 4, Aveiro'),
('PSC022', 'Caneta de Ponta Fina Roxa', 'Rotstring', 98, 'Rua do Silencio, N.o 4, Aveiro'),
('PSC023', 'Caneta de Ponta Fina Amarela', 'Rotstring', 98, 'Rua do Silencio, N.o 4, Aveiro'),

-- Lapis rua do silencio (PSL - PAPELARIA SILENCIO Lapis)
-- tipo: HB (1-3)
('PSL001', 'Lapis HB', 'BYK', 42, 'Rua do Silencio, N.o 4, Aveiro'),
('PSL002', 'Lapis HB', 'Mapet', 65, 'Rua do Silencio, N.o 4, Aveiro'),
('PSL003', 'Lapis HB', 'Rotstring', 32, 'Rua do Silencio, N.o 4, Aveiro'),
-- tipo:4B (4-6)
('PSL004', 'Lapis 4B', 'BYK', 23, 'Rua do Silencio, N.o 4, Aveiro'),
('PSL005', 'Lapis 4B', 'Mapet', 65, 'Rua do Silencio, N.o 4, Aveiro'),
('PSL006', 'Lapis 4B', 'Rotstring', 42, 'Rua do Silencio, N.o 4, Aveiro'),
-- tipo:2B (7-9)
('PSL007', 'Lapis 2B', 'BYK', 43, 'Rua do Silencio, N.o 4, Aveiro'),
('PSL008', 'Lapis 2B', 'Mapet', 35, 'Rua do Silencio, N.o 4, Aveiro'),
('PSL009', 'Lapis 2B', 'Rotstring', 12, 'Rua do Silencio, N.o 4, Aveiro');


--CREATE TABLE Caneta (
--	ID CHAR(6) NOT NULL PRIMARY KEY REFERENCES Artigo_Papelaria (ID),
--	Tipo VARCHAR(30) NOT NULL,
--	Cor VARCHAR (16) NOT NULL,
--)

insert into Caneta(id, Tipo, Cor) values
('PRC001', 'Gel','Preta'),
('PRC002', 'Gel','Vermelha'),
('PRC003', 'Gel','Verde'),
('PRC004', 'Gel','Azul'),
('PRC005', 'Gel', 'Amarela'),
('PRC006', 'Gel,','Roxa'),
('PRC007', 'Gel','Preta'),
('PRC008', 'Gel','Azul' ),

-- tipo: Gel (9-15)
('PRC009', 'Esferografica','Preta'),
('PRC010', 'Esferografica','Verde'),
('PRC011', 'Esferografica','Azul'),
('PRC012', 'Esferografica','Vermelha'),
('PRC013', 'Esferografica','Preta'),
('PRC014', 'Esferografica','Vermelha'),
('PRC015', 'Esferografica','Azul'),

-- tipo: Ponta fina (16-23)
('PRC016', 'Ponta Fina','Preta'),
('PRC017', 'Ponta Fina','Verde'),
('PRC018', 'Ponta Fina','Vermelha'),
('PRC019', 'Ponta Fina','Preta'),
('PRC020', 'Ponta Fina','Vermelha'),
('PRC021', 'Ponta Fina','Preta'),
('PRC022', 'Ponta Fina','Roxa'),
('PRC023', 'Ponta Fina','Amarela'),

('PSC001', 'Gel','Preta'),
('PSC002', 'Gel','Vermelha'),
('PSC003', 'Gel','Verde'),
('PSC004', 'Gel','Azul'),
('PSC005', 'Gel','Amarela'),
('PSC006', 'Gel','Roxa'),
('PSC007', 'Gel','Preta'),
('PSC008', 'Gel','Azul'),

-- tipo: Esferográfica (9-15)
('PSC009', 'Esferografica','Preta'),
('PSC010', 'Esferografica','Verde'),
('PSC011', 'Esferografica','Azul'),
('PSC012', 'Esferografica','Vermelha'),
('PSC013', 'Esferografica','Preta'),
('PSC014', 'Esferografica','Vermelha'),
('PSC015', 'Esferografica','Azul'),

-- tipo: Ponta fina (16-23)
('PSC016', 'Ponta Fina','Preta'),
('PSC017', 'Ponta Fina','Verde'),
('PSC018', 'Ponta Fina','Vermelha'),
('PSC019', 'Ponta Fina','Preta'),
('PSC020', 'Ponta Fina','Vermelha'),
('PSC021', 'Ponta Fina','Preta'),
('PSC022', 'Ponta Fina','Roxa'),
('PSC023', 'Ponta Fina','Amarela');


--CREATE TABLE Lapis (
--	ID CHAR(6) NOT NULL PRIMARY KEY REFERENCES Artigo_Papelaria (ID),
--	Dureza VARCHAR(2) NOT NULL,
--)

insert into Lapis(id, Dureza) values
-- tipo: HB  Rachel
('PRL001', 'HB'),
('PRL002', 'HB'),
('PRL003', 'HB'),
-- tipo:4B 
('PRL004', '4B'),
('PRL005', '4B'),
('PRL006', '4B'),
-- tipo:2B 
('PRL007', '2B'),
('PRL008', '2B'),
('PRL009', '2B'),

-- tipo: HB Silencio
('PSL001', 'HB'),
('PSL002', 'HB'),
('PSL003', 'HB'),
-- tipo:4B 
('PSL004', '4B'),
('PSL005', '4B'),
('PSL006', '4B'),
-- tipo:2B 
('PSL007', '2B'),
('PSL008', '2B'),
('PSL009', '2B');