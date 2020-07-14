# hammerconsult
Para rodar o projeto via docker 

vá até a raiz do projeto e execute este comando. 
docker-compose -f docker-compose.yml -p teste_geovane up api 

Para criar as tabelas vá até a API e depois Infra e  rode o seguinte comando. 
	dotnet ef database update

Após isso troque a connectionstring e aponte para um banco de dados sql caso rode no docker apenas troque o IP da connection string. 

Na raiz do projeto tem uma collection do postman com os endPoints, para usar troque a variável de ambiente chamada  host para o ip da aplicação. 
 Caso rode pelo VS  com a opção API coloque este conteúdo na variável: https://localhost:5001

se usar docker coloque o IP da máquina virtual usando a porta 4000.

