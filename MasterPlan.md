# TeamViewer.Api - Master Implementation Plan

## Overview
A comprehensive .NET 10 library for the TeamViewer REST API, providing full API coverage with Refit-based interfaces, following the same patterns as LanSweeper.Api.

**Repository**: `panoramicdata/TeamViewer.Api`
**Package**: `TeamViewer.Api`
**License**: MIT
**Target Framework**: net10.0

## Architecture

### Project Structure
```
TeamViewer.Api/
├── TeamViewer.Api.slnx
├── .editorconfig
├── .gitignore
├── .gitattributes
├── LICENSE
├── README.md
├── CHANGELOG.md
├── version.json
├── TeamViewer.Api.dic
├── Documentation/
│   └── (existing PDF/HTML docs)
├── TeamViewer.Api/
│   ├── TeamViewer.Api.csproj
│   ├── TeamViewerClient.cs
│   ├── TeamViewerClientOptions.cs
│   ├── Exceptions/
│   │   └── TeamViewerApiException.cs
│   ├── Handlers/
│   │   ├── AuthenticationHandler.cs
│   │   ├── RetryHandler.cs
│   │   ├── LoggingHandler.cs
│   │   └── ErrorHandler.cs
│   ├── Interfaces/
│   │   ├── ITeamViewerClient.cs
│   │   ├── IPingApi.cs
│   │   ├── IEventLoggingApi.cs
│   │   ├── IAccountApi.cs
│   │   ├── IUsersApi.cs
│   │   ├── IGroupsApi.cs
│   │   ├── ISessionsApi.cs
│   │   ├── IReportsApi.cs
│   │   ├── IMeetingsApi.cs
│   │   ├── IContactsApi.cs
│   │   ├── IDevicesApi.cs
│   │   ├── IPoliciesApi.cs
│   │   ├── IMonitoringApi.cs
│   │   ├── IMonitoringPoliciesApi.cs
│   │   ├── IPatchManagementApi.cs
│   │   └── IEndpointProtectionApi.cs
│   └── Models/
│       ├── Common/
│       ├── Requests/
│       └── Responses/
└── TeamViewer.Api.Test/
    ├── TeamViewer.Api.Test.csproj
    ├── GlobalUsings.cs
    ├── xunit.runner.json
    ├── secrets.example.json
    ├── Infrastructure/
    │   ├── IntegrationTestBase.cs
    │   └── TestConfig.cs
    ├── UnitTests/
    └── IntegrationTests/
```

### Authentication
- **Script Token only** - Bearer token authentication via `Authorization: Bearer {token}` header
- No OAuth flow implementation (simplicity)

### Technology Stack
- **Refit** - Declarative REST API interfaces
- **System.Text.Json** - JSON serialization
- **Microsoft.Extensions.Http** - HttpClient factory patterns
- **Microsoft.Extensions.Logging** - Logging abstractions
- **XUnit 3** - Testing framework
- **AwesomeAssertions** - Fluent assertions

---

## Phase 1: Foundation
**Goal**: Project structure, authentication, and core infrastructure

### Steps
1. Create solution structure (SLNX, projects, config files)
2. Create .editorconfig, .gitignore, .gitattributes
3. Create LICENSE (MIT), README.md, CHANGELOG.md
4. Create TeamViewer.Api.csproj with dependencies
5. Create TeamViewerClientOptions.cs
6. Create ITeamViewerClient.cs interface
7. Create AuthenticationHandler.cs (Script Token)
8. Create RetryHandler.cs
9. Create LoggingHandler.cs  
10. Create ErrorHandler.cs
11. Create TeamViewerApiException.cs
12. Create TeamViewerClient.cs (main client)
13. Create test project structure
14. Create IntegrationTestBase.cs and TestConfig.cs
15. Verify build succeeds

### Unit Tests Required
- `TeamViewerClientTests.cs` - Client construction, disposal, null options handling
- `TeamViewerClientOptionsTests.cs` - Default values, required properties
- `AuthenticationHandlerTests.cs` - Bearer token injection, null token handling
- `RetryHandlerTests.cs` - Retry on 429/5xx, no retry on 4xx, exponential backoff
- `LoggingHandlerTests.cs` - Request/response logging with and without logger
- `ErrorHandlerTests.cs` - Error response parsing, exception creation
- `TeamViewerApiExceptionTests.cs` - Exception properties, constructors

