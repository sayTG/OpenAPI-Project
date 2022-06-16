#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CompliantAPI/CompliantAPI.csproj", "CompliantAPI/"]
RUN dotnet restore "CompliantAPI/CompliantAPI.csproj"
COPY ["CompliantAPI.Tests/CompliantAPI.Tests.csproj", "CompliantAPI.Tests/"]
RUN dotnet restore "CompliantAPI.Tests/CompliantAPI.Tests.csproj"
COPY . .
WORKDIR "/src/CompliantAPI.Tests"
RUN dotnet test "CompliantAPI.Tests.csproj"
WORKDIR "/src/CompliantAPI"
RUN dotnet build "CompliantAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CompliantAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompliantAPI.dll"]