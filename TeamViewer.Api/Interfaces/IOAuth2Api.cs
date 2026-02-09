using Refit;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// Interface for OAuth2 Management operations.
/// </summary>
public interface IOAuth2Api
{
	/// <summary>
	/// Gets OAuth2 clients.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>List of OAuth2 clients.</returns>
	[Get("/oauth2/clients")]
	Task<OAuth2ClientListResponse> GetClientsAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets an OAuth2 client by ID.
	/// </summary>
	/// <param name="clientId">The client ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The client details.</returns>
	[Get("/oauth2/clients/{clientId}")]
	Task<OAuth2Client> GetClientAsync(
		string clientId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Creates an OAuth2 client.
	/// </summary>
	/// <param name="request">The client creation request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created client.</returns>
	[Post("/oauth2/clients")]
	Task<OAuth2Client> CreateClientAsync(
		[Body] CreateOAuth2ClientRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Updates an OAuth2 client.
	/// </summary>
	/// <param name="clientId">The client ID.</param>
	/// <param name="request">The update request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The updated client.</returns>
	[Put("/oauth2/clients/{clientId}")]
	Task<OAuth2Client> UpdateClientAsync(
		string clientId,
		[Body] UpdateOAuth2ClientRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Deletes an OAuth2 client.
	/// </summary>
	/// <param name="clientId">The client ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/oauth2/clients/{clientId}")]
	Task DeleteClientAsync(
		string clientId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Regenerates the client secret for an OAuth2 client.
	/// </summary>
	/// <param name="clientId">The client ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The client with the new secret.</returns>
	[Post("/oauth2/clients/{clientId}/secret")]
	Task<OAuth2ClientWithSecret> RegenerateClientSecretAsync(
		string clientId,
		CancellationToken cancellationToken);
}
