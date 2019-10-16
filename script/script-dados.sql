Create database If Not Exists Compra;

USE Compra;
CREATE TABLE IF NOT EXISTS Promocoes
(
Id int(20) not null auto_increment,
Nome varchar(255) not null,
Sigla varchar(5) not null,
DescricaoPromocao varchar(255) not null,
Restricao varchar(255),
ValorDesconto double not null,
Promocodes varchar(250),
primary key(id)
); 


USE Compra;
INSERT INTO Promocoes (Nome, Sigla, DescricaoPromocao, Restricao, ValorDesconto, Promocodes)
VALUES ('Final de semana é dia de cinema!', 'FDS', 
'Desconto sobre maior ingresso', 'Apenas para as sessões de sábado e domingo', 12.50, 'YsnPvmhm, AdPRtqzw, MxNxhm3q' ); 

USE Compra;
INSERT INTO Promocoes (Nome, Sigla, DescricaoPromocao, Restricao, ValorDesconto, Promocodes)
VALUES ('Coringa é no cinema!', 'COR', 
'Desconto sobre total da compra', 'Para um filme e um cinema ', 20, 'xttEVw3k, BCBmzwCX' ); 

USE Compra;
INSERT INTO Promocoes (Nome, Sigla, DescricaoPromocao, ValorDesconto, Promocodes)
VALUES ('Desconto ingresso.com 9.99', 'ING9', 
'Desconto sobre menor ingresso', 9.99, 'b9E65dCf, VgfGVmZp' );

select * from Promocao
