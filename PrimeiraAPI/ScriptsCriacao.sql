-- 1 CRIAR O BANCO
CREATE DATABASE PrimeiraAPI;

-- 2 - USAR O BANCO
USE primeiraapi;

-- 3 - CRIAR TABELA USUARIO
CREATE TABLE usuario (
	id INT NOT NULL AUTO_INCREMENT,
	nome VARCHAR(50) NOT NULL,
	sobrenome VARCHAR (150) NOT NULL,
	telefone VARCHAR(20) NOT NULL, 
	email VARCHAR(50) NOT NULL,
	genero VARCHAR(20) NOT NULL,
	senha VARCHAR(30) NOT NULL,
	PRIMARY KEY (id) 
);
-- 4 - CRIAR ENDEREÇO
CREATE TABLE endereco (
	id INT NOT NULL AUTO_INCREMENT,
    rua VARCHAR(250) NOT NULL,
    numero VARCHAR(30) NOT NULL,
    bairro VARCHAR(150) NOT NULL,
	cidade Varchar(250) NOT NULL,
    complemento VARCHAR(150) NULL,
    cep VARCHAR(9) NOT NULL,
    estado VARCHAR(2) NOT NULL
    PRIMARY KEY (id)
);

-- 5 - ALTERAR TABELA ENDEREÇO
ALTER TABLE endereco ADD usuario_id INT NOT NULL;

-- ADICIONAR CHAVE ESTRANGEIRA
ALTER TABLE endereco ADD CONSTRAINT FK_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id);

-- INSERIR USUÁRIO
INSERT INTO usuario (nome, sobrenome, telefone, email, genero, senha) 
VALUES ('Matheus', 'Camilo', '(21)992593803', 'camilooliveiradev@gmail.com', 'masculino', '0811')

-- SELECIONAR USUÁRIO / * SIGNIFICA (TODOS)
SELECT * FROM usuario;

-- SELECIONAR UM USUÁRIO
SELECT * FROM usuario WHERE email = 'camilooliveira@gmail.com';

-- ALTERAR USUÁRIO
UPDATE usuario SET email = 'matheuscamilooliveira@gmail.com' WHERE id = 1;

-- DELETAR USUÁRIO
DELETE FROM usuario WHERE id = 1;
-- DELETAR MAIS DE 1 USUÁRIO
DELETE FROM usuario WHERE id IN (1, 2); --OU id > 2; VAI APAGAR TODOS OS ID MAIORES QUE 2
