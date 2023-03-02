FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ESchoolWeb/ESchoolWeb.csproj", "ESchoolWeb/"]
RUN dotnet restore "ESchoolWeb/ESchoolWeb.csproj"
COPY . .
WORKDIR "/src/ESchoolWeb"
RUN dotnet build "ESchoolWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ESchoolWeb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ESchoolWeb.dll"]
