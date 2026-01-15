using System.Text.Json.Serialization;

namespace TeamViewer.Api.Models.Requests;

/// <summary>
/// Request to create a patch management policy.
/// </summary>
public class CreatePatchPolicyRequest
{
	/// <summary>
	/// Gets or sets the policy name. Required.
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// Gets or sets the policy description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the policy is enabled.
	/// </summary>
	[JsonPropertyName("enabled")]
	public bool Enabled { get; set; } = true;
}

/// <summary>
/// Request to update a patch management policy.
/// </summary>
public class UpdatePatchPolicyRequest
{
	/// <summary>
	/// Gets or sets the policy name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the policy description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the policy is enabled.
	/// </summary>
	[JsonPropertyName("enabled")]
	public bool? Enabled { get; set; }
}

/// <summary>
/// Request to assign a patch management policy.
/// </summary>
public class AssignPatchPolicyRequest
{
	/// <summary>
	/// Gets or sets the policy ID. Required.
	/// </summary>
	[JsonPropertyName("policyId")]
	public required string PolicyId { get; set; }

	/// <summary>
	/// Gets or sets the device IDs to assign the policy to.
	/// </summary>
	[JsonPropertyName("deviceIds")]
	public List<string> DeviceIds { get; set; } = [];
}
