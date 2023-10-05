## Development information

## 🧱 Projects Structure
```
 📂src
 ┣ 📂back-end
 ┃ ┣ 📂shared
 ┃ ┃  ┗ 📦 Nuget Packages (.NET 7)
 ┃ ┗ 📡 API / GRPC Projects
 ┣ 📂front-end
 ┃ ┣ 📂shared
 ┃ ┃  ┗ 📦 Nuget Packages (.NET 7)
 ┃ ┗ 🖼️ Front-end themes (Blazor .NET)
 ┣ 📂smart-contracts
 ┃ ┣ 📂nft-contracts
 ┃ ┃ ┗ 📜 Flower.sol (Solidity)
 ┃ ┣ 📂exchange
 ┃ ┃ ┗ 📜 GRDNToken.sol (Solidity)
 ┣ 📂landing-page
 ┃ ┗ 🔗 Official Site (Blazor WebAssembly, PWA)
 ┣ 📂nft-market
 ┃ ┗ ⛓️ NFT Store Web3 DApp (Blazor WebAssembly, PWA)
 ┣ 📂charity-page
 ┃ ┗ ⛓️ Charity Web3 DApp (Blazor WebAssembly, PWA)
 ┣ 📂exchange
 ┃ ┗ ⛓️ Exchange Web3 DApp (Blazor WebAssembly, PWA)
 ┣ 📂metaverse
 ┃ ┣ 🔗 Metaverse Site (Blazor WebAssembly, PWA)
 ┃ ┗ 🌐 Metaverse (Unity C#)
 ┗ 📂mobile-apps
   ┣ 🔗 Mobile Application Site (Blazor WebAssembly, PWA)
   ┗ 📱 Mobile Applications, Android, IOS, Windows  (.NET Multi-platform App UI)
```
# 📦 Packages
## 🖼️ Nuget Packages - Shared Frond-end Blazor components  📦

| Package | Type | Registry | Link | Status |
| - | - | - | - | - | 
| Moralis Metamask Components |  Nuget | Github Package Registry | [Latest](https://coingarden.world) | |

## 📡 Nuget Packages - Shared Back-end Azure Functions  📦

| Package | Type | Registry | Link | Status |
| - | - | - | - | - | 
| Moralis Azure Functions | Nuget | Github Package Registry | [Latest](https://coingarden.world) | |

---

# 🏗️ Used technologies

| Technology | Description | Link |
| - | - | - |
| Moralis | Moralis provides enterprise-grade Web3 APIs that connect any tech stack to blockchain networks, providing top-of-the-line Web3 backend services;  | [moralis.io](https://moralis.io/) |
| Filecoin | Filecoin is a peer-to-peer network that allows anyone to store and retrieve data on the internet. Built-in economic incentives ensure that files are stored and retrieved reliably and continuously for however long a user specifies. | [filecoin.io](https://filecoin.io/) | 
| Chainlink | Chainlink expands the capabilities of smart contracts by enabling access to real-world data and off-chain computation while maintaining the security and reliability guarantees inherent to blockchain technology. | [chain.link](https://chain.link/) |
| .NET 7 Blazor | Blazor lets you build interactive web UIs using C# instead of JavaScript. Blazor apps are composed of reusable web UI components implemented using C#, HTML, and CSS. Both client and server code is written in C#, allowing you to share code and libraries.  | |
| .NET 6 MAUI | .NET MAUI unifies Android, iOS, macOS, and Windows APIs into a single API that allows a write-once run-anywhere developer experience, while additionally providing deep access to every aspect of each native platform. | [learn.microsoft.com](https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui) |
| gRPC on .NET | gRPC is a modern open source high performance Remote Procedure Call (RPC) framework that can run in any environment. It can efficiently connect services in and across data centers with pluggable support for load balancing, tracing, health checking and authentication. It is also applicable in last mile of distributed computing to connect devices, mobile applications and browsers to backend services. | [grpc.io](https://grpc.io/) |
| Azure Functions | Azure Function is a serverless compute service that enables user to run event-triggered code without having to provision or manage infrastructure. Being as a trigger-based service, it runs a script or piece of code in response to a variety of events. | [learn.microsoft.com](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) | 
| Azure Active Directory B2C | Azure AD B2C is a customer identity access management (CIAM) solution capable of supporting millions of users and billions of authentications per day. It takes care of the scaling and safety of the authentication platform, monitoring, and automatically handling threats like denial-of-service, password spray, or brute force attacks. | [learn.microsoft.com](https://learn.microsoft.com/en-us/azure/active-directory-b2c/overview) |

---
## Infrastructure 

### Splitted to folders with the idea, that if this repository became to big, it will be splitted to different submodules (check picture bellow how to checkout the code when that happens)
### All builds and deployments will be splitted too and when changes are made to some submodule it will be the only one build and deployed 
---

![infrastructure](https://github.com/s2kdesign-com/CoinGardenWorld/blob/main/src/official-website/CoinGardenWorld.Web/wwwroot/social-logo-1276x739.png?raw=true) 
![infrastructure](https://github.com/s2kdesign-com/CoinGardenWorld/blob/main/src/mobile-app/site/CoinGardenWorldMobileApp.Web/wwwroot/mobileapp_social_logo_1236x730.webp?raw=true) 
![infrastructure](https://github.com/s2kdesign-com/CoinGardenWorld/blob/main/src/nft-market/site/CoinGardenWorldStore.Web/wwwroot/images/nftstore_social_logo.webp?raw=true) 
![infrastructure](https://github.com/s2kdesign-com/CoinGardenWorld/blob/main/src/garden-bot/CoinGardenBotCore.Web/wwwroot/bot_social_logo_1237x730.webp?raw=true)

