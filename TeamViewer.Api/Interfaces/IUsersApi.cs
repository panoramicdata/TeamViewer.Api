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
	/// <param name="name">Filter by name (optional).</param>
	/// <param name="email">Filter by email (optional).</param>
	/// <param name="permissions">Filter by permissions (optional).</param>
	/// <param name="full">If true, returns full user details including permissions.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of users.</returns>
	[Get("/users")]
	Task<UserListResponse> GetUsersAsync(
		[AliasAs("name")] string? name = null,
		[AliasAs("email")] string? email = null,
		[AliasAs("permissions")] string? permissions = null,
		[AliasAs("full_list")] bool full = false,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Gets a specific user by ID.
	/// </summary>
	/// <param name="userId">The user ID (with or without 'u' prefix).</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The user.</returns>
	[Get("/users/{userId}")]
	Task<User> GetUserAsync(string userId, CancellationToken cancellationToken = default);

	/// <summary>
	/// Creates a new user in the company.
	/// </summary>
	/// <param name="request">The create user request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created user.</returns>
	[Post("/users")]
	Task<User> CreateUserAsync([Body] CreateUserRequest request, CancellationToken cancellationToken = default);

	/// <summary>
	/// Updates an existing user.
	/// </summary>
	/// <param name="userId">The user ID (with or without 'u' prefix).</param>
	/// <param name="request">The update user request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Put("/users/{userId}")]
	Task UpdateUserAsync(string userId, [Body] UpdateUserRequest request, CancellationToken cancellationToken = default);

	/// <summary>
	/// Deletes a user from the company.
	/// </summary>
	/// <param name="userId">The user ID (with or without 'u' prefix).</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/users/{userId}")]
	Task DeleteUserAsync(string userId, CancellationToken cancellationToken = default);
}
