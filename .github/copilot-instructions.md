# Copilot Instructions

## General Guidelines
- Never use "CancellationToken cancellationToken = default"; cancellation tokens should always be mandatory.
- For API methods with multiple optional query parameters, use a request object with the [Query] attribute instead of individual parameters.
