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
- Make cancellation tokens mandatory rather than `CancellationToken cancellationToken = default`; ask the maintainer before making an exception.
- For API methods with multiple optional query parameters, use a request object with the [Query] attribute instead of individual parameters.
- Do not suppress failing unit or integration tests with `Assert.Skip` or catch blocks.
- Tests should fail when there are real issues, so they can be addressed.
- Fix the underlying code or model bugs instead.
- Skip only tests that genuinely require unavailable resources, such as missing API permissions.
- Do not skip tests that fail because of code bugs or model mismatches.

## PanoramicData staff

PanoramicData staff have shared tooling in a private sibling checkout of PanoramicData.Skills. Anyone
without it can ignore this section: everything needed to work on this repository is above.
