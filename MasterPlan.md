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
| 24 | User Groups | CRUD /usergroups, members, roles |
| 25 | User Roles | Roles, permissions, assignments |
| 26 | Monitoring | Alarms, device hardware/software/info |
| 27 | Monitoring Policy | Policy CRUD + assignment |
| 28 | Patch Management | Devices, patches, policy |
| 29 | Endpoint Protection | Endpoints, install, link devices |
| 30 | Chat | Messages, Rooms, Send/Read |
| 31 | Conditional Access | Directory groups, rules, options |
| 32 | Reports Extensions | Screenshots, AI summaries, transcripts |
| 33 | Company | Company info |
| 34 | Company Address Book | Hidden members |
| 35 | SSO Extensions | Exclusion/inclusion lists |
| 36 | IoT | Dashboards, widgets, sensors, metrics |

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
| 24 | ⏳ Pending | User Groups |
| 25 | ⏳ Pending | User Roles |
| 26 | ⏳ Pending | Monitoring |
| 27 | ⏳ Pending | Monitoring Policy |
| 28 | ⏳ Pending | Patch Management |
| 29 | ⏳ Pending | Endpoint Protection |
| 30 | ⏳ Pending | Chat |
| 31 | ⏳ Pending | Conditional Access |
| 32 | ⏳ Pending | Reports Extensions |
| 33 | ⏳ Pending | Company |
| 34 | ⏳ Pending | Company Address Book |
| 35 | ⏳ Pending | SSO Extensions |
| 36 | ⏳ Pending | IoT |

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

## Phase 24: User Groups API
**Goal**: User group management with members and roles

### Steps
1. Create IUserGroupsApi.cs interface
2. Create UserGroup models
3. Wire up in client
4. Create tests

### Endpoints
- GET /usergroups - Get user groups
- POST /usergroups - Create user group
- GET /usergroups/{groupId} - Get user group
- PUT /usergroups/{groupId} - Update user group
- DELETE /usergroups/{groupId} - Delete user group
- GET /usergroups/{groupId}/members - Get group members
- POST /usergroups/{groupId}/members - Add member
- DELETE /usergroups/{groupId}/members/{accountId} - Remove member
- GET /usergroups/{groupId}/userroles - Get group roles

---

## Phase 25: User Roles API
**Goal**: Role-based access control management

### Steps
1. Create IUserRolesApi.cs interface
2. Create UserRole models
3. Wire up in client
4. Create tests

### Endpoints
- GET /userroles - Get user roles
- GET /userroles/predefined - Get predefined roles
- GET /userroles/permissions - Get available permissions
- POST /userroles/assign/account - Assign role to account
- POST /userroles/unassign/account - Unassign role from account
- POST /userroles/assign/usergroup - Assign role to group
- POST /userroles/unassign/usergroup - Unassign role from group
- GET /userroles/assignments/account - Get account role assignments
- GET /userroles/assignments/usergroups - Get group role assignments

---

## Phase 26: Monitoring API
**Goal**: Device monitoring and alarms

### Steps
1. Create IMonitoringApi.cs interface
2. Create Monitoring models (Alarm, DeviceInfo, Hardware, Software)
3. Wire up in client
4. Create tests

### Endpoints
- GET /monitoring/alarms - Get monitoring alarms
- GET /monitoring/devices - Get monitored devices
- GET /monitoring/devices/{deviceId}/information - Get device information
- GET /monitoring/devices/{deviceId}/hardware - Get device hardware info
- GET /monitoring/devices/{deviceId}/software - Get device software info

---

## Phase 27: Monitoring Policy API
**Goal**: Monitoring policy management

### Steps
1. Create IMonitoringPolicyApi.cs interface
2. Create MonitoringPolicy models
3. Wire up in client
4. Create tests

### Endpoints
- GET /Monitoring/Policy - Get monitoring policies
- POST /Monitoring/Policy - Create monitoring policy
- GET /Monitoring/Policy/{id} - Get monitoring policy
- PUT /Monitoring/Policy/{id} - Update monitoring policy
- DELETE /Monitoring/Policy/{id} - Delete monitoring policy
- POST /Monitoring/Policy/Assign - Assign monitoring policy

---

## Phase 28: Patch Management API
**Goal**: Patch management for devices

### Steps
1. Create IPatchManagementApi.cs interface
2. Create PatchManagement models
3. Wire up in client
4. Create tests

### Endpoints
- GET /patchmanagement/devices - Get devices
- GET /patchmanagement/devices/{deviceId}/patches/missing - Get missing patches
- GET /patchmanagement/scanresultcounts - Get scan result counts
- GET /PatchManagement/Policy - Get patch policies
- POST /PatchManagement/Policy - Create patch policy
- GET /PatchManagement/Policy/{id} - Get patch policy
- PUT /PatchManagement/Policy/{id} - Update patch policy
- DELETE /PatchManagement/Policy/{id} - Delete patch policy
- POST /PatchManagement/Policy/Assign - Assign patch policy

---

## Phase 29: Endpoint Protection API
**Goal**: Endpoint protection v2 management

### Steps
1. Create IEndpointProtectionApi.cs interface
2. Create EndpointProtection models
3. Wire up in client
4. Create tests

