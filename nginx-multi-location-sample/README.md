## Geting two Applications Behind NGINX and Serving them Through One Host

`cd` into here and run `docker-compose up`. From the host machine, run below commands:

```bash
curl http://localhost:5000/stores -D - -w "\n"
curl http://localhost:5000/products -D - -w "\n"
```

You should see responses like below:

```
tugberk@ubuntu:~/gifs$ curl http://localhost:5000/stores -D - -w "\n"
HTTP/1.1 200 OK
Server: nginx/1.9.9
Date: Tue, 19 Jan 2016 22:46:23 GMT
Content-Type: application/json; charset=utf-8
Transfer-Encoding: chunked
Connection: keep-alive
RequestId: 0HKP143P3IODS

["Store 1","Store 2","Store 3"]
```

```
tugberk@ubuntu:~/gifs$ curl http://localhost:5000/products -D - -w "\n"
HTTP/1.1 200 OK
Server: nginx/1.9.9
Date: Tue, 19 Jan 2016 22:47:09 GMT
Content-Type: application/json; charset=utf-8
Transfer-Encoding: chunked
Connection: keep-alive
RequestId: 0HKP1481M41GI

["Product 1","Product 2","Product 3"]
```

### Resources

 - http://serverfault.com/questions/376162/how-can-i-create-a-location-in-nginx-that-works-with-and-without-a-trailing-slas
 - http://stackoverflow.com/questions/12849584/automatically-add-newline-at-end-of-curl-response-body