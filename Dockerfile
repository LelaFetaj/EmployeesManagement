FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5001

ENV ASPNETCORE_URLS=http://+:5001

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["EmployeeManagementAPI/EmployeeManagementAPI.csproj", "EmployeeManagementAPI/"]
RUN dotnet restore "EmployeeManagementAPI/EmployeeManagementAPI.csproj"
COPY . .
WORKDIR "/src/EmployeeManagementAPI"
RUN dotnet build "EmployeeManagementAPI.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "EmployeeManagementAPI.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeManagementAPI.dll"]
