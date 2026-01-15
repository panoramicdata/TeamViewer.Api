using TeamViewer.Api.Exceptions;

namespace TeamViewer.Api.Test.IntegrationTests;

/// <summary>
/// Integration tests for the IoT API.
/// </summary>
public class IotApiTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetDashboardsAsync_ReturnsDashboardList()
	{
		try
		{
			// Act
			var result = await Client.Iot.GetDashboardsAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Dashboards.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("IoT API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetDeviceConfigurationsAsync_ReturnsConfigList()
	{
		try
		{
			// Act
			var result = await Client.Iot.GetDeviceConfigurationsAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Configurations.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("IoT API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetEdgeModulesAsync_ReturnsModuleList()
	{
		try
		{
			// Act
			var result = await Client.Iot.GetEdgeModulesAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Modules.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("IoT API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetLatestDataAsync_ReturnsData()
	{
		try
		{
			// Act
			var result = await Client.Iot.GetLatestDataAsync(CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.DataPoints.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("IoT API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task CreateUpdateDeleteDashboardAsync_FullCrudCycle()
	{
		var testName = $"{TestPrefix}Dashboard_{DateTime.UtcNow:HHmmss}";

		try
		{
			// Create
			var created = await Client.Iot.CreateDashboardAsync(
				new CreateIotDashboardRequest { Name = testName, Description = "Test IoT dashboard" },
				CancellationToken);

			created.Should().NotBeNull();
			created.Id.Should().NotBeNullOrEmpty();
			created.Name.Should().Be(testName);

			// Read
			var retrieved = await Client.Iot.GetDashboardAsync(created.Id!, CancellationToken);
			retrieved.Should().NotBeNull();
			retrieved.Name.Should().Be(testName);

			// Update
			var updatedName = $"{testName}_Updated";
			await Client.Iot.UpdateDashboardAsync(
				created.Id!,
				new UpdateIotDashboardRequest { Name = updatedName },
				CancellationToken);

			var afterUpdate = await Client.Iot.GetDashboardAsync(created.Id!, CancellationToken);
			afterUpdate.Name.Should().Be(updatedName);

			// Delete
			await Client.Iot.DeleteDashboardAsync(created.Id!, CancellationToken);
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("IoT API requires additional permissions or is not available.");
		}
	}

	[Fact]
	public async Task GetWidgetsAsync_WithValidDashboard_ReturnsWidgets()
	{
		try
		{
			var dashboards = await Client.Iot.GetDashboardsAsync(CancellationToken);
			if (dashboards.Dashboards.Count == 0)
			{
				Assert.Skip("No IoT dashboards available for testing.");
				return;
			}

			// Act
			var result = await Client.Iot.GetWidgetsAsync(
				dashboards.Dashboards[0].Id!,
				CancellationToken);

			// Assert
			result.Should().NotBeNull();
			result.Widgets.Should().NotBeNull();
		}
		catch (TeamViewerApiException ex) when (ex.Message.Contains("invalid_token") || ex.Message.Contains("permission") || ex.Message.Contains("not_found") || ex.Message.Contains("unknown"))
		{
			Assert.Skip("IoT API requires additional permissions or is not available.");
		}
	}
}
