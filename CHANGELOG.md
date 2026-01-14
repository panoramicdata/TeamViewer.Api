# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.1.0] - 2025-01-14

### Added
- Initial release
- **Core Infrastructure**
  - TeamViewerClient with Script Token authentication
  - Automatic retry with exponential backoff for rate limiting (429) and server errors (5xx)
  - Comprehensive logging support via Microsoft.Extensions.Logging
  - Custom TeamViewerApiException for API errors
- **Ping API** - Test connectivity and token validity
- **Account API** - Get and update account information
- **Users API** - Full CRUD operations for company users
- **Groups API** - Group management with sharing capabilities
- **Sessions API** - Session code management for remote support
- **Devices API** - Device management in Computers & Contacts
- **Contacts API** - Contact management
- **Reports API** - Connection and device reports
- **Meetings API** - Meeting scheduling and management
- **Event Logging API** - Audit log access
- **Policies API** - TeamViewer policy management
- **Remote Management API** - Managed devices and groups
