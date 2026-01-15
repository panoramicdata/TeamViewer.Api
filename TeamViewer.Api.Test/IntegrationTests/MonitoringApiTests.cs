namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Monitoring API.
/// </summary>
public class MonitoringApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetAlarmsAsync_ReturnsAlarmList()
	{
		// Act
		var result = await Client.Monitoring.GetAlarmsAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Alarms.Should().NotBeNull();
	}

	[Fact]
	public async Task GetDevicesAsync_ReturnsDeviceList()
	{
		// Act
		var result = await Client.Monitoring.GetDevicesAsync(CancellationToken);

		// Assert
		result.Should().NotBeNull();
	}

	[Fact]
	public async Task GetDeviceInformationAsync_WithValidDevice_ReturnsInfo()
	{
		var devices = await Client.Monitoring.GetDevicesAsync(CancellationToken);
		if (devices.Count == 0)
		{
			Assert.Skip("No monitored devices available for testing.");
			return;
		}

		// Act
		var result = await Client.Monitoring.GetDeviceInformationAsync(
			devices[0].DeviceId!,
			CancellationToken);

		// Assert
		result.Should().NotBeNull();
	}

	[Fact]
	public async Task GetDeviceHardwareAsync_WithValidDevice_ReturnsHardwareInfo()
	{
		var devices = await Client.Monitoring.GetDevicesAsync(CancellationToken);
		if (devices.Count == 0)
		{
			Assert.Skip("No monitored devices available for testing.");
			return;
		}

		// Act
		var result = await Client.Monitoring.GetDeviceHardwareAsync(
			devices[0].DeviceId!,
			CancellationToken);

		// Assert
		result.Should().NotBeNull();
	}

	[Fact]
	public async Task GetDeviceSoftwareAsync_WithValidDevice_ReturnsSoftwareInfo()
	{
		var devices = await Client.Monitoring.GetDevicesAsync(CancellationToken);
		if (devices.Count == 0)
		{
			Assert.Skip("No monitored devices available for testing.");
			return;
		}

		// Act
		var result = await Client.Monitoring.GetDeviceSoftwareAsync(
			devices[0].DeviceId!,
			CancellationToken);

		// Assert
		result.Should().NotBeNull();
		result.Software.Should().NotBeNull();
	}
}
