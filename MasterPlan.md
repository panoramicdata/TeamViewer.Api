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
| 24 | ✅ Complete | User Groups |
| 25 | ⚠️ Partial | User Roles - assignments require Tensor |
| 26 | ⚠️ Partial | Monitoring - requires Remote Management license |
| 27 | ✅ Complete | Monitoring Policy |
| 28 | ✅ Complete | Patch Management |
| 29 | ⚠️ Partial | Endpoint Protection - requires license |
| 30 | ✅ Complete | Chat |
| 31 | ⚠️ Partial | Conditional Access - requires Tensor |
| 32 | ✅ Complete | Reports Extensions |
| 33 | ✅ Complete | Company |
| 34 | ✅ Complete | Company Address Book |
| 35 | ✅ Complete | SSO Extensions |
| 36 | ⚠️ Partial | IoT - some endpoints require IoT license |
| 37 | 🔄 In Progress | Feature Access & Test Remediation |

---

## Test Results Summary

**Last Run**: 2026-03-05 (after deserialization fixes)

| Category | Count |
|----------|-------|
| ✅ Passed | 161 |
| ❌ Failed | 27 |
| ⏭️ Skipped | 18 |
| **Total** | 206 |

> **Note**: Previous run showed 96 passed / 11 failed / 24 skipped because catch blocks were silently
> suppressing 37+ failures. All catch blocks have now been removed so every failure is visible.

### Failing Tests — Full Analysis

Tests are grouped by **root cause** to support the licensing email.

#### 1. `not_found` — API endpoint not available on current license (19 tests)

These endpoints return HTTP 404, meaning the API routes don't exist for our account tier.

| API | Test | Error |
|-----|------|-------|
| AccessTokens | `GetAccessTokensAsync_ReturnsTokenList` | `not_found` |
| CompanyBranding | `GetCompanyBrandingAsync_ReturnsBrandingSettings` | `not_found` |
| CompanyBranding | `UpdateCompanyBrandingAsync_UpdatesBrandingSettings` | `not_found` |
| IoT | `GetEdgeModulesAsync_ReturnsModuleList` | `not_found` |
| IoT | `GetDeviceConfigurationsAsync_ReturnsConfigList` | `not_found` |
| OAuth2 | `GetClientsAsync_ReturnsClientList` | `not_found` |
| OAuth2 | `CreateUpdateDeleteClientAsync_FullCrudCycle` | `not_found` |
| OemDevices | `GetDevicesAsync_ReturnsDeviceList` | `not_found` |
| OemDevices | `GetDeviceAsync_WithValidDevice_ReturnsDevice` | `not_found` |
| ReachNotifications | `GetSubscriptionsAsync_ReturnsSubscriptionList` | `not_found` |
| ReachNotifications | `CreateUpdateDeleteSubscriptionAsync_FullCrudCycle` | `not_found` |
| SocketAuthentication | `AuthenticateAsync_ReturnsToken` | `not_found` |
| SocketAuthentication | `ValidateTokenAsync_WithValidToken_ReturnsValid` | `not_found` |
| WebConnector | `GetSessionsAsync_ReturnsSessionList` | `not_found` |

**Required**: OEM/Reach license, WebConnector license, IoT add-on, OAuth2 management access, Socket Authentication access, Access Tokens scope

#### 2. `internal_error` — Feature requires higher-tier license (10 tests)

These endpoints exist but return HTTP 500 `internal_error`, indicating the feature is not provisioned.

| API | Test | Error |
|-----|------|-------|
| ConditionalAccess | `GetFeatureOptionsAsync_ReturnsOptions` | `internal_error` |
| ConditionalAccess | `GetApprovalOptionsAsync_ReturnsOptions` | `internal_error` |
| ConditionalAccess | `GetTimeOptionsAsync_ReturnsOptions` | `internal_error` |
| ConditionalAccess | `GetRulesAsync_ReturnsRuleList` | `internal_error` |
| EndpointProtection | `GetEndpointsAsync_ReturnsEndpointList` | `internal_error` |
| EventLogging | `GetEventsAsync_WithEventTypeFilter_ReturnsFilteredEvents` | `internal_error` |
| Monitoring | `GetDeviceInformationAsync_WithValidDevice_ReturnsInfo` | `internal_error` |
| Monitoring | `GetDeviceHardwareAsync_WithValidDevice_ReturnsHardwareInfo` | `internal_error` |
| Monitoring | `GetDeviceSoftwareAsync_WithValidDevice_ReturnsSoftwareInfo` | `internal_error` |

