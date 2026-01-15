using Refit;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for company information.
/// </summary>
public interface ICompanyApi
{
	/// <summary>
	/// Gets the company information.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The company information.</returns>
	[Get("/company")]
	Task<Company> GetAsync(
		CancellationToken cancellationToken);
}
