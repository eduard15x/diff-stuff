# RabbitMQ Examples

# Running a docker container with management package attached
* docker run -d --hostname rmq --name rabbit-server -p 8080:15672 -p 5672:5672 rabbitmq:3-management

## You can visit the Management UI in your browser:
* URL: http://localhost:8080
## Default credentials:
* Username: guest
* Password: guest
## Applications or services can connect to RabbitMQ using 
* amqp://* localhost:5672

## COMMANDS
### docker run
This is the command to create and start a new Docker container from an image.

### -d
This flag runs the container in "detached mode."
Detached mode means the container runs in the background, and the terminal won’t be blocked by the container's logs.

### --hostname rmq
This sets the hostname of the container to rmq.
Inside the container, the hostname will appear as rmq instead of a randomly generated string.

### --name rabbit-server
Assigns a custom name, rabbit-server, to the container.
This makes it easier to reference the container later (e.g., when using docker stop rabbit-server or docker logs rabbit-server).

### -p 8080:15672
Maps the RabbitMQ Management Web Interface (inside the container, running on port 15672) to your local machine's port 8080.
Access it by opening http://localhost:8080 in your browser.
Format: -p <host_port>:<container_port>

### -p 5672:5672
Maps RabbitMQ’s main communication port (inside the container, running on port 5672) to your local machine's port 5672.
This port is used by applications to connect to RabbitMQ for message queuing (e.g., producers and consumers).
Format: -p <host_port>:<container_port>

### -p rabbitmq:3-management
Specifies the Docker image to use.
rabbitmq:3-management is a RabbitMQ image with the management plugin pre-installed, allowing you to manage RabbitMQ via a web interface (on port 15672).
The 3 represents the RabbitMQ version.