**Deliverable**: Working client that can authenticate with full unit test coverage


---

## Phase 2: Ping & Account APIs
**Goal**: First API endpoints to validate architecture

### Steps
1. Create IPingApi.cs interface
2. Create PingResponse.cs model
3. Create IAccountApi.cs interface
4. Create Account models (Account, AccountUpdateRequest)
5. Wire up APIs in TeamViewerClient
6. Verify all tests pass

### Integration Tests Required
- `PingApiTests.cs` - PingAsync returns valid response
- `AccountApiTests.cs` - GetAccountAsync, UpdateAccountAsync

**Deliverable**: Ping and Account APIs fully working with integration tests

---

## Phase 3: User Management API
**Goal**: Full user CRUD operations

### Steps
1. Create IUsersApi.cs interface
2. Create User models (User, UserListResponse, CreateUserRequest, UpdateUserRequest)
3. Create permission enums
4. Wire up in client
5. Verify tests pass

### Integration Tests Required
- `UsersApiTests.cs` - GetUsersAsync, GetUserAsync, CreateUserAsync, UpdateUserAsync, DeleteUserAsync

**Deliverable**: User Management API complete with integration tests

---

## Phase 4: Group Management API
**Goal**: Group CRUD with sharing

### Steps
1. Create IGroupsApi.cs interface
2. Create Group models (Group, GroupListResponse, CreateGroupRequest, ShareGroupRequest)
3. Wire up in client
4. Verify tests pass

### Integration Tests Required
- `GroupsApiTests.cs` - GetGroupsAsync, GetGroupAsync, CreateGroupAsync, UpdateGroupAsync, DeleteGroupAsync, ShareGroupAsync, UnshareGroupAsync

**Deliverable**: Group Management API complete with integration tests

---

## Phase 5: Session Management API
**Goal**: Support session code management

### Steps
1. Create ISessionsApi.cs interface
2. Create Session models (Session, SessionListResponse, CreateSessionRequest, etc.)
3. Wire up in client
4. Verify tests pass

### Integration Tests Required
- `SessionsApiTests.cs` - GetSessionsAsync, GetSessionAsync, CreateSessionAsync, UpdateSessionAsync

**Deliverable**: Session Management API complete with integration tests

---

## Phase 6: Reporting API
**Goal**: Connection reports

### Steps
1. Create IReportsApi.cs interface
2. Create Report models (ConnectionReport, DeviceReport, etc.)
3. Wire up in client
4. Verify tests pass

### Integration Tests Required
- `ReportsApiTests.cs` - GetConnectionReportsAsync, GetDeviceReportsAsync

**Deliverable**: Reporting API complete with integration tests

---

## Phase 7: Meetings API
**Goal**: Meeting management

### Steps
1. Create IMeetingsApi.cs interface
2. Create Meeting models (Meeting, MeetingListResponse, CreateMeetingRequest, etc.)
3. Wire up in client
4. Verify tests pass

### Integration Tests Required
- `MeetingsApiTests.cs` - GetMeetingsAsync, GetMeetingAsync, CreateMeetingAsync, UpdateMeetingAsync, DeleteMeetingAsync

**Deliverable**: Meetings API complete with integration tests

---

## Phase 8: Contacts API
**Goal**: Contacts list management

### Steps
1. Create IContactsApi.cs interface
2. Create Contact models
3. Wire up in client
4. Verify tests pass

### Integration Tests Required
- `ContactsApiTests.cs` - GetContactsAsync, GetContactAsync, CreateContactAsync, DeleteContactAsync

**Deliverable**: Contacts API complete with integration tests

---

## Phase 9: Devices API
**Goal**: Device management in Computers & Contacts

### Steps
1. Create IDevicesApi.cs interface
2. Create Device models
3. Wire up in client
4. Verify tests pass

### Integration Tests Required
- `DevicesApiTests.cs` - GetDevicesAsync, GetDeviceAsync, UpdateDeviceAsync, DeleteDeviceAsync

