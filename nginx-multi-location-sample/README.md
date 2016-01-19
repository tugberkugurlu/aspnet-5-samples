## Geting two Applications Behind NGINX and Serving them Through One Host

`cd` into here and run `docker-compose up`. From the host machine, run below commands:

```
curl http://localhost:5000/stores -D - -w "\n"
curl http://localhost:5000/products -D - -w "\n"
```

### Resources

 - http://serverfault.com/questions/376162/how-can-i-create-a-location-in-nginx-that-works-with-and-without-a-trailing-slas
 - http://stackoverflow.com/questions/12849584/automatically-add-newline-at-end-of-curl-response-body