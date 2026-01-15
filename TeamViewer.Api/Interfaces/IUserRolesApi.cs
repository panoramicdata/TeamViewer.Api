using Refit;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for user role management.
/// </summary>
public interface IUserRolesApi
{
	/// <summary>
	/// Gets a list of user roles.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of user roles.</returns>
	[Get("/userroles")]
	Task<UserRoleListResponse> GetAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets predefined user roles.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of predefined user roles.</returns>
	[Get("/userroles/predefined")]
	Task<UserRoleListResponse> GetPredefinedAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets available permissions.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of available permission names.</returns>
	[Get("/userroles/permissions")]
	Task<List<string>> GetPermissionsAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Assigns a role to an account.
	/// </summary>
	/// <param name="request">The assignment request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Post("/userroles/assign/account")]
	Task AssignToAccountAsync(
		[Body] AssignRoleToAccountRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Unassigns a role from an account.
	/// </summary>
	/// <param name="request">The unassignment request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Post("/userroles/unassign/account")]
	Task UnassignFromAccountAsync(
		[Body] UnassignRoleFromAccountRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Assigns a role to a user group.
	/// </summary>
	/// <param name="request">The assignment request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Post("/userroles/assign/usergroup")]
	Task AssignToUserGroupAsync(
		[Body] AssignRoleToUserGroupRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Unassigns a role from a user group.
	/// </summary>
	/// <param name="request">The unassignment request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Post("/userroles/unassign/usergroup")]
	Task UnassignFromUserGroupAsync(
		[Body] UnassignRoleFromUserGroupRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets role assignments for accounts.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of account role assignments.</returns>
	[Get("/userroles/assignments/account")]
	Task<RoleAssignmentListResponse> GetAccountAssignmentsAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets role assignments for user groups.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of user group role assignments.</returns>
	[Get("/userroles/assignments/usergroups")]
	Task<RoleAssignmentListResponse> GetUserGroupAssignmentsAsync(
		CancellationToken cancellationToken);
}
