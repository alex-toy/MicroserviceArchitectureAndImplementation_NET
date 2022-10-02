# Microservice Architecture And Implementation .NET

https://github.com/mehmetozkaya/AspnetMicroservices

## Catalog.API with MongoDb

Go inside Developper Powershell

1. Package Manager Command

- Install-Package MongoDB.Driver 

2. Docker commands 

- Create the Mongo database
    - docker pull mongo
    - docker run -d -p 27017:27017 --name shopping-mongo mongo
    - docker logs -f shopping-mongo
    - docker exec -it shopping-mongo mongosh
    - Run all commands from *mongo_commands.txt*
    
- Before the following steps, you may need to do some cleaning :
    - stop all containers :     docker stop $(docker ps -aq)
    - remove all containers :   docker rm $(docker ps -aq)
    - remove all images :       docker rmi $(docker images -q)
    - in case it was up :       docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down

- Run *Catalog* microservice **locally**
    - In *appsettings.Development.json*, set : "ConnectionString": "mongodb://localhost:27017"
    - if container already exixting : docker start shopping-mongo
    - if container not exixting : docker run -d -p 27017:27017 --name shopping-mongo mongo
    - Hit **Catalog.API**

- Run *Catalog* microservice **containerized**
    - In *appsettings.Development.json*, set : "ConnectionString": "mongodb://catalogdb:27017"
    - run : docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
    - go to : http://localhost:8080/swagger/index.html
    - docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down

<img src="/pictures/catalog_swagger.png" title="catalog swagger"  width="800">

- Debug
    - mogoclient : docker run -d -p 3000:3000 mongoclient/mongoclient
    - connect to mongoclient : http://localhost:3000/
    - docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down



## Basket.API with Redis

1. Package Manager Command

- Install-Package Microsoft.Extensions.Caching.StackExchangeRedis 
- Update-Package -ProjectName Basket.API

2. Docker commands 

- Create the Redis database
    - docker pull redis
    - docker run -d -p 6379:6379 --name aspnetrun-redis redis
    - docker logs -f aspnetrun-redis
    - docker exec -it aspnetrun-redis /bin/bash
    - redis-cli
    - set key value
    - get key

- Run *Basket* microservice **locally**
    - docker run -d -p 6379:6379 --name aspnetrun-redis redis
    - or : docker start aspnetrun-redis
    - Hit **Basket.API**

- Run *Basket* microservice **containerized**
    - In *appsettings.Development.json*, set : "ConnectionString": "mongodb://basketdb:27017"
    - run : docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
    - go to : http://localhost:8001/swagger/index.html
    - docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down

<img src="/pictures/basket_swagger.png" title="basket swagger"  width="800">



## DummyCookie.API with Redis

1. Package Manager Command

- Install-Package Microsoft.Extensions.Caching.StackExchangeRedis 
- Update-Package -ProjectName DummyCookie

2. Docker commands 

- Create the Redis database
    - docker pull redis
    - docker run -d -p 6380:6380 --name cookie-redis redis
    - docker exec -it cookie-redis /bin/bash

- Run *DummyCookie* microservice **locally**
    - docker run -d -p 6380:6380 --name cookie-redis redis
    - or : docker start cookie-redis
    - Hit **DummyCookie**



## Portainer

- run : docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
- go to : http://localhost:9000
- Create a user

<img src="/pictures/portainer.png" title="portainer"  width="800">



## Generals

### Docker general commands
    - docker ps
    - stop all containers : docker stop $(docker ps -aq)
    - remove all containers : docker rm $(docker ps -aq) --force
    - remove all images : docker rmi $(docker images -q)
    - remove unnamed images : docker system prune
    - docker start shopping-mongo
    - docker run -d -p 27017:27017 --name shopping-mongo mongo
    - docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
    - docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down






















