
Consideracoes gerais:

Está retornando o valor total da compra e a promocao aplicada.
Caso queira o json do carrinho, descomentar a linha 76 da PromocaoController; 

A promocao que possui restricao para Cinema e Filme, A restricao de cada encontra-se setada no banco com o ID correspondente. Nesse caso, está setado Coringa (22050) pro Roxy (17). Caso queira mudar, só alterar o script de insercao na restricao  de Filme e na Restricao de Cinema

Banco de Dados
- Rodar o script da pasta 'Script'
- Alterar no arquivo 'appsettings.json' as configurações de conexão


Como consumir:

Após rodar o projeto, abrirá uma página no navegador padrão. 
Nessa página há um campo para importação do JSON (como não sabia como trazer essas informações para cá, setei dessa forma).
Após enviar o JSON, aparecerá na tela o valor do desconto e a descrição da promoção.



Dependencias
- sdk 2.2 
- pacotes nuGet:
* Microsoft.EntityFrameworkCore (design e tool) (2.2.0)
* MySqlConnector
* Pomelo.EntityFrameworkCore.MySql (2.2.0)
- base de dados MYSQL

 