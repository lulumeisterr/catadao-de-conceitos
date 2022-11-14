# Criacao de etapa de Build a partir do sdk da microsoft
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app
COPY . .
RUN dotnet restore "Gateway.csproj"
RUN dotnet publish "Gateway.csproj" -c Release -o out

                ## Aplicando Multi-Stage Build ##
# Consumindo o build a partir da /app/out utilizando apenas o runtime do .netcore 6
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Gateway.dll"]


