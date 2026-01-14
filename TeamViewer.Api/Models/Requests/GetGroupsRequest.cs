using Refit;

namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request parameters for getting groups.
/// </summary>
public class GetGroupsRequest
{
	/// <summary>
	/// Gets or sets the name filter.
	/// </summary>
	[AliasAs("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the shared status filter.
	/// </summary>
	[AliasAs("shared")]
	public bool? Shared { get; set; }
}
