# .NET MAUI Application Overview - CoinGarden.World Mobile App

## 📱 Executive Summary

This repository contains a **complete and functional .NET MAUI (Multi-platform App UI)** application for the CoinGarden.World platform. The application is a **Blazor Hybrid** mobile app that runs natively on multiple platforms.

## 🎯 Application Location

**Main MAUI Project Path:** `src/mobile-app/app/CoinGardenWorldMobileApp.Maui/`

**Solution File:** `CoinGardenWorld.sln` (root directory)

## 🏗️ Architecture Overview

### Core Technologies
- **.NET 8.0** - Latest .NET framework
- **.NET MAUI** - Multi-platform App UI framework
- **Blazor Hybrid** - Web UI technology within native apps
- **Razor Components** - Component-based UI framework

### Application Components

#### 1. **CoinGardenWorldMobileApp.Maui** (Main MAUI Project)
- **Location:** `src/mobile-app/app/CoinGardenWorldMobileApp.Maui/`
- **Type:** Multi-platform executable application
- **Framework:** Microsoft.NET.Sdk.Razor
- **Target Frameworks:**
  - `net8.0-android` (Android 24.0+)
  - `net8.0-ios` (iOS 14.2+)
  - `net8.0-maccatalyst` (macOS 14.0+)
  - `net8.0-windows10.0.19041.0` (Windows 10+)
  - `net8.0-tizen` (Optional, Tizen 6.5+)

#### 2. **CoinGardenWorldMobileApp.MobileAppTheme** (UI Components Library)
- **Location:** `src/mobile-app/app/CoinGardenWorldMobileApp.MobileAppTheme/`
- **Type:** Razor class library
- **Purpose:** Shared UI components, pages, and styling
- **Features:**
  - Authentication components
  - Localization support (English, Bulgarian)
  - PWA (Progressive Web App) capabilities
  - Azure Application Insights integration
  - SignalR real-time communication

#### 3. **CoinGardenWorldMobileApp.DotNetApi** (Backend API)
- **Location:** `src/mobile-app/app/CoinGardenWorldMobileApp.DotNetApi/`
- **Type:** ASP.NET Core Web API
- **Purpose:** Backend services for the mobile app

#### 4. **CoinGardenWorldMobileApp.Models** (Data Models)
- **Location:** `src/mobile-app/app/CoinGardenWorldMobileApp.Models/`
- **Type:** Class library
- **Purpose:** Shared data models and DTOs

#### 5. **CoinGardenWorldMobileApp.WebApp** (Web Version)
- **Location:** `src/mobile-app/app/CoinGardenWorldMobileApp.WebApp/`
- **Type:** Blazor WebAssembly application
- **Purpose:** Web version of the mobile app

## 🚀 Platform Support

### Supported Platforms

| Platform | OS Version | Status | Build Workflow |
|----------|-----------|--------|----------------|
| **Android** | 24.0+ (Android 7.0+) | ✅ Active | `mobileapp-android.yml` |
| **iOS** | 14.2+ | ✅ Active | `mobileapp-ios.yml` |
| **macOS** (Catalyst) | 14.0+ | ✅ Active | `mobileapp-mac.yml` |
| **Windows** | 10.0.17763.0+ | ✅ Active | `mobileapp-windows.yml` |
| **Tizen** | 6.5+ | 🔧 Optional | Not configured |

### Platform-Specific Code

The application includes platform-specific implementations in:
```
src/mobile-app/app/CoinGardenWorldMobileApp.Maui/Platforms/
├── Android/          # Android-specific code
├── iOS/              # iOS-specific code
├── MacCatalyst/      # macOS Catalyst-specific code
├── Windows/          # Windows-specific code
└── Tizen/            # Tizen-specific code (optional)
```

## 🔧 Key Features

### Application Features
- **Cross-platform Native UI** - Single codebase for all platforms
- **Blazor Hybrid** - Reusable web components in native apps
- **Authentication & Authorization** - Microsoft Identity integration
- **Real-time Communication** - SignalR support
- **Offline Capabilities** - Local storage with Blazored.LocalStorage
- **PWA Support** - Progressive Web App features
- **Localization** - Multi-language support (EN, BG)
- **Telemetry** - Azure Application Insights integration
- **Azure Storage** - Cloud storage integration

### Key NuGet Packages
```xml
<!-- MAUI Core -->
<PackageReference Include="Microsoft.Maui.Controls" />
<PackageReference Include="Microsoft.Maui.Controls.Compatibility" />
<PackageReference Include="Microsoft.AspNetCore.Components.WebView.Maui" />

<!-- Authentication -->
<PackageReference Include="Microsoft.Authentication.WebAssembly.Msal" />
<PackageReference Include="Microsoft.Identity.Client" />

<!-- Utilities -->
<PackageReference Include="Blazored.LocalStorage" />
<PackageReference Include="BlazorApplicationInsights" />
<PackageReference Include="Mapster" />
<PackageReference Include="Toolbelt.Blazor.PWA.Updater" />
```

## 📦 Build & Deployment

### Prerequisites
- .NET 8.0 SDK
- .NET MAUI workloads installed
- Platform-specific SDKs (Android SDK, Xcode for iOS/macOS, Visual Studio for Windows)

### Build Commands

#### Restore Dependencies
```bash
dotnet restore CoinGardenWorld.sln
```

