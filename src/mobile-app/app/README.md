# GardenAPP a part of [CoinGarden.World](https://coingarden.world/) 


## Used Technologies 

| Package | Description |
| - | - | 
| [Mapster](https://github.com/MapsterMapper/Mapster) | Writing mapping methods is a machine job. Do not waste your time, let Mapster do it. |
| [Mapster Tool](https://github.com/MapsterMapper/Mapster/wiki/Mapster.Tool) | No need to write your own DTO classes. Mapster provides Mapster.Tool to help you generating models. And if you would like to have explicit mapping, Mapster also generates mapper class for you. |

## Security 

[Web API built with ASP.NET Core using the Azure AD B2C](https://learn.microsoft.com/en-us/samples/azure-samples/active-directory-aspnetcore-webapp-openidconnect-v2/how-to-secure-a-web-api-built-with-aspnet-core-using-the-azure-ad-b2c/)
* [JWT Bearer JSON Web Tokens (JWTs)](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)

[Role-based authorization](https://learn.microsoft.com/en-us/aspnet/core/security/authorization/roles?view=aspnetcore-7.0)


[Rate limiting middleware](https://learn.microsoft.com/en-us/aspnet/core/performance/rate-limit?view=aspnetcore-7.0)
* Permit Limit per 60 Seconds : 20 API Request

## Infrastructure 

### [OpenAPI Documentation with Swagger](https://learn.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-7.0)

> URL : https://plant-api.azurewebsites.net/swagger/index.html

![infrastructure](https://learn.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger/_static/swagger-ui.png?view=aspnetcore-7.0)  

### [OData Protocol REST APIs](https://learn.microsoft.com/en-us/odata/overview)

> URL : https://plant-api.azurewebsites.net/$odata

![infrastructure](https://learn.microsoft.com/en-us/odata/assets/library-relationship.png)  

### [Real Time Communication with Azure SignalR Management](https://learn.microsoft.com/en-us/azure/azure-signalr/signalr-overview)

> URL : https://plant-api.azurewebsites.net/chathub
> URL : https://plant-api.azurewebsites.net/notificationshub

![infrastructure](https://github.com/s2kdesign-com/CoinGardenWorld/blob/main/docs/assets/signalr-mobile-app.png?raw=true)  

