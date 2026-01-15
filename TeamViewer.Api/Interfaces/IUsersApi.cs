using Refit;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for user management.
/// </summary>
public interface IUsersApi
{
	/// <summary>
	/// Gets a list of users in the company.
	/// </summary>
	/// <param name="request">The request parameters.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of users.</returns>
	[Get("/users")]
	Task<UserListResponse> GetAsync(
		[Query] GetUsersRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a specific user by ID.
	/// </summary>
	/// <param name="userId">The user ID (with or without 'u' prefix).</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The user.</returns>
	[Get("/users/{userId}")]
	Task<User> GetAsync(
		string userId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Creates a new user in the company.
	/// </summary>
	/// <param name="request">The create user request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created user.</returns>
	[Post("/users")]
	Task<User> CreateAsync(
		[Body] CreateUserRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Updates an existing user.
	/// </summary>
	/// <param name="userId">The user ID (with or without 'u' prefix).</param>
	/// <param name="request">The update user request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Put("/users/{userId}")]
	Task UpdateAsync(
		string userId,
		[Body] UpdateUserRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Deletes a user from the company.
	/// </summary>
	/// <param name="userId">The user ID (with or without 'u' prefix).</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/users/{userId}")]
	Task DeleteAsync(
		string userId,
		CancellationToken cancellationToken);
}
