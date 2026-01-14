# Contributing to TeamViewer.Api

Thank you for your interest in contributing to TeamViewer.Api!

## How to Contribute

### Reporting Issues

- Use the GitHub issue tracker to report bugs
- Describe the issue clearly, including steps to reproduce
- Include the .NET version and TeamViewer.Api version

### Pull Requests

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Make your changes
4. Ensure all tests pass (`dotnet test`)
5. Commit your changes (`git commit -m 'Add amazing feature'`)
6. Push to the branch (`git push origin feature/amazing-feature`)
7. Open a Pull Request

### Coding Standards

- Follow the existing code style (see `.editorconfig`)
- Use nullable reference types
- Add XML documentation for public APIs
- Write unit tests for new functionality
- Ensure all tests pass before submitting

### Commit Messages

- Use clear, descriptive commit messages
- Start with a verb (Add, Fix, Update, Remove, etc.)
- Keep the first line under 72 characters

### Testing

- Write unit tests for handlers and client logic
- Write integration tests for API endpoints
- Integration tests should gracefully skip when permissions are unavailable

## Development Setup

1. Clone the repository
2. Open `TeamViewer.Api.slnx` in Visual Studio 2022 or later
3. Copy `secrets.example.json` to `secrets.json` and add your Script Token
4. Build and run tests

## Questions?

Feel free to open an issue for any questions about contributing.
