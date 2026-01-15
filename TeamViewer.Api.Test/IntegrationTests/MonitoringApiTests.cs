using TeamViewer.Api.Exceptions;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the Monitoring API.
/// </summary>
public class MonitoringApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetAlarmsAsync_ReturnsAlarmList()
	{
		try
		{
			// Act
			var result = await Client.Monitoring.GetAlarmsAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Alarms.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Monitoring API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetDevicesAsync_ReturnsDeviceList()
	{
		try
		{
			// Act
			var result = await Client.Monitoring.GetDevicesAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Devices.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Monitoring API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetDeviceInformationAsync_WithValidDevice_ReturnsInfo()
	{
		try
		{
			var devices = await Client.Monitoring.GetDevicesAsync(CancellationToken);
			if (devices.Devices.Count == 0)
			{
				Assert.Skip("No monitored devices available for testing.");
				return;
			}

			// Act
			var result = await Client.Monitoring.GetDeviceInformationAsync(
				devices.Devices[0].DeviceId!,
				CancellationToken);

			// Assert
			result.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Monitoring API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetDeviceHardwareAsync_WithValidDevice_ReturnsHardwareInfo()
	{
		try
		{
			var devices = await Client.Monitoring.GetDevicesAsync(CancellationToken);
			if (devices.Devices.Count == 0)
			{
				Assert.Skip("No monitored devices available for testing.");
				return;
			}

			// Act
			var result = await Client.Monitoring.GetDeviceHardwareAsync(
				devices.Devices[0].DeviceId!,
				CancellationToken);

			// Assert
			result.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Monitoring API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetDeviceSoftwareAsync_WithValidDevice_ReturnsSoftwareInfo()
	{
		try
		{
			var devices = await Client.Monitoring.GetDevicesAsync(CancellationToken);
			if (devices.Devices.Count == 0)
			{
				Assert.Skip("No monitored devices available for testing.");
				return;
			}

			// Act
			var result = await Client.Monitoring.GetDeviceSoftwareAsync(
				devices.Devices[0].DeviceId!,
				CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Software.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("Monitoring API requires additional permissions or is not available.");
		}
	}
}
