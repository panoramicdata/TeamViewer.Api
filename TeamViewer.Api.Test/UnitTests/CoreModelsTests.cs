using System.Text.Json;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Unit tests for core response model serialization and deserialization.
/// </summary>
public class CoreModelsTests
{
	private static readonly JsonSerializerOptions JsonOptions = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
	};

	#region Account and User Models

	[Fact]
	public void AccountResponse_Serialization_RoundTrips()
	{
		// Arrange
		var account = new AccountResponse
		{
			UserId = "u12345",
			Email = "test@example.com",
			Name = "Test User",
			CompanyName = "Test Company"
		};

		// Act
		var json = JsonSerializer.Serialize(account, JsonOptions);
		var deserialized = JsonSerializer.Deserialize<AccountResponse>(json, JsonOptions);

		// Assert
		deserialized.Should().NotBeNull();
		deserialized!.UserId.Should().Be(account.UserId);
		deserialized.Email.Should().Be(account.Email);
		deserialized.Name.Should().Be(account.Name);
		deserialized.CompanyName.Should().Be(account.CompanyName);
	}

	[Fact]
	public void User_Serialization_RoundTrips()
	{
		// Arrange
		var user = new User
		{
			Id = "user-123",
			Email = "user@example.com",
			Name = "John Doe",
			Active = true
		};

		// Act
		var json = JsonSerializer.Serialize(user, JsonOptions);
		var deserialized = JsonSerializer.Deserialize<User>(json, JsonOptions);

		// Assert
		deserialized.Should().NotBeNull();
		deserialized!.Id.Should().Be(user.Id);
		deserialized.Email.Should().Be(user.Email);
		deserialized.Name.Should().Be(user.Name);
		deserialized.Active.Should().BeTrue();
	}

	#endregion

	#region Device and Group Models

	[Fact]
	public void Device_Serialization_RoundTrips()
	{
		// Arrange
		var device = new Device
		{
			DeviceId = "d12345",
			Alias = "My Computer",
			OnlineState = "Online",
			RemoteControlId = "r123456789"
		};

		// Act
		var json = JsonSerializer.Serialize(device, JsonOptions);
		var deserialized = JsonSerializer.Deserialize<Device>(json, JsonOptions);

		// Assert
		deserialized.Should().NotBeNull();
		deserialized!.DeviceId.Should().Be(device.DeviceId);
		deserialized.Alias.Should().Be(device.Alias);
		deserialized.OnlineState.Should().Be(device.OnlineState);
	}

	[Fact]
	public void Group_Serialization_RoundTrips()
	{
		// Arrange
		var group = new Group
		{
			Id = "g12345",
			Name = "My Group"
		};

		// Act
		var json = JsonSerializer.Serialize(group, JsonOptions);
		var deserialized = JsonSerializer.Deserialize<Group>(json, JsonOptions);

		// Assert
		deserialized.Should().NotBeNull();
		deserialized!.Id.Should().Be(group.Id);
		deserialized.Name.Should().Be(group.Name);
	}

	[Fact]
	public void DeviceListResponse_WithEmptyDevices_Initializes()
	{
		// Arrange & Act
		var response = new DeviceListResponse();

		// Assert
		response.Devices.Should().NotBeNull();
		response.Devices.Should().BeEmpty();
	}

	#endregion

	#region Session and Meeting Models

	[Fact]
	public void Session_Serialization_RoundTrips()
	{
		// Arrange
		var session = new Session
		{
			Code = "s12-345-678",
			State = "open",
			EndCustomer = "Customer Name"
		};

		// Act
		var json = JsonSerializer.Serialize(session, JsonOptions);
		var deserialized = JsonSerializer.Deserialize<Session>(json, JsonOptions);

		// Assert
		deserialized.Should().NotBeNull();
		deserialized!.Code.Should().Be(session.Code);
		deserialized.State.Should().Be(session.State);
	}

	[Fact]
	public void Meeting_Serialization_RoundTrips()
	{
		// Arrange
		var meeting = new Meeting
		{
			MeetingId = "m12345",
			Subject = "Team Meeting",
			Start = DateTime.UtcNow,
			End = DateTime.UtcNow.AddHours(1)
		};

		// Act
		var json = JsonSerializer.Serialize(meeting, JsonOptions);
		var deserialized = JsonSerializer.Deserialize<Meeting>(json, JsonOptions);

		// Assert
		deserialized.Should().NotBeNull();
		deserialized!.MeetingId.Should().Be(meeting.MeetingId);
		deserialized.Subject.Should().Be(meeting.Subject);
	}

	#endregion

	#region Report Models

	[Fact]
	public void ConnectionReport_Serialization_RoundTrips()
	{
		// Arrange
		var report = new ConnectionReport
		{
			Id = "r12345",
			UserId = "u123",
			UserName = "Test User",
			StartDate = DateTime.UtcNow.AddHours(-1),
			EndDate = DateTime.UtcNow
		};

		// Act
		var json = JsonSerializer.Serialize(report, JsonOptions);
		var deserialized = JsonSerializer.Deserialize<ConnectionReport>(json, JsonOptions);

		// Assert
		deserialized.Should().NotBeNull();
		deserialized!.Id.Should().Be(report.Id);
		deserialized.UserId.Should().Be(report.UserId);
		deserialized.UserName.Should().Be(report.UserName);
	}

	#endregion

	#region Policy Models

	[Fact]
	public void Policy_Serialization_RoundTrips()
	{
		// Arrange
		var policy = new Policy
		{
			PolicyId = "pol-123",
			Name = "Security Policy"
		};

		// Act
		var json = JsonSerializer.Serialize(policy, JsonOptions);
		var deserialized = JsonSerializer.Deserialize<Policy>(json, JsonOptions);

		// Assert
		deserialized.Should().NotBeNull();
		deserialized!.PolicyId.Should().Be(policy.PolicyId);
		deserialized.Name.Should().Be(policy.Name);
	}

	#endregion

	#region Ping Response

	[Fact]
	public void PingResponse_Serialization_RoundTrips()
	{
		// Arrange
		var ping = new PingResponse
		{
			TokenValid = true
		};

		// Act
		var json = JsonSerializer.Serialize(ping, JsonOptions);
		var deserialized = JsonSerializer.Deserialize<PingResponse>(json, JsonOptions);

		// Assert
		deserialized.Should().NotBeNull();
		deserialized!.TokenValid.Should().BeTrue();
	}

	[Fact]
	public void PingResponse_InvalidToken_Deserializes()
	{
		// Arrange
		var json = """{"token_valid":false}""";

		// Act
		var ping = JsonSerializer.Deserialize<PingResponse>(json, JsonOptions);

		// Assert
		ping.Should().NotBeNull();
		ping!.TokenValid.Should().BeFalse();
	}

	#endregion

	#region Access Token Models

	[Fact]
	public void AccessToken_Serialization_RoundTrips()
	{
		// Arrange
		var token = new AccessToken
		{
			Token = "abc123",
			Name = "Test Token"
		};

		// Act
		var json = JsonSerializer.Serialize(token, JsonOptions);
		var deserialized = JsonSerializer.Deserialize<AccessToken>(json, JsonOptions);

		// Assert
		deserialized.Should().NotBeNull();
		deserialized!.Token.Should().Be(token.Token);
		deserialized.Name.Should().Be(token.Name);
	}

	#endregion
}
