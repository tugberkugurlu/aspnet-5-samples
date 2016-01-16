## Simple HTTP Load Balancing with ASP.NET 5, NGINX, Docker and Docker Compose 

`cd` into here and run `docker-compose up`. From the host machine, hit `http://localhost:5000` and you should see hello message from two different machines coming in randomly.

> This is just for the demo purposes to show how simple it is to have an environment like this up an running locally. This probably provides no performance gains when you run all containers in one box.

### Resources

 - http://anandmanisankar.com/posts/docker-container-nginx-node-redis-example/
 - https://blog.rendle.io/asp-net-5-dnx-beta8-connection-refused-in-docker/
 - http://stackoverflow.com/q/34821881/463785
 - https://www.youtube.com/watch?v=yQvcHy_tPjI
