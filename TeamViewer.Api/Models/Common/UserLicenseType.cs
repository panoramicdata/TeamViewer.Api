namespace TeamViewer.Api.Models.Common;

/// <summary>
/// License types for TeamViewer users.
/// </summary>
public enum UserLicenseType
{
	/// <summary>
	/// Free license.
	/// </summary>
	Free,

	/// <summary>
	/// Business license.
	/// </summary>
	Business,

	/// <summary>
	/// Premium license.
	/// </summary>
	Premium,

	/// <summary>
	/// Corporate license.
	/// </summary>
	Corporate,

	/// <summary>
	/// Tensor license.
	/// </summary>
	Tensor,

	/// <summary>
	/// Unknown or unspecified license type.
	/// </summary>
	Unknown
}