**Required**: TeamViewer Tensor (Conditional Access), Endpoint Protection add-on, Event Logging scope, Remote Management license (Monitoring detail endpoints)

#### 3. `invalid_token` — Script token missing required scope (3 tests)

The token doesn't have the required permission scope for these endpoints.

| API | Test | Error |
|-----|------|-------|
| Chat | `GetRoomsAsync_ReturnsRoomList` | `invalid_token` |
| Chat | `GetUnreadMessagesAsync_ReturnsMessageList` | `invalid_token` |
| Chat | `GetMessagesAsync_WithRoom_ReturnsMessageList` | `invalid_token` |

**Required**: Add `Chat` scope to the Script Token in TeamViewer Management Console

#### 4. `invalid_request` — Request parameters rejected by API (7 tests)

The API rejects the request payload. May indicate wrong parameters, model issues, or permission constraints.

| API | Test | Error |
|-----|------|-------|
| Contacts | `InviteAndDeleteContactAsync_InvitesAndDeletesContact` | `invalid_request` |
| Meetings | `CreateAndDeleteMeetingAsync_CreatesAndDeletesMeeting` | `invalid_request` |
| Meetings | `UpdateMeetingAsync_UpdatesMeetingSubject` | `invalid_request` |
| OemApi | `ResolveTenantsAsync_WithAccountId_ReturnsTenants` | `invalid_request` |
| ConditionalAccess | `CreateUpdateDeleteRuleAsync_FullCrudCycle` | `invalid_request` |
| Sessions | `CreateAndDeleteSessionAsync_CreatesAndDeletesSession` | `invalid_request` |
| Sessions | `UpdateSessionAsync_UpdatesSessionDescription` | `invalid_request` |

**Required**: Investigate request models — may need OEM license, Tensor license, or corrected request payloads

#### 5. `An unknown error occurred` — Unrecognised API error response (7 tests)

The ErrorHandler couldn't parse a known error property from the response body. Needs investigation.

| API | Test | Error |
|-----|------|-------|
| OemApi | `GetConnectionReportsAsync_ReturnsReportList` | `An unknown error occurred` |
| OemApi | `GetLicensingCustomersAsync_ReturnsCustomerList` | `An unknown error occurred` |
| PatchManagement | `GetScanResultCountsAsync_ReturnsResults` | `An unknown error occurred` |
| PatchManagement | `CreateUpdateDeletePolicyAsync_FullCrudCycle` | `An unknown error occurred` |
| MonitoringPolicy | `CreateUpdateDeletePolicyAsync_FullCrudCycle` | `An unknown error occurred` |
| SsoDomain | `CreateAndDeleteSsoDomainAsync_CreatesAndDeletesDomain` | `An unknown error occurred` |
| ConditionalAccess | `CreateUpdateDeleteDirectoryGroupAsync_FullCrudCycle` | `An unknown error occurred` |
| UserRoles | `GetAccountAssignmentsAsync_ReturnsAssignments` | `An unknown error occurred` |
| UserRoles | `GetUserGroupAssignmentsAsync_ReturnsAssignments` | `An unknown error occurred` |
| IoT | `GetLatestDataAsync_ReturnsData` | `An unknown error occurred` |
| IoT | `GetWidgetsAsync_WithValidDashboard_ReturnsWidgets` | `An unknown error occurred` |

**Required**: OEM/Reach license, Patch Management add-on, Monitoring Policy access, SSO management, Tensor (Conditional Access), Role management permissions, IoT add-on

#### 6. ~~Deserialization errors — Model mismatch with live API (4 tests)~~ ✅ FIXED

~~The API returns data but the response model doesn't match. These are code bugs to fix.~~

All 4 deserialization issues have been fixed:
- **Policy.Settings**: Changed from `PolicySettings?` (flat object) to `List<PolicySetting>` — API returns an array of `{Key, Value, Enforce}` objects
- **ConnectionReport.SupportSessionType**: Changed from `string?` to `int?` — API returns a number
- **IPoliciesApi.GetAsync(policyId)**: Changed return type from `Task<Policy>` to `Task<PolicyListResponse>` — single-policy endpoint also returns the `{"policies":[...]}` wrapper

