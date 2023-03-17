# GameStreamer.Backend
This solution is the backend part of the Ultimate TicTacToe Game

## Used architecture and technologies

### Arch
Clean Architecture with implemented Domain Driven Design (DDD) practices

### Technologies
Message Broker (RabbitMQ)
Storage (PostgreSQL)
ORM (EF Core) - Commands, (Dapper) - Queries

### Patterns
CQRS, Outbox Pattern, Dependency Injection, Mediator, Pub/Sub, Fabric

### Deploy and Run
Solution boxed into a Docker container for simplified deploy on VPS

Commands for building and starting Docker container locally:
1) Open cmd in folder with Dockerfile
2) docker build -t game-streamer-local:your_tag .
    (For Example: docker build -t game-streamer-local:0.0.1 .)
3) docker run -d -it --name=GameStreamer-Backend game-streamer-local:your_tag --env "ASPNETCORE_ENVIRONMENT=Production"
    (For Example: docker run -d -it --name=GameStreamer-Backend -p 8080:80 game-streamer-local:0.0.1 --env "ASPNETCORE_ENVIRONMENT=Production")

### (!!!) Important information
**
For local deploy you have to download and run project docker-local-environment which place is here:
https://github.com/Gosha94/My-Dev-Environment.git
**
