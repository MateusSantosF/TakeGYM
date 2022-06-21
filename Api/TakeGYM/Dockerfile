FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine3.11 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine3.11 AS build
WORKDIR /src
COPY ["TakeGYM.Facades/TakeGYM.Facades.csproj", "TakeGYM.Facades/"]
COPY ["TakeGYM.Models/TakeGYM.Models.csproj", "TakeGYM.Models/"]
COPY ["TakeGYM.Services/TakeGYM.Services.csproj", "TakeGYM.Services/"]
COPY ["TakeGYM/TakeGYM.csproj", "TakeGYM/"]

RUN dotnet restore "TakeGYM/TakeGYM.csproj"
COPY . .
WORKDIR "/src/TakeGYM"
RUN dotnet build "TakeGYM.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TakeGYM.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TakeGYM.dll"]