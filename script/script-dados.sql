Create database If Not Exists Compra;

USE Compra;
CREATE TABLE IF NOT EXISTS Promocao
(
Id int(20) not null auto_increment,
DescricaoAplicarPromocao varchar(255) not null,
SiglaAplicarPromocao varchar(5) not null,
Nome varchar(255) not null,
Restricoes varchar(255),
ValorDesconto double not null,
Promocodes varchar(250),
primary key(id)
); 

-- 1'Apenas para as sessões de sábado e domingo'
USE Compra;
INSERT INTO Promocao (DescricaoAplicarPromocao, SiglaAplicarPromocao, Nome, Restricoes, ValorDesconto, Promocodes)
VALUES ('Desconto sobre maior ingresso', 'MAI','Final de semana é dia de cinema!',  '1'
, 12.50, 'YsnPvmhm, AdPRtqzw, MxNxhm3q' ); 


-- 2 'Para um filme: CORINGA'
-- 3 'Para um cinema: Roxy'

USE Compra;
INSERT INTO Promocao (DescricaoAplicarPromocao, SiglaAplicarPromocao, Nome, Restricoes, ValorDesconto, Promocodes)
VALUES ('Desconto sobre total da compra','TOT', 'Coringa é no cinema!', '2,3', 
 20, 'xttEVw3k, BCBmzwCX' ); 


USE Compra;
INSERT INTO Promocao (DescricaoAplicarPromocao, SiglaAplicarPromocao, Nome, ValorDesconto, Promocodes)
VALUES ('Desconto sobre menor ingresso', 'MEN', 'Desconto ingresso.com 9.99', 
 9.99, 'b9E65dCf, VgfGVmZp' );

select * from Promocao;

USE Compra;
CREATE TABLE IF NOT EXISTS Restricao (
    Id INT(20) NOT NULL AUTO_INCREMENT,
    Nome VARCHAR(255) NOT NULL,
    Sigla VARCHAR(5) NOT NULL,
    AssociadoId INT,
    PRIMARY KEY (Id)
);


USE Compra;
INSERT INTO Restricao (Nome, Sigla, AssociadoId)
VALUES ('Apenas para as sessões de sábado e domingo', 'FDS', 0); 

USE Compra;
INSERT INTO Restricao (Nome, Sigla, AssociadoId)
VALUES ('Restrição para um filme', 'F', 22050); 

USE Compra;
INSERT INTO Restricao (Nome, Sigla, AssociadoId)
VALUES ('Restrição para um Cinema', 'C', 17); 


select * from Restricao;
