FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["./WizardEmporium.Common/", "WizardEmporium.Common/"]
COPY ["./WizardEmporium.Store/" ,"WizardEmporium.Store/"]
RUN dotnet restore WizardEmporium.Store/WizardEmporium.Store.csproj

WORKDIR /src/WizardEmporium.Store
RUN dotnet publish WizardEmporium.Store.csproj -c Release -o /app --no-restore

FROM base AS final
WORKDIR /app
COPY --from=build /app .
COPY ["./WizardEmporium.Store/WizardEmporium.Store.db", "app/"]
ENTRYPOINT ["dotnet", "WizardEmporium.Store.dll"]