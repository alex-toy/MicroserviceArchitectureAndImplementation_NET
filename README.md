# Microservice Architecture And Implementation .NET

https://github.com/mehmetozkaya/AspnetMicroservices

## Catalog.API with MongoDb

Go inside Developper Powershell

### Package Manager Command

- Install-Package MongoDB.Driver 

### Docker commands 

- Create the Mongo database
    - docker pull mongo
    - docker run -d -p 27017:27017 --name shopping-mongo mongo
    - docker logs -f shopping-mongo
    - docker exec -it shopping-mongo mongosh
    - Run all commands from *mongo_commands.txt*

- Run *Catalog* microservice **locally**
    - if container already exixting : docker start shopping-mongo
    - if container not exixting : docker run -d -p 27017:27017 --name shopping-mongo mongo
    - Hit **Basket.API**

- Run *Catalog* microservice **containerized**
    - docker start shopping-mongo
    - docker run -d -p 27017:27017 --name shopping-mongo mongo
    - docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
    - docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down
    - mogoclient : docker run -d -p 3000:3000 mongoclient/mongoclient
    - Hit Basket.API
    - connect to mongoclient : http://localhost:3000/



## Basket.API with Redis

### Package Manager Command

- Install-Package Microsoft.Extensions.Caching.StackExchangeRedis 
- Update-Package -ProjectName Basket.API

### Docker commands 

- Create the Redis database
    - docker pull redis
    - docker run -d -p 6379:6379 --name aspnetrun-redis redis
    - docker logs -f aspnetrun-redis
    - docker exec -it aspnetrun-redis /bin/bash
    - redis-cli
    - set key value
    - get key

- Run *Basket* microservice
    - docker ps



## Generals

### Docker general commands
    - docker ps
    - remove all containers : docker stop $(docker ps -aq)
    - remove all images : docker rmi $(docker images -q)
    - remove unnamed images : docker system prune
    - docker start shopping-mongo
    - docker run -d -p 27017:27017 --name shopping-mongo mongo
    - docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
    - docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down






















