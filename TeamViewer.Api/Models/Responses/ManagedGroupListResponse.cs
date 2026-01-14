using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing a list of managed groups.
/// </summary>
public class ManagedGroupListResponse
{
	/// <summary>
	/// Gets or sets the list of managed groups.
	/// </summary>
	[JsonPropertyName("groups")]
	public List<ManagedGroup> Groups { get; set; } = [];
}
