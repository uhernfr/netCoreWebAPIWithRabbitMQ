# netCoreWebAPIWithRabbitMQ
Projeto Exemplo de WebAPI com Producer / Consumer usando RabbitMQ

Necessário baixar e executar imagem docker com RabbitMQ presente no docker Hub:
https://hub.docker.com/_/rabbitmq

:: Comando para baixar imagem:
docker pull rabbitmq

:: Comando para executar imagem na porta 15672
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management

:: Acesso ao RabbitMQ:
url: http://127.0.0.1:1567/
user guest - password guest

:: WebAPI
url: http://localhost:8226/index.html

endpoints: 
POST /api/RabbitMQProducer - grava conteudo do parametro message na fila
GET /api/RabbitMQConsumer - le o conteudo da fila
