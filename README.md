# Setup

 - Install .NET 6.0 GA SDK
 - Create rollback.json file containing:
    - `{ "microsoft.net.sdk.macos": "12.0.101-preview.10.249" }`
 - dotnet workload install
    - `dotnet workload install macos --source https://aka.ms/dotnet6/nuget/index.json --source https://api.nuget.org/v3/index.json --from-rollback-file rollback.json`

 - dotnet new macos project
    - `dotnet new macos -o TestAuthMacOSNET6`
 - Add auth code
 - Build and run project
    - `dotnet restore`
    - `dotnet build`
    - `open -n bin/Debug/net6.0-macos/osx-x64/TestAuthMacOSNET6.app/`
 - Enter credentials into 'Test Auth' prompt
 - Error dialog
   - `Could not get authorization. ToolExecuteFailure`
 - Same code works with a classic Xamarin.Mac project