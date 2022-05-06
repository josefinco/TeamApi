# TeamApi (API para administração de membros do time)

Projeto para estudo:

Database noSQL  (MongoDB)
Padrão de projeto DDD - WIP
Autenticação e Autorização por JWT - WIP
Docker - TO-DO
Docker Compose - TO-DO
Testes de Carga (K6) TO-DO

### Mongo on Docker 

```
docker pull mongo
```
```
docker run --name mongodb -d -p 27017:27017 -e MONGO_INITDB_ROOT_USERNAME=admin -e MONGO_INITDB_ROOT_PASSWORD=1234567 mongo
```
