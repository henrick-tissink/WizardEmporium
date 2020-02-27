FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["./WizardEmporium.Common/", "WizardEmporium.Common/"]
COPY ["./WizardEmporium.User/" ,"WizardEmporium.User/"]
RUN dotnet restore WizardEmporium.User/WizardEmporium.User.csproj

WORKDIR /src/WizardEmporium.User
RUN dotnet publish WizardEmporium.User.csproj -c Release -o /app --no-restore

FROM base AS final
WORKDIR /app
COPY --from=build /app .
COPY ["./WizardEmporium.User/WizardEmporium.User.db", "app/"]
ENTRYPOINT ["dotnet", "WizardEmporium.User.dll"]