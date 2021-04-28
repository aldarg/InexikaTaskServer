FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /usr/server_app
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out
WORKDIR /usr/server_app/out
ENTRYPOINT ["dotnet", "InexikaTaskServer.dll"]