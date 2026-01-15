using Refit;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for company branding management.
/// </summary>
public interface ICompanyBrandingApi
{
	/// <summary>
	/// Gets the company branding settings.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The company branding settings.</returns>
	[Get("/companybranding")]
	Task<CompanyBranding> GetCompanyBrandingAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Updates the company branding settings.
	/// </summary>
	/// <param name="request">The update request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Put("/companybranding")]
	Task UpdateCompanyBrandingAsync([Body] UpdateCompanyBrandingRequest request, CancellationToken cancellationToken);
}
