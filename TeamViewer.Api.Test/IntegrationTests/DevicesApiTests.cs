namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Devices API.
/// </summary>
public class DevicesApiTest(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetDevicesAsync_ReturnsDeviceList()
	{
		EnsureConfigured();

		// Act
		var result = await Client.Devices.GetAsync(new GetDevicesRequest(), CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Devices.Should().NotBeNull();
	}

	[Fact]
	public async Task GetDevicesAsync_WithGroupFilter_ReturnsFilteredDevices()
	{
		EnsureConfigured();

		// First get a group ID
		var groups = await Client.Groups.GetAsync(new GetGroupsRequest(), CancellationToken);

		if (groups.Groups.Count == 0)
		{
			Assert.Skip("No groups available for filtering.");
			return;
		}

		var groupId = groups.Groups[0].Id!;

		// Act
		var result = await Client.Devices.GetAsync(new GetDevicesRequest { GroupId = groupId }, CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Devices.Should().NotBeNull();
	}

	[Fact]
	public async Task GetDevicesAsync_WithOnlineStateFilter_ReturnsFilteredDevices()
	{
		EnsureConfigured();

		// Act
		var result = await Client.Devices.GetAsync(new GetDevicesRequest { OnlineState = "online" }, CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Devices.Should().NotBeNull();
	}

	[Fact]
	public async Task GetDeviceAsync_WithValidDeviceId_ReturnsDevice()
	{
		EnsureConfigured();

		// First get a list of devices to find a valid ID
		var devices = await Client.Devices.GetAsync(new GetDevicesRequest(), CancellationToken);

		if (devices.Devices.Count == 0)
		{
			Assert.Skip("No devices available for testing.");
			return;
		}

		var deviceId = devices.Devices[0].DeviceId!;

		// Act
		var result = await Client.Devices.GetAsync(deviceId, CancellationToken);

		// Assert - single device may have different structure, just verify we got a response
		result.Should().NotBeNull();
	}
}
