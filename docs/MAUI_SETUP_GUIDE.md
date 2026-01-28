# .NET MAUI Application Setup Guide

## Quick Setup Instructions

This guide helps you set up the development environment for the CoinGarden.World .NET MAUI application.

## Prerequisites

### Required Software

1. **.NET 8.0 SDK or later**
   - Download: https://dotnet.microsoft.com/download/dotnet/8.0
   - Verify installation: `dotnet --version`

2. **Visual Studio 2022** (Recommended) or **Visual Studio Code**
   - **Visual Studio 2022 (17.8+):**
     - Community, Professional, or Enterprise edition
     - During installation, select:
       - ".NET Multi-platform App UI development" workload
       - "ASP.NET and web development" workload
   
   - **Visual Studio Code:**
     - Install C# Dev Kit extension
     - Install .NET MAUI extension

### Platform-Specific Requirements

#### For Android Development
- Android SDK (API Level 24+)
- Android Emulator or physical device
- Automatically installed with Visual Studio MAUI workload

#### For iOS Development (macOS only)
- Xcode 14.0 or later
- iOS SDK 14.2 or later
- Apple Developer account (for device deployment)
- Install via: `xcode-select --install`

#### For macOS Development (macOS only)
- Xcode 14.0 or later
- macOS SDK 14.0 or later

#### For Windows Development (Windows only)
- Windows 10/11 SDK (10.0.17763.0 or later)
- Automatically included with Visual Studio

## Installation Steps

### Step 1: Install .NET MAUI Workloads

Run the following commands in your terminal:

```bash
# Install MAUI workload
dotnet workload install maui

# Alternatively, install all mobile workloads
dotnet workload install android ios maccatalyst tvos macos maui wasm-tools
```

### Step 2: Verify Installation

```bash
# List installed workloads
dotnet workload list

# You should see something like:
# maui
# android
# ios
# maccatalyst
```

### Step 3: Clone the Repository

```bash
git clone https://github.com/s2kdesign-com/CoinGardenWorld.git
cd CoinGardenWorld
```

### Step 4: Restore Dependencies

```bash
# Restore all project dependencies
dotnet restore CoinGardenWorld.sln
```

## Building the Application

### Build for All Platforms (Development)

```bash
# Build the entire solution
dotnet build CoinGardenWorld.sln
```

### Build for Specific Platform

```bash
# Navigate to the MAUI project directory
cd src/mobile-app/app/CoinGardenWorldMobileApp.Maui

# Android
dotnet build -f net8.0-android

# iOS (macOS only)
dotnet build -f net8.0-ios

# macOS (macOS only)
dotnet build -f net8.0-maccatalyst

# Windows (Windows only)
dotnet build -f net8.0-windows10.0.19041.0
```

## Running the Application

### Using Visual Studio 2022

1. Open `CoinGardenWorld.sln`
2. Set `CoinGardenWorldMobileApp.Maui` as the startup project
3. Select your target platform from the dropdown (Android, iOS, Windows, etc.)
4. Choose your device/emulator
5. Press F5 or click "Start Debugging"

### Using Command Line

```bash
# Run on Android Emulator
dotnet build -f net8.0-android -t:Run

# Run on iOS Simulator (macOS only)
dotnet build -f net8.0-ios -t:Run

# Run on Windows
dotnet build -f net8.0-windows10.0.19041.0 -t:Run
```

### Using Visual Studio Code

1. Open the repository folder in VS Code
2. Install recommended extensions when prompted
3. Open the Command Palette (Ctrl+Shift+P / Cmd+Shift+P)
4. Type ".NET MAUI" and select your target platform
5. Start debugging

## Publishing for Production

### Android (APK/AAB)

```bash
cd src/mobile-app/app/CoinGardenWorldMobileApp.Maui

# Build APK
dotnet publish -f net8.0-android -c Release

# Output: bin/Release/net8.0-android/publish/*.apk
```

### iOS (IPA) - macOS only

```bash
cd src/mobile-app/app/CoinGardenWorldMobileApp.Maui

# Build IPA
dotnet publish -f net8.0-ios -c Release

# Note: Requires code signing configuration
# Output: bin/Release/net8.0-ios/publish/*.ipa
```

### Windows (MSIX)

```bash
cd src/mobile-app/app/CoinGardenWorldMobileApp.Maui

# Build MSIX
dotnet publish -f net8.0-windows10.0.19041.0 -c Release

# Output: bin/Release/net8.0-windows10.0.19041.0/publish/*.msix
```

### macOS (PKG) - macOS only

```bash
cd src/mobile-app/app/CoinGardenWorldMobileApp.Maui

# Build PKG
dotnet publish -f net8.0-maccatalyst -c Release

# Note: Requires code signing configuration
# Output: bin/Release/net8.0-maccatalyst/publish/
```

## Configuration

### Development Settings

Edit `appsettings.Development.json` in the MAUI project:

```json
{
  "APPLICATIONINSIGHTS_CONNECTION_STRING": "your-connection-string",
  // Add other development settings
}
```

### Production Settings

Edit `appsettings.json` in the MAUI project for production configuration.

## Troubleshooting

### Common Issues

#### 1. "MAUI workload not found"
```bash
# Reinstall MAUI workload
dotnet workload install maui --skip-manifest-update
```

#### 2. Android SDK not found
- Install Android SDK via Visual Studio Installer
- Or set `ANDROID_HOME` environment variable

#### 3. iOS build fails
- Ensure Xcode is installed and up to date
- Accept Xcode license: `sudo xcodebuild -license accept`
- Install Xcode command line tools: `xcode-select --install`

#### 4. "Unable to find package"
```bash
# Clear NuGet cache
dotnet nuget locals all --clear

# Restore again
dotnet restore
```

#### 5. Windows build fails
- Ensure Windows SDK is installed
- Check Visual Studio Installer for Windows 10 SDK

### Getting Help

If you encounter issues:

1. Check the [official .NET MAUI documentation](https://learn.microsoft.com/dotnet/maui/)
2. Review GitHub Issues: https://github.com/s2kdesign-com/CoinGardenWorld/issues
3. Contact the team via social media (see README.md)

## Development Tools

### Recommended VS Code Extensions

- C# Dev Kit
- .NET MAUI
- C# Extensions
- NuGet Package Manager
- GitLens

### Recommended Visual Studio Extensions

- XAML Styler
- Mobile App Explorer
- Hot Reload for .NET MAUI

## Next Steps

After successful setup:

1. Read the [MAUI Application Overview](./MAUI_APPLICATION_OVERVIEW.md)
2. Explore the codebase in `src/mobile-app/app/`
3. Check the [Getting Started Guide](./GETTING_STARTED.md)
4. Review the project structure and conventions

## CI/CD Integration

The repository includes GitHub Actions workflows for automated builds. See `.github/workflows/mobileapp-*.yml` files.

To test locally before pushing:

```bash
# Run the build command from the workflow
dotnet workload install maui
dotnet restore CoinGardenWorld.sln
dotnet publish src/mobile-app/app/CoinGardenWorldMobileApp.Maui/CoinGardenWorldMobileApp.Maui.csproj -c Release -f net8.0-android
```

---

**Last Updated:** January 28, 2026

**Minimum Requirements:**
- .NET 8.0 SDK
- Visual Studio 2022 17.8+ or VS Code with extensions
- Platform-specific SDKs (Android/iOS/Windows)