**Deliverable**: Devices API complete with integration tests

---

## Phase 10: Event Logging API
**Goal**: Audit log access

### Steps
1. Create IEventLoggingApi.cs interface
2. Create EventLog models (AuditEvent, EventLoggingRequest, etc.)
3. Wire up in client
4. Verify tests pass

### Integration Tests Required
- `EventLoggingApiTests.cs` - GetEventsAsync with various filters

**Deliverable**: Event Logging API complete with integration tests

---

## Phase 11: Policy Management API
**Goal**: TeamViewer policy management

### Steps
1. Create IPoliciesApi.cs interface
2. Create Policy models
3. Wire up in client
4. Verify tests pass

### Integration Tests Required
- `PoliciesApiTests.cs` - GetPoliciesAsync, GetPolicyAsync, UpdatePolicyAsync

**Deliverable**: Policy Management API complete with integration tests

---

## Phase 12: Remote Management - Monitoring API
**Goal**: Monitoring features

### Steps
1. Create IMonitoringApi.cs interface
2. Create Monitoring models
3. Wire up in client
4. Verify tests pass

### Integration Tests Required
- `MonitoringApiTests.cs` - GetAlertsAsync, AcknowledgeAlertAsync

**Deliverable**: Monitoring API complete with integration tests

---

## Phase 13: Remote Management - Monitoring Policy API
**Goal**: Monitoring policy management

### Steps
1. Create IMonitoringPoliciesApi.cs interface
2. Create MonitoringPolicy models
3. Wire up in client
4. Verify tests pass

### Integration Tests Required
- `MonitoringPoliciesApiTests.cs` - GetMonitoringPoliciesAsync, GetMonitoringPolicyAsync

**Deliverable**: Monitoring Policy API complete with integration tests

---

## Phase 14: Remote Management - Patch Management API
**Goal**: Patch management features

### Steps
1. Create IPatchManagementApi.cs interface
2. Create PatchManagement models
3. Wire up in client
4. Verify tests pass

### Integration Tests Required
- `PatchManagementApiTests.cs` - GetPatchesAsync, GetPatchStatusAsync



**Deliverable**: Patch Management API complete with integration tests

---

## Phase 15: Remote Management - Endpoint Protection API
**Goal**: Endpoint protection features

### Steps
1. Create IEndpointProtectionApi.cs interface
2. Create EndpointProtection models
3. Wire up in client
4. Verify tests pass

### Integration Tests Required
- `EndpointProtectionApiTests.cs` - GetProtectionStatusAsync, GetThreatsAsync

**Deliverable**: Endpoint Protection API complete with integration tests

---

## Phase 16: Finalization
**Goal**: Polish, documentation, and publish

### Steps
1. Review and complete XML documentation
2. Update README with full usage examples
3. Create PUBLISHING.md
4. Create Publish.ps1 script
5. Configure NuGet package metadata
6. Run full test suite with coverage report
7. Ensure minimum 80% code coverage
8. Create GitHub repository
9. Push to GitHub
10. Configure GitHub Actions for CI/CD
11. Tag initial release

**Deliverable**: Published NuGet package and GitHub repository

---

## API Endpoint Summary

| Phase | API Section | Endpoints |
|-------|-------------|-----------|
| 2 | Ping | GET /ping |
| 2 | Account | GET/PUT /account |
| 3 | Users | GET/POST/PUT/DELETE /users |
| 4 | Groups | GET/POST/PUT/DELETE /groups, share/unshare |
| 5 | Sessions | GET/POST/PUT /sessions |
| 6 | Reports | GET/PUT/DELETE /reports/connections, /reports/devices |
| 7 | Meetings | GET/POST/PUT/DELETE /meetings |
| 8 | Contacts | GET/POST/DELETE /contacts |
| 9 | Devices | GET/PUT/POST/DELETE /devices |
| 10 | Event Logging | POST /EventLogging |
| 11 | Policies | GET/PUT /teamviewerpolicies |
| 12 | Remote Management | GET/POST/DELETE /managed/devices, /managed/groups |
| 17 | Company Branding | GET/PUT /companybranding |
| 18 | SSO Domains | GET/POST/DELETE /ssoDomain |
| 19 | User Devices | GET /users/{userId}/devices |
| 20 | Group Devices | GET /groups/{groupId}/devices |
| 21 | Meeting Extensions | GET /meetings/{meetingId}/invitation, participants |
| 22 | Access Tokens | GET/POST/DELETE /account/accesstokens |
| 23 | WebConnector | GET/POST /webconnector/sessions |

