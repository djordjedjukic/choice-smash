FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src
COPY ["src/ChoiceSmash.csproj", "./"]
RUN dotnet restore "ChoiceSmash.csproj"
COPY . .
RUN dotnet publish "ChoiceSmash.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080

ENTRYPOINT ["dotnet", "ChoiceSmash.dll"]