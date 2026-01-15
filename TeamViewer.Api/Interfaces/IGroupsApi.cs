using Refit;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for group management.
/// </summary>
public interface IGroupsApi
{
	/// <summary>
	/// Gets a list of groups.
	/// </summary>
	/// <param name="request">The request parameters.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of groups.</returns>
	[Get("/groups")]
	Task<GroupListResponse> GetAsync(
		[Query] GetGroupsRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a specific group by ID.
	/// </summary>
	/// <param name="groupId">The group ID (with or without 'g' prefix).</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The group.</returns>
	[Get("/groups/{groupId}")]
	Task<Group> GetAsync(
		string groupId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Creates a new group.
	/// </summary>
	/// <param name="request">The create group request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created group.</returns>
	[Post("/groups")]
	Task<Group> CreateAsync(
		[Body] CreateGroupRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Updates an existing group.
	/// </summary>
	/// <param name="groupId">The group ID (with or without 'g' prefix).</param>
	/// <param name="request">The update group request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Put("/groups/{groupId}")]
	Task UpdateAsync(
		string groupId,
		[Body] UpdateGroupRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Deletes a group.
	/// </summary>
	/// <param name="groupId">The group ID (with or without 'g' prefix).</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/groups/{groupId}")]
	Task DeleteAsync(
		string groupId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Shares a group with users.
	/// </summary>
	/// <param name="groupId">The group ID (with or without 'g' prefix).</param>
	/// <param name="request">The share group request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Post("/groups/{groupId}/share")]
	Task ShareAsync(
		string groupId,
		[Body] ShareGroupRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Unshares a group from a user.
	/// </summary>
	/// <param name="groupId">The group ID (with or without 'g' prefix).</param>
	/// <param name="userId">The user ID to unshare from.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/groups/{groupId}/share/{userId}")]
	Task UnshareAsync(
		string groupId,
		string userId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets the users a group is shared with.
	/// </summary>
	/// <param name="groupId">The group ID (with or without 'g' prefix).</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of shared users.</returns>
	[Get("/groups/{groupId}/share")]
	Task<GroupShareListResponse> GetSharesAsync(
		string groupId,
		CancellationToken cancellationToken);
}
