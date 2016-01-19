FROM microsoft/aspnet:1.0.0-rc1-update1

COPY ./Stores/project.json /app/Stores/
COPY ./NuGet.Config /app/
COPY ./global.json /app/
WORKDIR /app/Stores
RUN ["dnu", "restore"]
ADD ./Stores /app/Stores/

EXPOSE 5090
ENTRYPOINT ["dnx", "run"]
