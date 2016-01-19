FROM microsoft/aspnet:1.0.0-rc1-update1

COPY ./Products/project.json /app/Products/
COPY ./NuGet.Config /app/
COPY ./global.json /app/
WORKDIR /app/Products
RUN ["dnu", "restore"]
ADD ./Products /app/Products/

EXPOSE 5090
ENTRYPOINT ["dnx", "run"]
