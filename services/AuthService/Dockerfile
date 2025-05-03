# Imagem base do SDK do .NET 6 para build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copia os arquivos de projeto e restaura as dependências
COPY *.csproj ./
RUN dotnet restore

# Copia o restante do código e publica a aplicação
COPY . ./
RUN dotnet publish -c Release -o out

# Imagem base do runtime do .NET 6 para execução
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Define a porta exposta
EXPOSE 80

# Comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "AuthService.dll"]
