
  

# Docker containers using docker-compose to create multiple services
 

A Sample Application implementing and integrating multiple docker services for communication using docker-compose. includes aspnet **Core Web API**, frontend spa app using **Angular**, **RabbitMQ**, **Redis** cache, **SqlServer**, **azure functions**, **Azurite** azure storage emulator, and **NginX** gateway with ssl using local CA.

  *this cluster is not production ready.* you will need to extend the cluster before use in prod environments. 

# Local Debugging

add the following lines to your hosts file:

     #docker
    127.0.0.1 rabbitmq
    127.0.0.1 redis
    127.0.0.1 azfunc
    127.0.0.1 azurite

 then run the following command to create the docker cluster:

    ./compose.cmd

  

# Docker Compose

  

Docker-Compose is a configuration file which contains instructions for the Docker about how services should be built from respective Dockerfiles. While a Dockerfile aims at creating and customizing application containers by means of base images and instructions, the Docker-Compose file works on top of the Dockerfile and helps developers in running docker containers with complex runtime specifications such as ports, volumes and so on.

   

# Frameworks & versions
- Angular 12.x
- WebApi net 6.0-preview
- Azure functions isolated process
- Function sdk v4-preview
- Azurite for azure storage emulation
- SQL Server
- Redis Cache and redis-insight web
- RabbitMQ and management site
- Nginx exposing the client angular app and web api
