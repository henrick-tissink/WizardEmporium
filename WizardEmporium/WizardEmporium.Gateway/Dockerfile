FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["./WizardEmporium.Gateway/" ,"WizardEmporium.Gateway/"]
RUN dotnet restore WizardEmporium.Gateway/WizardEmporium.Gateway.csproj

WORKDIR /src/WizardEmporium.Gateway
RUN dotnet publish WizardEmporium.Gateway.csproj -c Release -o /app --no-restore

FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "WizardEmporium.Gateway.dll"]