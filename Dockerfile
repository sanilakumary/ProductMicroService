FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 57068
EXPOSE 44371

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ProductMicroService/ProductMicroService.csproj ProductMicroService/
RUN dotnet restore ProductMicroService/ProductMicroService.csproj
COPY . .
WORKDIR /src/ProductMicroService
RUN dotnet build ProductMicroService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ProductMicroService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProductMicroService.dll"]
