using Refit;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// Interface for OEM Management and Reach API operations.
/// </summary>
public interface IOemApi
{
	#region Tenant Management (Reach API)

	/// <summary>
	/// Resolves tenants for a given account ID.
	/// </summary>
	/// <param name="accountId">The account ID to resolve tenants for.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The resolved tenant information.</returns>
	[Get("/Tenants/ResolveTenants")]
	Task<TenantResolveResponse> ResolveTenantsAsync(
		[Query] string accountId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a tenant by ID.
	/// </summary>
	/// <param name="id">The tenant ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The tenant details.</returns>
	[Get("/oem/tenants/{id}")]
	Task<OemTenant> GetTenantAsync(
		string id,
		CancellationToken cancellationToken);

	/// <summary>
	/// Creates a new tenant.
	/// </summary>
	/// <param name="request">The tenant creation request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created tenant.</returns>
	[Post("/oem/tenants")]
	Task<OemTenant> CreateTenantAsync(
		[Body] CreateOemTenantRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Updates an existing tenant.
	/// </summary>
	/// <param name="id">The tenant ID.</param>
	/// <param name="request">The tenant update request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The updated tenant.</returns>
	[Put("/oem/tenants/{id}")]
	Task<OemTenant> UpdateTenantAsync(
		string id,
		[Body] UpdateOemTenantRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets devices for a tenant.
	/// </summary>
	/// <param name="id">The tenant ID.</param>
	/// <param name="request">The request body with device filters.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>List of devices for the tenant.</returns>
	[Post("/oem/tenants/{id}/devices")]
	Task<OemDeviceListResponse> GetTenantDevicesAsync(
		string id,
		[Body] GetOemTenantDevicesRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets OEM connection reports.
	/// </summary>
	/// <param name="fromDate">Start date for the report.</param>
	/// <param name="toDate">End date for the report.</param>
	/// <param name="tenantId">Optional tenant ID filter.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>List of connection reports.</returns>
	[Get("/oem/reports/connections")]
	Task<OemConnectionReportListResponse> GetConnectionReportsAsync(
		[Query("from_date")] DateTime? fromDate,
		[Query("to_date")] DateTime? toDate,
		[Query("tenant_id")] string? tenantId,
		CancellationToken cancellationToken);

	#endregion

	#region OEM Licensing

	/// <summary>
	/// Gets OEM licensing customers.
	/// </summary>
	/// <param name="resellerId">Optional reseller ID filter.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>List of OEM licensing customers.</returns>
	[Get("/oem/licensing/customers")]
	Task<OemLicensingCustomerListResponse> GetLicensingCustomersAsync(
		[Query("resellerID")] string? resellerId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Creates an OEM licensing customer.
	/// </summary>
	/// <param name="request">The customer creation request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created customer.</returns>
	[Post("/oem/licensing/customers")]
	Task<OemLicensingCustomer> CreateLicensingCustomerAsync(
		[Body] CreateOemLicensingCustomerRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Deletes OEM licensing customers.
	/// </summary>
	/// <param name="request">The deletion request with customer IDs.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/oem/licensing/customers")]
	Task DeleteLicensingCustomersAsync(
		[Body] DeleteOemLicensingCustomersRequest request,
		CancellationToken cancellationToken);

	#endregion

	#region Integrations

	/// <summary>
	/// Registers a user via OEM integration.
	/// </summary>
	/// <param name="request">The user registration request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The registered user information.</returns>
	[Post("/integrations/registerUser")]
	Task<OemRegisteredUser> RegisterUserAsync(
		[Body] RegisterOemUserRequest request,
		CancellationToken cancellationToken);

	#endregion
}
