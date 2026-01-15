namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing a list of groups.
/// </summary>
public class GroupListResponse
{
	/// <summary>
	/// Gets or sets the list of groups.
	/// </summary>
	[JsonPropertyName("groups")]
	public List<Group> Groups { get; set; } = [];
}