---

## Current Status

| Phase | Status | Notes |
|-------|--------|-------|
| 1 | ✅ Complete | Foundation |
| 2 | ✅ Complete | Ping & Account |
| 3 | ✅ Complete | Users |
| 4 | ✅ Complete | Groups |
| 5 | ✅ Complete | Sessions |
| 6 | ✅ Complete | Reports |
| 7 | ✅ Complete | Meetings |
| 8 | ✅ Complete | Contacts |
| 9 | ✅ Complete | Devices |
| 10 | ✅ Complete | Event Logging |
| 11 | ✅ Complete | Policies |
| 12 | ✅ Complete | Remote Management |
| 17 | ✅ Complete | Company Branding |
| 18 | ✅ Complete | SSO Domains |
| 19 | ✅ Complete | User Devices |
| 20 | ✅ Complete | Group Devices |
| 21 | ✅ Complete | Meeting Extensions |
| 22 | ✅ Complete | Access Tokens |
| 23 | ✅ Complete | WebConnector |

---

## Phase 17: Company Branding API
**Goal**: Custom branding for TeamViewer modules

### Steps
1. Create ICompanyBrandingApi.cs interface
2. Create CompanyBranding models
3. Wire up in client
4. Create tests

### Endpoints
- GET /companybranding - Get company branding settings
- PUT /companybranding - Update company branding settings

---

## Phase 18: SSO Domains API
**Goal**: SSO domain management

### Steps
1. Create ISsoDomainApi.cs interface
2. Create SsoDomain models
3. Wire up in client
4. Create tests

### Endpoints
- GET /ssoDomain - Get SSO domains
- POST /ssoDomain - Create SSO domain
- DELETE /ssoDomain/{domainId} - Delete SSO domain

---

## Phase 19: User Devices API
**Goal**: Get devices assigned to specific users

### Steps
1. Add GetUserDevicesAsync to IUsersApi.cs
2. Create UserDevice models if needed
3. Create tests

### Endpoints
- GET /users/{userId}/devices - Get devices assigned to user

---

## Phase 20: Group Devices API
**Goal**: Get devices in specific groups

### Steps
1. Add GetGroupDevicesAsync to IGroupsApi.cs
2. Create tests

### Endpoints
- GET /groups/{groupId}/devices - Get devices in group

---

## Phase 21: Meeting Extensions API
**Goal**: Meeting invitation and participants

### Steps
1. Add endpoints to IMeetingsApi.cs
2. Create MeetingInvitation and Participant models
3. Create tests

### Endpoints
- GET /meetings/{meetingId}/invitation - Get meeting invitation email
- GET /meetings/{meetingId}/participants - Get meeting participants

---

## Phase 22: Access Tokens API
**Goal**: API access token management

### Steps
1. Add endpoints to IAccountApi.cs
2. Create AccessToken models
3. Create tests

### Endpoints
- GET /account/accesstokens - Get API access tokens
- POST /account/accesstokens - Create API access token
- DELETE /account/accesstokens/{tokenId} - Delete API access token

---

## Phase 23: WebConnector API
**Goal**: WebConnector session management

### Steps
1. Create IWebConnectorApi.cs interface
2. Create WebConnectorSession models
3. Wire up in client
4. Create tests

### Endpoints
- GET /webconnector/sessions - Get WebConnector sessions
- POST /webconnector/sessions - Create WebConnector session

---

## Notes
- All dates/times use ISO 8601 format (UTC)
- IDs are prefixed: u=user, g=group, m=meeting, s=session, c=contact, d=device, r=remotecontrol
- API base URL: https://webapi.teamviewer.com/api/v1/
- Authentication: Bearer token in Authorization header
