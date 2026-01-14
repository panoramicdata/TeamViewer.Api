using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing a list of policies.
/// </summary>
public class PolicyListResponse
{
	/// <summary>
	/// Gets or sets the list of policies.
	/// </summary>
	[JsonPropertyName("policies")]
	public List<Policy> Policies { get; set; } = [];
}
