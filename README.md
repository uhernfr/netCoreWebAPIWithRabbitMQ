# Net Core API usando RabbitMQ
Projeto Exemplo de WebAPI com Producer / Consumer usando RabbitMQ

### Resumo
Este projeto tem como objetivo:
- Utilizar RabbitMQ para gravação de mensagem na fila
- Utilizar RabbitMQ para leitura de mensagem na fila

### Como executar o projeto
- **Step 1: Baixar e executar imagem docker com RabbitMQ presente no docker Hub.**
> https://hub.docker.com/_/rabbitmq

Comando para baixar imagem:
>***docker pull rabbitmq***

Comando para executar imagem na porta 15672
> ***docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management***


- **Step 2: Verificar Acesso ao RabbitMQ**

url: 
>http://127.0.0.1:1567/
**user:** guest 
**password:** guest

- **Step 3 -WebAPI**

Efetuar clone do projeto 
>cd\
mkdir repo
cd repo
git clone https://github.com/uhernfr/netCoreWebAPIWithRabbitMQ.git

Restore, Build
>dotnet restore
dotnet build
dotnet run --p netCoreWebAPIWithRabbitMQ

Swagger
> url: http://localhost:5000/index.html

Endpoints: 
>**POST** /api/RabbitMQProducer - grava conteudo do parametro message na fila
**GET** /api/RabbitMQConsumer - le o conteudo da fila
