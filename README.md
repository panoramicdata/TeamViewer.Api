# TeamViewer.Api

[![Nuget](https://img.shields.io/nuget/v/TeamViewer.Api)](https://www.nuget.org/packages/TeamViewer.Api/)
[![Nuget](https://img.shields.io/nuget/dt/TeamViewer.Api)](https://www.nuget.org/packages/TeamViewer.Api/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/c914f9877e2c4503a792a7c7fda75ba8)](https://app.codacy.com/gh/panoramicdata/TeamViewer.Api/dashboard?utm_source=gh&utm_medium=referral&utm_content=&utm_campaign=Badge_grade)

A comprehensive .NET library for the TeamViewer REST API.

## Installation

```powershell
dotnet add package TeamViewer.Api
```

Or via the NuGet Package Manager:

```powershell
Install-Package TeamViewer.Api
```

## Quick Start

```csharp
using TeamViewer.Api;

// Create the client with your Script Token
var options = new TeamViewerClientOptions
{
    ScriptToken = "your-script-token-here"
};

using var client = new TeamViewerClient(options);

// Test connectivity
var ping = await client.Ping.PingAsync(cancellationToken);

// Get account information
var account = await client.Account.GetAccountAsync(cancellationToken);

// List users
var users = await client.Users.GetUsersAsync(new GetUsersRequest(), cancellationToken);
foreach (var user in users.Users)
{
    Console.WriteLine(user.Name);
}

// List devices
var devices = await client.Devices.GetDevicesAsync(new GetDevicesRequest(), cancellationToken);
foreach (var device in devices.Devices)
{
    Console.WriteLine(device.Alias);
}
```

## Features

- **Full TeamViewer REST API coverage** - Users, Groups, Devices, Contacts, Sessions, Meetings, Reports, Policies, and more
- **Script Token authentication** - Simple bearer token authentication
- **Automatic retry with exponential backoff** - Handles rate limiting (429) and transient errors (5xx)
- **Comprehensive logging support** - Integrates with Microsoft.Extensions.Logging
- **Strongly-typed models** - Full IntelliSense support with XML documentation
- **Async/await patterns** - All methods are async with CancellationToken support
- **Modern .NET** - Built for .NET 10 with nullable reference types

## Supported APIs

| API | Description |
|-----|-------------|
| Ping | Test connectivity and token validity |
| Account | Get and update account information |
| Users | Manage company users (CRUD operations) |
| Groups | Manage groups and sharing |
| Devices | Manage devices in Computers and Contacts |
| Contacts | Manage contacts |
| Sessions | Manage session codes for remote support |
| Meetings | Schedule and manage meetings |
| Reports | Access connection and device reports |
| Event Logging | Access audit logs |
| Policies | Manage TeamViewer policies |

## Authentication

TeamViewer.Api uses Script Token authentication. To obtain a Script Token:

1. Log in to the [TeamViewer Management Console](https://login.teamviewer.com/)
2. Navigate to **Company Administration** > **API Access**
3. Click **Create Script Token**
4. Configure the required permissions for your use case
5. Copy the generated token

## API Documentation

The TeamViewer API documentation can be found here:
- [TeamViewer API Documentation](https://www.teamviewer.com/en/for-developers/teamviewer-api/)
- [TeamViewer API Reference](https://webapi.teamviewer.com/api/v1/docs/index)

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
