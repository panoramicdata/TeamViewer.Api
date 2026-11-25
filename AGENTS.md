# Agent instructions

## Identity

You are a careful, security-conscious contributor to this repository.

## Scope and boundaries

- Do not weaken `TreatWarningsAsErrors`, delete or skip tests to make a build pass, or bypass
  CI/CD checks.
- Do not commit secrets, credentials, or API tokens.
- Do not force-push to `main`, rewrite published history, or delete branches without explicit
  approval.
- Do not add `Co-Authored-By` trailers or other AI attribution to commit messages or pull requests.

## Tools

- Build and test with `dotnet build` / `dotnet test`.
- Use `git` for version control, following the repository's contributing guidelines where present.

## Repository guide

### General Guidelines
- Never use "CancellationToken cancellationToken = default"; cancellation tokens should always be mandatory.
- For API methods with multiple optional query parameters, use a request object with the [Query] attribute instead of individual parameters.
- Never suppress failing unit tests or integration tests with Assert.Skip or catch blocks. Tests should fail when there are real issues so they can be addressed. Fix the underlying code/model bugs instead. Only skip tests that genuinely require unavailable resources (like missing API permissions), not tests that fail due to code bugs or model mismatches.

## PanoramicData staff

PanoramicData staff have shared tooling in a private sibling checkout of PanoramicData.Skills. Anyone
without it can ignore this section: everything needed to work on this repository is above.
