using TeamViewer.Api.Test.Infrastructure;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Devices API.
/// </summary>
public class DevicesApiTests : IntegrationTestBase
{
	[Fact]
	public async Task GetDevicesAsync_ReturnsDeviceList()
	{
		EnsureConfigured();

		// Act
		var result = await Client!.Devices.GetDevicesAsync(new GetDevicesRequest(), TestContext.Current.CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Devices.Should().NotBeNull();
	}

	[Fact]
	public async Task GetDevicesAsync_WithGroupFilter_ReturnsFilteredDevices()
	{
		EnsureConfigured();

		// First get a group ID
		var groups = await Client!.Groups.GetGroupsAsync(new GetGroupsRequest(), TestContext.Current.CancellationToken);

		if (groups.Groups.Count == 0)
		{
			Assert.Skip("No groups available for filtering.");
			return;
		}

		var groupId = groups.Groups[0].Id!;

		// Act
		var result = await Client!.Devices.GetDevicesAsync(new GetDevicesRequest { GroupId = groupId }, TestContext.Current.CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Devices.Should().NotBeNull();
	}

	[Fact]
	public async Task GetDevicesAsync_WithOnlineStateFilter_ReturnsFilteredDevices()
	{
		EnsureConfigured();

		// Act
		var result = await Client!.Devices.GetDevicesAsync(new GetDevicesRequest { OnlineState = "online" }, TestContext.Current.CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Devices.Should().NotBeNull();
	}

	[Fact]
	public async Task GetDeviceAsync_WithValidDeviceId_ReturnsDevice()
	{
		EnsureConfigured();

		// First get a list of devices to find a valid ID
		var devices = await Client!.Devices.GetDevicesAsync(new GetDevicesRequest(), TestContext.Current.CancellationToken);

		if (devices.Devices.Count == 0)
		{
			Assert.Skip("No devices available for testing.");
			return;
		}

		var deviceId = devices.Devices[0].DeviceId!;

		// Act
		var result = await Client!.Devices.GetDeviceAsync(deviceId, TestContext.Current.CancellationToken);

		// Assert - single device may have different structure, just verify we got a response
		result.Should().NotBeNull();
	}
}
