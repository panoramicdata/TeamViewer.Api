# Copilot Instructions

## General Guidelines
- Never use "CancellationToken cancellationToken = default"; cancellation tokens should always be mandatory.
- For API methods with multiple optional query parameters, use a request object with the [Query] attribute instead of individual parameters.
- Never suppress failing unit tests with Assert.Skip or catch blocks. Tests should fail when there are real issues so they can be addressed. Only skip tests that genuinely require unavailable resources (like missing API permissions), not tests that fail due to code bugs or model mismatches.
