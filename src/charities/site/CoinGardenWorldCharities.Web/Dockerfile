FROM mcr.microsoft.com/dotnet/sdk:7.0 AS publish
WORKDIR /src
COPY . .
RUN dotnet publish "charities/site/CoinGardenWorldCharities.Web/CoinGardenWorldCharities.Web.csproj" -c Release -o /app/publish

# Release NGINX
FROM nginx:alpine AS final
RUN apk add bash icu-libs krb5-libs libgcc libintl libssl1.1 libstdc++ zlib
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY charities/site/CoinGardenWorldCharities.Web/nginx.conf /etc/nginx/nginx.conf
SHELL ["/bin/bash", "-c"]
CMD /usr/sbin/nginx -g "daemon off;"
EXPOSE 80