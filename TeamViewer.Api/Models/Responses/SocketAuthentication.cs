using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Responses;

/// <summary>
/// Represents a socket authentication token.
/// </summary>
public class SocketAuthenticationToken
{
	/// <summary>
	/// Gets or sets the authentication token.
	/// </summary>
	[JsonPropertyName("token")]
	public string Token { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the token expiration time.
	/// </summary>
	[JsonPropertyName("expires_at")]
	public DateTime? ExpiresAt { get; set; }

	/// <summary>
	/// Gets or sets the WebSocket endpoint URL.
	/// </summary>
	[JsonPropertyName("websocket_url")]
	public string? WebSocketUrl { get; set; }

	/// <summary>
	/// Gets or sets the token type.
	/// </summary>
	[JsonPropertyName("token_type")]
	public string? TokenType { get; set; }
}

/// <summary>
/// Result of socket token validation.
/// </summary>
public class SocketTokenValidationResult
{
	/// <summary>
	/// Gets or sets whether the token is valid.
	/// </summary>
	[JsonPropertyName("valid")]
	public bool Valid { get; set; }

	/// <summary>
	/// Gets or sets the token expiration time if valid.
	/// </summary>
	[JsonPropertyName("expires_at")]
	public DateTime? ExpiresAt { get; set; }

	/// <summary>
	/// Gets or sets the account ID associated with the token.
	/// </summary>
	[JsonPropertyName("account_id")]
	public string? AccountId { get; set; }

	/// <summary>
	/// Gets or sets error message if validation failed.
	/// </summary>
	[JsonPropertyName("error")]
	public string? Error { get; set; }
}
