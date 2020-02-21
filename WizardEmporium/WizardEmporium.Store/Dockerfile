FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY ["./bin/Release/netcoreapp3.1/publish/", "app/"]
COPY ["WizardEmporium.Store.db", "app/"]
WORKDIR /app

EXPOSE 5000
EXPOSE 5001

ENTRYPOINT ["dotnet", "WizardEmporium.Store.dll"]