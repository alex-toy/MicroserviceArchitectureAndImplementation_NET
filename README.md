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
    -  docker logs -f shopping-mongo
    - docker exec -it shopping-mongo mongosh
    - use CatalogDb
    - db.createCollection('products')
    - db.Products.insert({})

- Run *Catalog* microservice
    - docker ps
    - docker start shopping-mongo
    - docker run -d -p 27017:27017 --name shopping-mongo mongo

### Make sure the following settings are set :

<img src="/pictures/catalog_api_settings.png" title="catalog api settings"  width="600">












