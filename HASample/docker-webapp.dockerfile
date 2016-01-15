FROM microsoft/aspnet:1.0.0-rc1-update1

COPY ./WebApp/project.json /app/WebApp/
COPY ./NuGet.Config /app/
COPY ./global.json /app/
WORKDIR /app/WebApp
RUN ["dnu", "restore"]
ADD ./WebApp /app/WebApp/

EXPOSE 5090
ENTRYPOINT ["dnx", "run"]