---

## Phase 37: Feature Access & Test Remediation
**Goal**: Obtain required TeamViewer licenses, fix model bugs, and get all integration tests passing

### Summary of Required Access

| # | Feature/Scope | Tests Blocked | Error Type |
|---|---------------|---------------|------------|
| 1 | **OEM / Reach license** | 8 | `not_found`, `invalid_request`, `unknown` |
| 2 | **TeamViewer Tensor** | 6 | `internal_error`, `invalid_request`, `unknown` |
| 3 | **IoT add-on** | 4 | `not_found`, `unknown` |
| 4 | **Endpoint Protection add-on** | 1 | `internal_error` |
| 5 | **Remote Management license** | 3 | `internal_error` |
| 6 | **Patch Management add-on** | 2 | `unknown` |
| 7 | **Chat scope on Script Token** | 3 | `invalid_token` |
| 8 | **Event Logging scope** | 1 | `internal_error` |
| 9 | **WebConnector license** | 1 | `not_found` |
| 10 | **OAuth2 management access** | 2 | `not_found` |
| 11 | **Socket Authentication access** | 2 | `not_found` |
| 12 | **Access Tokens scope** | 1 | `not_found` |
| 13 | **SSO management** | 1 | `unknown` |
| 14 | **Role management permissions** | 2 | `unknown` |
| 15 | **Monitoring Policy access** | 1 | `unknown` |
| — | ~~**Model bugs (no license needed)**~~ | ~~4~~ ✅ 0 | ~~deserialization~~ fixed |
| — | **Request model investigation** | 4 | `invalid_request` |

### Action Plan

#### Step 1: Fix model bugs immediately (no license needed) ✅ DONE
1. ~~Fix `PolicySettings` deserialization~~ ✅ Changed to `List<PolicySetting>` with `Key`, `Value` (`JsonElement`), `Enforce` properties
2. ~~Fix `SupportSessionType` in connection report model~~ ✅ Changed from `string?` to `int?`
3. ~~Fix `IPoliciesApi.GetAsync(policyId)` return type~~ ✅ Changed from `Task<Policy>` to `Task<PolicyListResponse>`
4. Investigate `invalid_request` errors on Contacts, Meetings, and Sessions to check if request models are correct

#### Step 2: Add missing Script Token scopes
In the TeamViewer Management Console, add these scopes to the test Script Token:
- Chat (read/write)
- Event Logging (read)
- Access Tokens (read)

#### Step 3: Contact TeamViewer Sales/Support for trial licenses
Email requesting trial access to:
1. **TeamViewer Tensor** — for Conditional Access, advanced role management
2. **OEM / Reach API** — for OEM devices, tenants, licensing, connection reports, notifications
3. **Endpoint Protection add-on** — for endpoint security management
4. **IoT add-on** — for dashboards, widgets, sensor data, edge modules
5. **Remote Management license** — for device monitoring detail (hardware/software/info)
6. **Patch Management add-on** — for patch devices, policies, scan results
7. **WebConnector license** — for web connector sessions
8. **OAuth2 management** — for OAuth2 client CRUD
9. **Socket Authentication** — for socket auth tokens

#### Step 4: After obtaining access
1. Re-run full test suite: `dotnet test`
2. Fix any remaining model mismatches revealed by actual API responses
3. Target: all 206 tests passing (or genuinely skipped for empty test data only)

### Deliverable
- All integration tests passing with real API responses
- Full API coverage validated against live TeamViewer instance
- No catch blocks suppressing failures

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

---

## Phase 38: Production Release
**Goal**: Publish stable v1.0 release to NuGet

### Prerequisites
- [ ] All Phase 37 actions complete
- [ ] All integration tests passing
- [ ] Code coverage > 80%
- [ ] README.md complete with examples
- [ ] CHANGELOG.md updated

### Steps
1. Update `version.json` to remove `-beta` suffix
2. Set version to `1.0` for stable release
3. Update `publicReleaseRefSpec` to include `main` branch
4. Final review of XML documentation
5. Run `.\Publish.ps1` to publish to NuGet
6. Create GitHub release with tag `v1.0.0`
7. Announce on relevant channels

### Post-Release
- Monitor NuGet download stats
- Address any community-reported issues
- Plan v1.1 features based on feedback