#### Build for Specific Platform
```bash
# Android
dotnet build src/mobile-app/app/CoinGardenWorldMobileApp.Maui/CoinGardenWorldMobileApp.Maui.csproj -f net8.0-android

# iOS
dotnet build src/mobile-app/app/CoinGardenWorldMobileApp.Maui/CoinGardenWorldMobileApp.Maui.csproj -f net8.0-ios

# Windows
dotnet build src/mobile-app/app/CoinGardenWorldMobileApp.Maui/CoinGardenWorldMobileApp.Maui.csproj -f net8.0-windows10.0.19041.0

# macOS
dotnet build src/mobile-app/app/CoinGardenWorldMobileApp.Maui/CoinGardenWorldMobileApp.Maui.csproj -f net8.0-maccatalyst
```

#### Publish for Release
```bash
# Android (APK/AAB)
dotnet publish src/mobile-app/app/CoinGardenWorldMobileApp.Maui/CoinGardenWorldMobileApp.Maui.csproj -c Release -f net8.0-android

# iOS (IPA)
dotnet publish src/mobile-app/app/CoinGardenWorldMobileApp.Maui/CoinGardenWorldMobileApp.Maui.csproj -c Release -f net8.0-ios

# Windows (MSIX)
dotnet publish src/mobile-app/app/CoinGardenWorldMobileApp.Maui/CoinGardenWorldMobileApp.Maui.csproj -c Release -f net8.0-windows10.0.19041.0

# macOS (PKG)
dotnet publish src/mobile-app/app/CoinGardenWorldMobileApp.Maui/CoinGardenWorldMobileApp.Maui.csproj -c Release -f net8.0-maccatalyst
```

### CI/CD Workflows

The repository includes GitHub Actions workflows for automated builds:

1. **mobileapp-android.yml** - Builds Android APK/AAB
2. **mobileapp-ios.yml** - Builds iOS IPA
3. **mobileapp-mac.yml** - Builds macOS app
4. **mobileapp-windows.yml** - Builds Windows MSIX
5. **mobileapp-web-azure-static-web-apps.yml** - Deploys web version

All workflows:
- Automatically install .NET MAUI workloads
- Version the application based on GitHub run number
- Create release artifacts
- Can be triggered manually via `workflow_dispatch`

## 🌐 Deployment Targets

### Mobile App Releases
- **Latest Version:** Available via GitHub Releases
- **Download Page:** https://github.com/s2kdesign-com/CoinGardenWorld/releases/latest
- **Platforms:** Android, iOS, Windows, macOS

### Web Deployment
- **Web App URL:** https://plant.coingarden.world
- **PWA Support:** Yes, installable as Progressive Web App
- **Hosting:** Azure Static Web Apps

### API Endpoints
- **Mobile App API:** https://plant-api.coingarden.world/swagger/index.html
- **Mobile App Site:** https://app.coingarden.world

## 🗂️ Project Structure

```
src/mobile-app/
├── app/                                    # Mobile application projects
│   ├── CoinGardenWorldMobileApp.Maui/     # Main MAUI application
│   │   ├── Platforms/                      # Platform-specific code
│   │   │   ├── Android/
│   │   │   ├── iOS/
│   │   │   ├── MacCatalyst/
│   │   │   ├── Windows/
│   │   │   └── Tizen/
│   │   ├── Resources/                      # App resources (icons, images, fonts)
│   │   ├── wwwroot/                        # Static web assets
│   │   ├── App.xaml                        # MAUI app definition
│   │   ├── MauiProgram.cs                  # App initialization
│   │   └── appsettings.json                # Configuration
│   ├── CoinGardenWorldMobileApp.MobileAppTheme/  # Shared UI library
│   │   ├── Components/                     # Blazor components
│   │   ├── Pages/                          # Blazor pages
│   │   ├── Localization/                   # i18n resources
│   │   └── Extensions/                     # Service extensions
│   ├── CoinGardenWorldMobileApp.DotNetApi/ # Backend API
│   ├── CoinGardenWorldMobileApp.Models/   # Data models
│   └── CoinGardenWorldMobileApp.WebApp/   # Web version
├── site/                                   # Marketing/info site
│   ├── CoinGardenWorldMobileApp.Web/      # Blazor WASM site
│   └── CoinGardenWorldMobileApp_Api/      # Site API
└── README.md
```

## 🔐 Application Configuration

### Configuration Files
- `appsettings.json` - Production configuration
- `appsettings.Development.json` - Development configuration (debug builds only)

### Key Configuration Sections
```json
{
  "APPLICATIONINSIGHTS_CONNECTION_STRING": "...",
  // Other configuration settings
}
```

## 📚 Related Documentation

- **Official Site:** https://coingarden.world
- **Documentation (EN):** https://docs.coingarden.world/
- **Documentation (BG):** https://docs.coingarden.world/v/bg/
- **Getting Started:** `docs/GETTING_STARTED.md`
- **Mobile App README:** `src/mobile-app/README.md`

## 🎨 Branding

**Color Scheme:** `#0094ff` (Mobile App Blue)

![Mobile App Gradient](https://github.com/s2kdesign-com/CoinGardenWorld/blob/main/docs/assets/mobileapp-site-gradient.png?raw=true)

## 🤝 Contributing

When contributing to the mobile app:
1. Follow the existing code structure
2. Test on multiple platforms before submitting PR
3. Update localization resources if adding new UI text
4. Ensure CI/CD workflows pass

## 📝 License

See `LICENSE.txt` in the root directory.

## 📞 Support

- **Facebook:** [CoinGarden.World](https://www.facebook.com/CoinGarden.World)
- **Instagram:** [@coingardenworld](https://www.instagram.com/coingardenworld/)
- **YouTube:** [@CoinGarden-World](https://www.youtube.com/@CoinGarden-World)
- **Twitter:** [@coingardenworld](https://twitter.com/coingardenworld)
- **TikTok:** [@coingarden.world](https://www.tiktok.com/@coingarden.world)

---

**Last Updated:** January 28, 2026

**Status:** ✅ Active Development - Fully Functional .NET MAUI Application
