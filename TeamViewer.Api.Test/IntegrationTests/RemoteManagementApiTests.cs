namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Remote Management API.
/// </summary>
public class RemoteManagementApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetManagedDevicesAsync_ReturnsManagedDeviceList()
	{
		EnsureConfigured();

		// Act
		var result = await Client
			.RemoteManagement
			.GetManagedDevicesAsync(
				new GetManagedDevicesRequest(),
				CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Devices.Should().NotBeNull();
	}

	[Fact]
	public async Task GetManagedGroupsAsync_ReturnsManagedGroupList()
	{
		EnsureConfigured();

		// Act
		var result = await Client
			.RemoteManagement
			.GetManagedGroupsAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Groups.Should().NotBeNull();
	}
}
