# Microservice Architecture And Implementation .NET

https://github.com/mehmetozkaya/AspnetMicroservices

## Generals

### Docker general commands
```
docker ps
stop all containers : docker stop $(docker ps -aq)
remove all containers : docker rm $(docker ps -aq) --force
remove all images : docker rmi $(docker images -q)
remove unnamed images : docker system prune
docker start shopping-mongo
docker run -d -p 27017:27017 --name shopping-mongo mongo
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down
```



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

- Run *Catalog.API* microservice **locally**
    - In *appsettings.Development.json*, set : "ConnectionString": "mongodb://localhost:27017"
    - if container already exixting : docker start shopping-mongo
    - if container not exixting : docker run -d -p 27017:27017 --name shopping-mongo mongo
    - Hit **Catalog.API**

- Run *Catalog.API* microservice **containerized**
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

- Run *Basket.API* microservice **locally**
    - docker run -d -p 6379:6379 --name aspnetrun-redis redis
    - or : docker start aspnetrun-redis
    - Hit **Basket.API**

- Run *Basket.API* microservice **containerized**
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



## Discount.API with PostgreSQL

1. Package Manager Command

- Install-Package Npgsql 
- Install-Package Dapper 
- Update-Package -ProjectName Discount.API

2. steps : 
- docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
- go to **portainer** : http://localhost:9000

<img src="/pictures/portainer_discount.png" title="portainer"  width="800">

- go to **pgadmin** : http://localhost:5050

<img src="/pictures/pgadmin.png" title="portainer"  width="800">

- click **Add New Server** and add *DiscountServer*, *discountdb*, username and password

<img src="/pictures/pgadmin1.png" title="portainer"  width="300">
<img src="/pictures/pgadmin2.png" title="portainer"  width="300">

- You should now see a successfully created database :

<img src="/pictures/pgadmin3.png" title="portainer"  width="800">

- Inside the *pgadmin* portal, *Tools/Query Tool*, create new tables with the help of *discount.sql*, the add some data :

<img src="/pictures/pgadmin4.png" title="portainer"  width="400">
<img src="/pictures/pgadmin5.png" title="portainer"  width="400">

3. Run *Discount.API* microservice **locally**
    - docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down
    - run : docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
    - Hit **Discount.API**

<img src="/pictures/discount_local.png" title="portainer"  width="800">

- Run *Discount.API* microservice **containerized**
    - run : docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
    - go to : http://localhost:8002/swagger/index.html
    - docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down



## Discount.Grpc 

1. Package Manager Command
```
Install-Package Npgsql 
Install-Package Dapper 
Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection 
Update-Package -ProjectName Discount.Grpc
```

2. Add **Connected Services** : 

- Go to the *Basket.API* project 
- add a service reference :

<img src="/pictures/connected_services.png" title="connected services"  width="800">

- Select *discount.proto* and *client* :

<img src="/pictures/connected_services2.png" title="connected services"  width="800">

3. Run all microservice **locally**
    - docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down
    - Force rebuild of *basket.api* : docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d --build
    - go to *catalog.api* : http://localhost:8080/swagger/index.html
    - go to *basket.api* : http://localhost:8001/swagger/index.html
    - go to **portainer** : http://localhost:9000
    - go to **pgadmin** : http://localhost:5050

- click **Add New Server** and add *DiscountServer*, *discountdb*, username and password

<img src="/pictures/pgadmin1.png" title="portainer"  width="300">
<img src="/pictures/pgadmin2.png" title="portainer"  width="300">

- You should now see the previously created tables :

<img src="/pictures/pgadmin6.png" title="portainer"  width="500">



## Ordering

### Packages

1. Package Manager Command in **Ordering.API**
```
Install-Package AutoMapper
Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection
Install-Package MassTransit
```

2. Package Manager Command in **Ordering.Application**
```
Install-Package MediatR.Extensions.Microsoft.DependencyInjection 
Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection 
Install-Package AutoMapper
Install-Package Microsoft.Extensions.Logging.Abstractions  
Install-Package FluentValidation 
Install-Package FluentValidation.DependencyInjectionExtensions
Install-Package Microsoft.EntityFrameworkCore.Tools
```

3. Package Manager Command in **Ordering.Infrastructure**
```
Install-Package AutoMapper
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package MassTransit
Install-Package SendGrid
```

2. Migrate to database in **Ordering.Application**
```
Add-Migration InitialCreate
```

### Steps

2. steps : 
- docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
- go to  : http://localhost:9000

<img src="/pictures/portainer_discount.png" title="portainer"  width="800">













