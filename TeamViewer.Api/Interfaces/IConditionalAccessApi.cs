using Refit;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Interfaces;

/// <summary>
/// API interface for conditional access management.
/// </summary>
public interface IConditionalAccessApi
{
	/// <summary>
	/// Gets a list of directory groups.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of directory groups.</returns>
	[Get("/ConditionalAccess/DirectoryGroups")]
	Task<DirectoryGroupListResponse> GetDirectoryGroupsAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Creates a new directory group.
	/// </summary>
	/// <param name="request">The create request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created directory group.</returns>
	[Post("/ConditionalAccess/DirectoryGroups")]
	Task<DirectoryGroup> CreateDirectoryGroupAsync(
		[Body] CreateDirectoryGroupRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a specific directory group by ID.
	/// </summary>
	/// <param name="groupId">The group ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The directory group.</returns>
	[Get("/ConditionalAccess/DirectoryGroups/{groupId}")]
	Task<DirectoryGroup> GetDirectoryGroupAsync(
		string groupId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Updates a directory group.
	/// </summary>
	/// <param name="groupId">The group ID.</param>
	/// <param name="request">The update request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Put("/ConditionalAccess/DirectoryGroups/{groupId}")]
	Task UpdateDirectoryGroupAsync(
		string groupId,
		[Body] UpdateDirectoryGroupRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Deletes a directory group.
	/// </summary>
	/// <param name="groupId">The group ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/ConditionalAccess/DirectoryGroups/{groupId}")]
	Task DeleteDirectoryGroupAsync(
		string groupId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets members of a directory group.
	/// </summary>
	/// <param name="groupId">The group ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of group members.</returns>
	[Get("/ConditionalAccess/DirectoryGroups/{groupId}/members")]
	Task<DirectoryGroupMemberListResponse> GetDirectoryGroupMembersAsync(
		string groupId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a list of conditional access rules.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of rules.</returns>
	[Get("/ConditionalAccess/Rules")]
	Task<ConditionalAccessRuleListResponse> GetRulesAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Creates a new conditional access rule.
	/// </summary>
	/// <param name="request">The create request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The created rule.</returns>
	[Post("/ConditionalAccess/Rules")]
	Task<ConditionalAccessRule> CreateRuleAsync(
		[Body] CreateConditionalAccessRuleRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets a specific conditional access rule by ID.
	/// </summary>
	/// <param name="ruleId">The rule ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The rule.</returns>
	[Get("/ConditionalAccess/Rules/{ruleId}")]
	Task<ConditionalAccessRule> GetRuleAsync(
		string ruleId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Updates a conditional access rule.
	/// </summary>
	/// <param name="ruleId">The rule ID.</param>
	/// <param name="request">The update request.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Put("/ConditionalAccess/Rules/{ruleId}")]
	Task UpdateRuleAsync(
		string ruleId,
		[Body] UpdateConditionalAccessRuleRequest request,
		CancellationToken cancellationToken);

	/// <summary>
	/// Deletes a conditional access rule.
	/// </summary>
	/// <param name="ruleId">The rule ID.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A task representing the operation.</returns>
	[Delete("/ConditionalAccess/Rules/{ruleId}")]
	Task DeleteRuleAsync(
		string ruleId,
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets approval options.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of approval options.</returns>
	[Get("/ConditionalAccess/Options/Approval")]
	Task<ConditionalAccessOptionListResponse> GetApprovalOptionsAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets feature options.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of feature options.</returns>
	[Get("/ConditionalAccess/Options/Features")]
	Task<ConditionalAccessOptionListResponse> GetFeatureOptionsAsync(
		CancellationToken cancellationToken);

	/// <summary>
	/// Gets time options.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>A list of time options.</returns>
	[Get("/ConditionalAccess/Options/Time")]
	Task<ConditionalAccessOptionListResponse> GetTimeOptionsAsync(
		CancellationToken cancellationToken);
}
