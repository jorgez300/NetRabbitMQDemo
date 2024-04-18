#  .NET 6 Project with RabbitMQ

Created for demostration purposes.

Send and consume messages using RabbitMQ.


##  Docker command

    docker run -d --hostname rmpdemo --name rabbit-demo -p 15000:15672 -p 5672:5672 rabbitmq:3-management

navigate to localhost:15000, should open the RabbitMQ dashboard

    user: guest
    pass: guest

## Projects Setup

Set all console apps (Sender, Receiver1, Receiver2) as multiple startup projects.

Parameters and configuration are in the RabbitMQLibrary -> RabbitMQContext
