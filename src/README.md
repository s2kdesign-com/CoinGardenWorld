## Development information

## ๐งฑ Projects Structure
```
 ๐src
 โฃ ๐back-end
 โ โฃ ๐shared
 โ โ  โ ๐ฆ Nuget Packages (.NET 7)
 โ โ ๐ก API / GRPC Projects
 โฃ ๐front-end
 โ โฃ ๐shared
 โ โ  โ ๐ฆ Nuget Packages (.NET 7)
 โ โ ๐ผ๏ธ Front-end themes (Blazor .NET)
 โฃ ๐smart-contracts
 โ โฃ ๐nft-contracts
 โ โ โ ๐ Flower.sol (Solidity)
 โ โฃ ๐exchange
 โ โ โ ๐ GRDNToken.sol (Solidity)
 โฃ ๐landing-page
 โ โ ๐ Official Site (Blazor WebAssembly, PWA)
 โฃ ๐nft-market
 โ โ โ๏ธ NFT Store Web3 DApp (Blazor WebAssembly, PWA)
 โฃ ๐charity-page
 โ โ โ๏ธ Charity Web3 DApp (Blazor WebAssembly, PWA)
 โฃ ๐exchange
 โ โ โ๏ธ Exchange Web3 DApp (Blazor WebAssembly, PWA)
 โฃ ๐metaverse
 โ โฃ ๐ Metaverse Site (Blazor WebAssembly, PWA)
 โ โ ๐ Metaverse (Unity C#)
 โ ๐mobile-apps
   โฃ ๐ Mobile Application Site (Blazor WebAssembly, PWA)
   โ ๐ฑ Mobile Applications, Android, IOS, Windows  (.NET Multi-platform App UI)
```
# ๐ฆ Packages
## ๐ผ๏ธ Nuget Packages - Shared Frond-end Blazor components  ๐ฆ

| Package | Type | Registry | Link | Status |
| - | - | - | - | - | 
| Moralis Metamask Components |  Nuget | Github Package Registry | [Latest](https://coingarden.world) | |

## ๐ก Nuget Packages - Shared Back-end Azure Functions  ๐ฆ

| Package | Type | Registry | Link | Status |
| - | - | - | - | - | 
| Moralis Azure Functions | Nuget | Github Package Registry | [Latest](https://coingarden.world) | |

---

# ๐๏ธ Used technologies

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
### How to checkout git submodules

![recurse-submodules](https://github.com/s2kdesign-com/CoinGardenWorld/raw/main/docs/assets/recurse-submodules.png)