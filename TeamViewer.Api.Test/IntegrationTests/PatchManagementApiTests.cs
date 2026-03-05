namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Patch Management API.
/// </summary>
public class PatchManagementApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetDevicesAsync_ReturnsDeviceList()
	{
		// Act
		var result = await Client.PatchManagement.GetDevicesAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Devices.Should().NotBeNull();
	}

	[Fact]
	public async Task GetScanResultCountsAsync_ReturnsResults()
	{
		// Act
		var result = await Client.PatchManagement.GetScanResultCountsAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
	}

	[Fact]
	public async Task GetMissingPatchesAsync_WithValidDevice_ReturnsPatchList()
	{
		var devices = await Client.PatchManagement.GetDevicesAsync(CancellationToken);
		if (devices.Devices.Count == 0)
		{
			Assert.Skip("No devices available for patch management testing.");
			return;
		}

		// Act
		var result = await Client.PatchManagement.GetMissingPatchesAsync(
			devices.Devices[0].DeviceId!,
			CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Patches.Should().NotBeNull();
	}

	[Fact]
	public async Task GetPoliciesAsync_ReturnsPolicyList()
	{
		// Act
		var result = await Client.PatchManagement.GetPoliciesAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Policies.Should().NotBeNull();
	}

	[Fact]
	public async Task CreateUpdateDeletePolicyAsync_FullCrudCycle()
	{
		var testName = $"{TestPrefix}PatchPolicy_{DateTime.UtcNow:HHmmss}";

		// Create
		var created = await Client.PatchManagement.CreatePolicyAsync(
			new CreatePatchPolicyRequest { Name = testName, Description = "Test patch policy" },
			CancellationToken);

		created.Should().NotBeNull();
		created.Id.Should().NotBeNullOrEmpty();
		created.Name.Should().Be(testName);

		// Read
		var retrieved = await Client.PatchManagement.GetPolicyAsync(created.Id!, CancellationToken);
		retrieved.Should().NotBeNull();
		retrieved.Name.Should().Be(testName);

		// Update
		var updatedName = $"{testName}_Updated";
		await Client.PatchManagement.UpdatePolicyAsync(
			created.Id!,
			new UpdatePatchPolicyRequest { Name = updatedName },
			CancellationToken);

		var afterUpdate = await Client.PatchManagement.GetPolicyAsync(created.Id!, CancellationToken);
		afterUpdate.Name.Should().Be(updatedName);

		// Delete
		await Client.PatchManagement.DeletePolicyAsync(created.Id!, CancellationToken);
	}
}
