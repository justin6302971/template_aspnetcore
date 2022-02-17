# sample asp net core project
n-tier

## Prerequisite
* Asp net core (3.1)
* postgreSQL(12)
* EF core 6(3.1.16)
* Swagger
* Database First 
* Design Pattern(DDD and Software Layered Architecture Pattern)
* DI and IoC

## Implementation (remain done)
* SP.WebApi (CRUD with swagger) 
* containerize app with Docker and run with docker compose

## Step
1. run postgre local db with docker compose cmd 
2. run app locally to give it a try


## Scripts And Notes

### db 
``` bash
# setting up .env file 
echo "custom env"

# start postgre db
docker-compose up -d

# stop and cleanup postgre db
docker-compose down

# access postgreSql database host in docker via terminal
docker exec -it local_postgredb_dev sh

psql -d exampledb -U [username] -W
```


### dotnet core app
``` bash 
# https certificate for local machine
dotnet dev-certs https --trust
# path to key chain: /Users/justinchien/Library/Keychains/login.keychain-db


# add project reference
dotnet add reference [project_path]

# db first 
# notice:make sure project path is correct and execute commands
dotnet ef dbcontext scaffold Name=ConnectionStrings:SpConnectionString Npgsql.EntityFrameworkCore.PostgreSQL -o Models --context-dir DataContext -c SpDataContext -p ./SP.Data/SP.Data.csproj -s ./SP.WebApi/SP.WebApi.csproj --force
```

## reference
1. [set up db first command](https://stackoverflow.com/questions/46572306/ef-core-2-0-scaffold-dbcontext-find-connectionstring-in-another-project)
2. [design pattern](https://raychiutw.github.io/2019/%E9%9A%A8%E6%89%8B-Design-Pattern-4-Repository-%E6%A8%A1%E5%BC%8F-Repository-Pattern/)
3. [db first tutorial](https://www.devart.com/dotconnect/postgresql/docs/EFCore-Database-First-NET-Core.html)
4. [fb first tutorial 2](https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx)
5. [official doc](https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli)
6. [(ef core and postgresql) : uuid](https://garywoodfine.com/how-to-generate-postgresql-uuid-with-ef-core/)
