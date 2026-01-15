namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Response containing a list of API access tokens.
/// </summary>
public class AccessTokenListResponse
{
	/// <summary>
	/// Gets or sets the list of access tokens.
	/// </summary>
	[JsonPropertyName("tokens")]
	public List<AccessToken> Tokens { get; set; } = [];
}
