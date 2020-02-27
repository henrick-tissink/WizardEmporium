FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["./WizardEmporium.Common/", "WizardEmporium.Common/"]
COPY ["./WizardEmporium.Delivery/", "WizardEmporium.Delivery/"]
RUN dotnet restore WizardEmporium.Delivery/WizardEmporium.Delivery.csproj

WORKDIR /src/WizardEmporium.Delivery
RUN dotnet publish WizardEmporium.Delivery.csproj -c Release -o /app --no-restore

FROM base AS final
WORKDIR /app
COPY --from=build /app .
COPY ["./WizardEmporium.Delivery/WizardEmporium.Delivery.db", "app/"]
ENTRYPOINT ["dotnet", "WizardEmporium.Delivery.dll"]