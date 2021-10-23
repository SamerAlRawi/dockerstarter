
# Docker containers using docker-compose to create multiple services
  

A Sample Application implementing and integrating multiple docker services for communication using docker-compose. includes aspnet **Core Web API**, frontend **Angular** application, **RabbitMQ**, **Redis** cache, **SqlServer**, and **azure function** and **NginX** gateway with ssl using local CA. 

# Local Debugging  
add the following lines to your hosts file:

  #docker
  127.0.0.1 rabbitmq
  127.0.0.1 redis
  127.0.0.1 azfunc
  127.0.0.1 azurite

run compose.cmd 

# What is Docker Compose?

  Docker-Compose is a configuration file which contains instructions for the Docker about how services should be built from respective Dockerfiles. While a Dockerfile aims at creating and customizing application containers by means of base images and instructions, the Docker-Compose file works on top of the Dockerfile and helps developers in running docker containers with complex runtime specifications such as ports, volumes and so on.

  

# frameworks versions

- Angular 12.x
- Azure functions isolated process
- net6.0-preview
- Function sdk v4-preview
- WebApi net 6.0
