# MessageBrokersTests

## Como testar:

- Subir o container do RabbitMQ:

na pasta /container-files, rodar o comando:

```bash
docker-compose up
```

- Acessar o endereço http://localhost:15672/

  >- user: *guest*
  >- password: *guest*

- Criar uma exchange chamada "Exchange"
- Criar uma fila chamada "queue"
- efetuar o binding da exchange com a fila

Para publicar na fila, rodar o ***PublishRabbitMQ***

Para ler a fila, rodar ***ConsumerRabbit***