### Endpoints
- GET /endpointprotectionv2/endpoints - Get endpoints
- POST /endpointprotectionv2/install - Install endpoint protection
- POST /endpointprotectionv2/linkdevices - Link devices

---

## Phase 30: Chat API
**Goal**: TeamViewer chat functionality

### Steps
1. Create IChatApi.cs interface
2. Create Chat models (Message, Room)
3. Wire up in client
4. Create tests

### Endpoints
- GET /chat/Rooms - Get chat rooms
- GET /chat/Messages - Get messages
- POST /chat/SendMessage - Send message
- POST /chat/MarkMessageAsRead - Mark message as read
- GET /chat/UnreadMessages - Get unread messages

---

## Phase 31: Conditional Access API
**Goal**: Conditional access rules and directory groups

### Steps
1. Create IConditionalAccessApi.cs interface
2. Create ConditionalAccess models
3. Wire up in client
4. Create tests

### Endpoints
- GET /ConditionalAccess/DirectoryGroups - Get directory groups
- POST /ConditionalAccess/DirectoryGroups - Create directory group
- GET /ConditionalAccess/DirectoryGroups/{id} - Get directory group
- PUT /ConditionalAccess/DirectoryGroups/{id} - Update directory group
- DELETE /ConditionalAccess/DirectoryGroups/{id} - Delete directory group
- GET /ConditionalAccess/DirectoryGroups/{id}/members - Get members
- GET /ConditionalAccess/Rules - Get rules
- POST /ConditionalAccess/Rules - Create rule
- GET /ConditionalAccess/Rules/{id} - Get rule
- PUT /ConditionalAccess/Rules/{id} - Update rule
- DELETE /ConditionalAccess/Rules/{id} - Delete rule
- GET /ConditionalAccess/Options/Approval - Get approval options
- GET /ConditionalAccess/Options/Features - Get feature options
- GET /ConditionalAccess/Options/Time - Get time options

---

## Phase 32: Reports Extensions API
**Goal**: Extended reporting features

### Steps
1. Add endpoints to IReportsApi.cs
2. Create Screenshot, Transcript models
3. Create tests

### Endpoints
- GET /reports/connections/{id}/screenshots - Get screenshots
- GET /reports/connections/{id}/{screenshotId}/screenshot - Get screenshot
- GET /reports/connections/{id}/ai-summary - Get AI summary
- GET /reports/connections/{id}/chat-transcript - Get chat transcript
- GET /reports/connections/{id}/voice-transcript - Get voice transcript
- GET /reports/devices - Get device reports
- GET /reports/devices/{id}/ai-summary - Get AI summary
- GET /reports/devices/{id}/chat-transcript - Get chat transcript

---

## Phase 33: Company API
**Goal**: Company information

### Steps
1. Create ICompanyApi.cs interface
2. Create Company models
3. Wire up in client
4. Create tests

### Endpoints
- GET /company - Get company information

---

## Phase 34: Company Address Book API
**Goal**: Company address book management

### Steps
1. Create ICompanyAddressBookApi.cs interface
2. Create AddressBook models
3. Wire up in client
4. Create tests

### Endpoints
- GET /companyaddressbook - Get address book
- GET /companyaddressbook/hiddenmembers - Get hidden members
- POST /companyaddressbook/hiddenmembers - Add hidden member
- DELETE /companyaddressbook/hiddenmembers/{accountId} - Remove hidden member

---

## Phase 35: SSO Extensions API
**Goal**: SSO domain exclusion/inclusion lists

### Steps
1. Add endpoints to ISsoDomainApi.cs
2. Create SsoExclusion/Inclusion models
3. Create tests

### Endpoints
- GET /ssoDomain/{id}/exclusion - Get exclusion list
- POST /ssoDomain/{id}/exclusion - Add to exclusion list
- DELETE /ssoDomain/{id}/exclusion - Remove from exclusion list
- GET /ssoDomain/{id}/inclusion - Get inclusion list
- POST /ssoDomain/{id}/inclusion - Add to inclusion list
- DELETE /ssoDomain/{id}/inclusion - Remove from inclusion list

---

## Phase 36: IoT API
**Goal**: IoT dashboards, widgets, sensors, and metrics

### Steps
1. Create IIotApi.cs interface
2. Create IoT models (Dashboard, Widget, Sensor, Metric)
3. Wire up in client
4. Create tests

### Endpoints
- GET /iot/dashboards - Get dashboards
- POST /iot/dashboards - Create dashboard
- GET /iot/dashboards/{id} - Get dashboard
- PUT /iot/dashboards/{id} - Update dashboard
- DELETE /iot/dashboards/{id} - Delete dashboard
- GET /iot/dashboards/{id}/widgets - Get widgets
- POST /iot/dashboards/{id}/widgets - Create widget
- GET /iot/device-configurations - Get device configurations
- POST /iot/device-configurations - Create device configuration
- GET /iot/edge-modules - Get edge modules
- GET /iot/LatestData - Get latest IoT data
- POST /iot/data/push - Push IoT data

---

## Notes
- All dates/times use ISO 8601 format (UTC)
- IDs are prefixed: u=user, g=group, m=meeting, s=session, c=contact, d=device, r=remotecontrol
- API base URL: https://webapi.teamviewer.com/api/v1/
- Authentication: Bearer token in Authorization header
