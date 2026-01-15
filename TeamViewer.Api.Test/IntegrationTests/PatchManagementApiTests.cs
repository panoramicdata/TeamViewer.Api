using TeamViewer.Api.Exceptions;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Patch Management API.
/// </summary>
public class PatchManagementApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetDevicesAsync_ReturnsDeviceList()
	{
		try
		{
			// Act
			var result = await Client.PatchManagement.GetDevicesAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Devices.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Patch Management API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetScanResultCountsAsync_ReturnsResults()
	{
		try
		{
			// Act
			var result = await Client.PatchManagement.GetScanResultCountsAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Patch Management API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetMissingPatchesAsync_WithValidDevice_ReturnsPatchList()
	{
		try
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
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Patch Management API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetPoliciesAsync_ReturnsPolicyList()
	{
		try
		{
			// Act
			var result = await Client.PatchManagement.GetPoliciesAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Policies.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Patch Management API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task CreateUpdateDeletePolicyAsync_FullCrudCycle()
	{
		var testName = $"{TestPrefix}PatchPolicy_{DateTime.UtcNow:HHmmss}";

		try
		{
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
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Patch Management API requires additional permissions or is not available.");
		}
	}
}
