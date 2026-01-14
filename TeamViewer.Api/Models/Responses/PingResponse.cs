using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response from the ping endpoint.
/// </summary>
public class PingResponse
{
	/// <summary>
	/// Gets or sets a value indicating whether the token is valid.
	/// </summary>
	[JsonPropertyName("token_valid")]
	public bool TokenValid { get; set; }
}
