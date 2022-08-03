FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /learncsharp
COPY ["learncsharp.csproj", "./"]
COPY . .
RUN dotnet restore "learncsharp.csproj"

WORKDIR /learncsharp
RUN dotnet publish -c release -o /app --no-restore

RUN apt-get update && apt-get install -y wget ca-certificates gnupg \
&& echo 'deb http://apt.newrelic.com/debian/ newrelic non-free' | tee /etc/apt/sources.list.d/newrelic.list \
&& wget https://download.newrelic.com/548C16BF.gpg \
&& apt-key add 548C16BF.gpg \
&& apt-get update \
&& apt-get install -y newrelic-netcore20-agent \
&& rm -rf /var/lib/apt/lists/*

FROM base AS final
WORKDIR /app
COPY --from=build /app ./
ENV ASPNETCORE_URLS http://*:443
ENTRYPOINT ["dotnet", "learncsharp.dll"]
