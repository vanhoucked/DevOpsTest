FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Server/Project.Server.csproj", "src/Server/"]
COPY ["src/Client/Project.Client.csproj", "src/Client/"]
COPY ["src/Shared/Project.Shared.csproj", "src/Shared/"]
COPY ["src/Services/Project.Services.csproj", "src/Services/"]
COPY ["src/Domain/Project.Domain.csproj", "src/Domain/"]
COPY ["src/Persistence/Project.Persistence.csproj", "src/Persistence/"]
RUN dotnet restore "src/Server/Project.Server.csproj"

COPY . .
WORKDIR "/src/src/Server/"
RUN dotnet build "Project.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Project.Server.dll"]