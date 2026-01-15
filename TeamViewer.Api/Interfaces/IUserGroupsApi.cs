namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for user group management.
/// </summary>
public interface IUserGroupsApi
{
	/// <summary>
	/// Gets a list of user groups.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of user groups.</returns>
	[Get("/usergroups")]
	Task<UserGroupListResponse> GetAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Creates a new user group.
	/// </summary>
	/// <param name="request">The create request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created user group.</returns>
	[Post("/usergroups")]
	Task<UserGroup> CreateAsync(
		[Body] CreateUserGroupRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a specific user group by ID.
	/// </summary>
	/// <param name="groupId">The group ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The user group.</returns>
	[Get("/usergroups/{groupId}")]
	Task<UserGroup> GetAsync(
	int groupId,
	CancellationToken cancellationToken);

	/// <summary>
	/// Updates a user group.
	/// </summary>
	/// <param name="groupId">The group ID.</param>
	/// <param name="request">The update request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Put("/usergroups/{groupId}")]
	Task UpdateAsync(
	int groupId,
	[Body] UpdateUserGroupRequest request,
	CancellationToken cancellationToken);

	/// <summary>
	/// Deletes a user group.
	/// </summary>
	/// <param name="groupId">The group ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/usergroups/{groupId}")]
	Task DeleteAsync(
	int groupId,
	CancellationToken cancellationToken);

	/// <summary>
	/// Gets members of a user group.
	/// </summary>
	/// <param name="groupId">The group ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of group members.</returns>
	[Get("/usergroups/{groupId}/members")]
	Task<UserGroupMemberListResponse> GetMembersAsync(
	int groupId,
	CancellationToken cancellationToken);

	/// <summary>
	/// Adds a member to a user group.
	/// </summary>
	/// <param name="groupId">The group ID.</param>
	/// <param name="request">The add member request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Post("/usergroups/{groupId}/members")]
	Task AddMemberAsync(
	int groupId,
	[Body] AddUserGroupMemberRequest request,
	CancellationToken cancellationToken);

	/// <summary>
	/// Removes a member from a user group.
	/// </summary>
	/// <param name="groupId">The group ID.</param>
	/// <param name="accountId">The account ID to remove.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/usergroups/{groupId}/members/{accountId}")]
	Task RemoveMemberAsync(
	int groupId,
	string accountId,
	CancellationToken cancellationToken);

	/// <summary>
	/// Gets user roles assigned to a user group.
	/// </summary>
	/// <param name="groupId">The group ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of user roles.</returns>
	[Get("/usergroups/{groupId}/userroles")]
	Task<UserRoleListResponse> GetRolesAsync(
		int groupId,
		CancellationToken cancellationToken);
}
