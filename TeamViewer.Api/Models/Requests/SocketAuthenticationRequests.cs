using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to validate a socket authentication token.
/// </summary>
public class ValidateSocketTokenRequest
{
	/// <summary>
	/// Gets or sets the token to validate.
	/// </summary>
	[JsonPropertyName("token")]
	public required string Token { get; set; }
}

/// <summary>
/// Request to revoke a socket authentication token.
/// </summary>
public class RevokeSocketTokenRequest
{
	/// <summary>
	/// Gets or sets the token to revoke.
	/// </summary>
	[JsonPropertyName("token")]
	public required string Token { get; set; }
}
