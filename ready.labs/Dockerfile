#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#Start with the base .NET SDK Image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release

#Set the working directory inside the container
WORKDIR /src
COPY ["ready.labs/ready.labs.csproj", "ready.labs/"]

RUN dotnet restore "./ready.labs/./ready.labs.csproj"
COPY . .
WORKDIR "/src/ready.labs"
RUN dotnet build "./ready.labs.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ready.labs.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ready.labs.dll"]