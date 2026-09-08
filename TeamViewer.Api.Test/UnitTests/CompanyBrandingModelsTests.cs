using System.Text.Json;
using TeamViewer.Api.Models.Requests;
using TeamViewer.Api.Models.Responses;

namespace TeamViewer.Api.Test.UnitTests;

/// <summary>
/// Unit tests for company branding model serialization and deserialization. The fields shared by the
/// response and the update request are declared on a common base, so these tests pin the wire names
/// down for both sides.
/// </summary>
public class CompanyBrandingModelsTests
{
	private static readonly JsonSerializerOptions JsonOptions = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
		DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
	};

	[Fact]
	public void CompanyBranding_Deserialization_ReadsAllFields()
	{
		// Arrange
		const string json = """
			{
				"logo_url": "https://example.com/logo.png",
				"company_name": "Panoramic Data",
				"support_text": "Call us",
				"support_url": "https://example.com/support",
				"support_email": "support@example.com",
				"support_phone": "020 1234 5678",
				"primary_color": "#112233",
				"secondary_color": "#445566",
				"branding_enabled": true
			}
			""";

		// Act
		var branding = JsonSerializer.Deserialize<CompanyBranding>(json, JsonOptions);

		// Assert
		branding.Should().NotBeNull();
		branding!.LogoUrl.Should().Be("https://example.com/logo.png");
		branding.CompanyName.Should().Be("Panoramic Data");
		branding.SupportText.Should().Be("Call us");
		branding.SupportUrl.Should().Be("https://example.com/support");
		branding.SupportEmail.Should().Be("support@example.com");
		branding.SupportPhone.Should().Be("020 1234 5678");
		branding.PrimaryColor.Should().Be("#112233");
		branding.SecondaryColor.Should().Be("#445566");
		branding.BrandingEnabled.Should().BeTrue();
	}

	[Fact]
	public void CompanyBranding_Serialization_ProducesExpectedPropertyNames()
	{
		// Arrange
		var branding = new CompanyBranding
		{
			LogoUrl = "https://example.com/logo.png",
			CompanyName = "Panoramic Data",
			SupportText = "Call us",
			SupportUrl = "https://example.com/support",
			SupportEmail = "support@example.com",
			SupportPhone = "020 1234 5678",
			PrimaryColor = "#112233",
			SecondaryColor = "#445566",
			BrandingEnabled = true
		};

		// Act
		var json = JsonSerializer.Serialize(branding, JsonOptions);

		// Assert
		json.Should().Contain("\"logo_url\":\"https://example.com/logo.png\"");
		json.Should().Contain("\"company_name\":\"Panoramic Data\"");
		json.Should().Contain("\"support_text\":\"Call us\"");
		json.Should().Contain("\"support_url\":\"https://example.com/support\"");
		json.Should().Contain("\"support_email\":\"support@example.com\"");
		json.Should().Contain("\"support_phone\":\"020 1234 5678\"");
		json.Should().Contain("\"primary_color\":\"#112233\"");
		json.Should().Contain("\"secondary_color\":\"#445566\"");
		json.Should().Contain("\"branding_enabled\":true");
	}

	[Fact]
	public void UpdateCompanyBrandingRequest_FullUpdate_SerializesEveryField()
	{
		// Arrange
		var request = new UpdateCompanyBrandingRequest
		{
			CompanyName = "Panoramic Data",
			SupportText = "Call us",
			SupportUrl = "https://example.com/support",
			SupportEmail = "support@example.com",
			SupportPhone = "020 1234 5678",
			PrimaryColor = "#112233",
			SecondaryColor = "#445566",
			BrandingEnabled = true
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"company_name\":\"Panoramic Data\"");
		json.Should().Contain("\"support_text\":\"Call us\"");
		json.Should().Contain("\"support_url\":\"https://example.com/support\"");
		json.Should().Contain("\"support_email\":\"support@example.com\"");
		json.Should().Contain("\"support_phone\":\"020 1234 5678\"");
		json.Should().Contain("\"primary_color\":\"#112233\"");
		json.Should().Contain("\"secondary_color\":\"#445566\"");
		json.Should().Contain("\"branding_enabled\":true");
		json.Should().NotContain("\"logo_url\"");
	}

	[Fact]
	public void UpdateCompanyBrandingRequest_PartialUpdate_SerializesOnlyProvidedFields()
	{
		// Arrange
		var request = new UpdateCompanyBrandingRequest
		{
			CompanyName = "Panoramic Data"
		};

		// Act
		var json = JsonSerializer.Serialize(request, JsonOptions);

		// Assert
		json.Should().Contain("\"company_name\":\"Panoramic Data\"");
		json.Should().NotContain("\"support_text\"");
		json.Should().NotContain("\"primary_color\"");
		json.Should().NotContain("\"branding_enabled\"");
	}
}
