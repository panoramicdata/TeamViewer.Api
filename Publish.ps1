#Requires -Version 7.0

<#
.SYNOPSIS
    Builds and publishes TeamViewer.Api packages to NuGet.

.DESCRIPTION
    This script performs the following steps:
    1. Validates that nuget-key.txt exists
    2. Ensures Git working directory is clean (porcelain)
    3. Cleans previous build artifacts
    4. Builds the solution in Release mode with symbols
    5. Runs unit tests (can be skipped with -SkipTests)
    6. Publishes packages to NuGet

.PARAMETER SkipTests
    Skip running unit tests before publishing.

.PARAMETER NuGetSource
    The NuGet source to publish to. Defaults to https://api.nuget.org/v3/index.json

.PARAMETER DryRun
    Performs all steps except the actual publish to NuGet.

.PARAMETER SkipGitCheck
    Skip the Git porcelain check (not recommended for production releases).

.EXAMPLE
    .\Publish.ps1
    Builds, tests, and publishes the packages.

.EXAMPLE
    .\Publish.ps1 -SkipTests
    Builds and publishes without running tests.

.EXAMPLE
    .\Publish.ps1 -DryRun
    Performs all steps except publishing to NuGet.

.EXAMPLE
    .\Publish.ps1 -SkipGitCheck
    Skips the Git working directory check.
#>

[CmdletBinding()]
param(
    [Parameter()]
    [switch]$SkipTests,

    [Parameter()]
    [string]$NuGetSource = "https://api.nuget.org/v3/index.json",

    [Parameter()]
    [switch]$DryRun,

    [Parameter()]
    [switch]$SkipGitCheck
)

$ErrorActionPreference = "Stop"
$ScriptDir = $PSScriptRoot

# ANSI color codes for better output
$ColorReset = "`e[0m"
$ColorGreen = "`e[32m"
$ColorYellow = "`e[33m"
$ColorRed = "`e[31m"
$ColorCyan = "`e[36m"

function Write-Step {
    param([string]$Message)
    Write-Information "${ColorCyan}==>${ColorReset} ${Message}" -InformationAction Continue
}

function Write-Success {
    param([string]$Message)
    Write-Information "${ColorGreen}✓${ColorReset} ${Message}" -InformationAction Continue
}

function Write-WarningMessage {
    param([string]$Message)
    Write-Information "${ColorYellow}⚠${ColorReset} ${Message}" -InformationAction Continue
}

function Write-ErrorMessage {
    param([string]$Message)
    Write-Information "${ColorRed}✗${ColorReset} ${Message}" -InformationAction Continue
}

# Function to check if a command exists
function Test-CommandExists {
    param([string]$Command)
    $null -ne (Get-Command $Command -ErrorAction SilentlyContinue)
}

# ============================================================================
# Step 1: Validate Prerequisites
# ============================================================================

Write-Step "Validating prerequisites..."

# Check for dotnet CLI
if (-not (Test-CommandExists "dotnet")) {
    Write-ErrorMessage "dotnet CLI not found. Please install .NET SDK."
    exit 1
}

$dotnetVersion = dotnet --version
Write-Success "Found dotnet CLI version: $dotnetVersion"

# Check for Git
if (-not (Test-CommandExists "git")) {
    Write-ErrorMessage "git CLI not found. Please install Git."
    exit 1
}

$gitVersion = git --version
Write-Success "Found $gitVersion"

# Check for nuget-key.txt
$NuGetKeyFile = Join-Path $ScriptDir "nuget-key.txt"
if (-not (Test-Path $NuGetKeyFile)) {
    Write-ErrorMessage "nuget-key.txt not found in solution root: $ScriptDir"
    Write-Information "Please create nuget-key.txt with your NuGet API key." -InformationAction Continue
    exit 1
}

$NuGetApiKey = (Get-Content $NuGetKeyFile -Raw).Trim()
if ([string]::IsNullOrWhiteSpace($NuGetApiKey)) {
    Write-ErrorMessage "nuget-key.txt is empty. Please add your NuGet API key."
    exit 1
}

Write-Success "Found nuget-key.txt with API key"

# ============================================================================
# Step 2: Check Git Working Directory is Clean
# ============================================================================

if (-not $SkipGitCheck) {
    Write-Step "Checking Git working directory status..."

    try {
        # Check if we're in a Git repository
        $isGitRepo = git rev-parse --is-inside-work-tree 2>$null

        if ($isGitRepo -eq "true") {
            # Get current branch
            $currentBranch = git rev-parse --abbrev-ref HEAD
            Write-Information "  Current branch: $currentBranch" -InformationAction Continue

            # Check for uncommitted changes
            $gitStatus = git status --porcelain

            if ($gitStatus) {
                Write-ErrorMessage "Git working directory is not clean. Uncommitted changes detected:"
                Write-Information "" -InformationAction Continue
                git status --short
                Write-Information "" -InformationAction Continue
                Write-Information "${ColorYellow}Please commit or stash your changes before publishing.${ColorReset}" -InformationAction Continue
                Write-Information "To skip this check, use the -SkipGitCheck parameter (not recommended)." -InformationAction Continue
                exit 1
            }

            # Check for unpushed commits
            $unpushedCommits = git log origin/$currentBranch..$currentBranch --oneline 2>$null
            if ($unpushedCommits) {
                Write-WarningMessage "You have unpushed commits:"
                Write-Information "" -InformationAction Continue
                Write-Information "${ColorYellow}$unpushedCommits${ColorReset}" -InformationAction Continue
                Write-Information "" -InformationAction Continue
                Write-Information "${ColorYellow}Consider pushing your changes before publishing.${ColorReset}" -InformationAction Continue

                # Prompt user to continue
                $response = Read-Host "Continue anyway? (y/N)"
                if ($response -ne 'y' -and $response -ne 'Y') {
                    Write-Information "${ColorYellow}Publishing cancelled.${ColorReset}" -InformationAction Continue
                    exit 0
                }
            }

            Write-Success "Git working directory is clean"
        } else {
            Write-WarningMessage "Not in a Git repository - skipping Git checks"
        }
    } catch {
        Write-WarningMessage "Could not check Git status: $_"
        Write-Information "Continuing anyway..." -InformationAction Continue
    }
} else {
    Write-WarningMessage "Skipping Git working directory check as requested"
}

# ============================================================================
# Step 3: Clean Previous Build Artifacts
# ============================================================================

Write-Step "Cleaning previous build artifacts..."

try {
    # Remove nupkgs directory if it exists
    $PackageDir = Join-Path $ScriptDir "nupkgs"
    if (Test-Path $PackageDir) {
        Remove-Item -Path $PackageDir -Recurse -Force
        Write-Information "  Removed previous nupkgs directory" -InformationAction Continue
    }

    # Run dotnet clean
    dotnet clean --configuration Release --verbosity quiet
    if ($LASTEXITCODE -eq 0) {
        Write-Success "Cleaned previous build artifacts"
    } else {
        Write-WarningMessage "Clean command returned non-zero exit code"
    }
} catch {
    Write-WarningMessage "Failed to clean: $_"
    Write-Information "Continuing anyway..." -InformationAction Continue
}

# ============================================================================
# Step 4: Restore Dependencies
# ============================================================================

Write-Step "Restoring dependencies..."

try {
    dotnet restore
    if ($LASTEXITCODE -eq 0) {
        Write-Success "Dependencies restored"
    } else {
        Write-ErrorMessage "Restore failed"
        exit 1
    }
} catch {
    Write-ErrorMessage "Failed to restore: $_"
    exit 1
}

# ============================================================================
# Step 5: Build Solution
# ============================================================================

Write-Step "Building solution in Release mode..."

try {
    dotnet build --configuration Release --no-restore
    if ($LASTEXITCODE -eq 0) {
        Write-Success "Build completed successfully"
    } else {
        Write-ErrorMessage "Build failed"
        exit 1
    }
} catch {
    Write-ErrorMessage "Failed to build: $_"
    exit 1
}

# ============================================================================
# Step 6: Run Tests
# ============================================================================

if (-not $SkipTests) {
    Write-Step "Running unit tests..."

    try {
        dotnet test --configuration Release --no-build --verbosity normal --logger "console;verbosity=normal"
        if ($LASTEXITCODE -eq 0) {
            Write-Success "All tests passed"
        } else {
            Write-ErrorMessage "Tests failed"
            Write-Information "" -InformationAction Continue
            Write-Information "${ColorYellow}To skip tests and publish anyway, run with -SkipTests parameter${ColorReset}" -InformationAction Continue
            exit 1
        }
    } catch {
        Write-ErrorMessage "Failed to run tests: $_"
        exit 1
    }
} else {
    Write-WarningMessage "Skipping unit tests as requested"
}

# ============================================================================
# Step 7: Pack NuGet Packages
# ============================================================================

Write-Step "Creating NuGet packages..."

try {
    $PackageDir = Join-Path $ScriptDir "nupkgs"
    dotnet pack --configuration Release --no-build --include-symbols -p:SymbolPackageFormat=snupkg --output $PackageDir
    if ($LASTEXITCODE -eq 0) {
        Write-Success "Packages created successfully"
    } else {
        Write-ErrorMessage "Pack failed"
        exit 1
    }
} catch {
    Write-ErrorMessage "Failed to pack: $_"
    exit 1
}

# ============================================================================
# Step 8: List Created Packages
# ============================================================================

$PackageDir = Join-Path $ScriptDir "nupkgs"
$NuGetPackages = Get-ChildItem -Path $PackageDir -Filter "*.nupkg" -Exclude "*.symbols.nupkg"
$SymbolPackages = Get-ChildItem -Path $PackageDir -Filter "*.snupkg"

Write-Information "" -InformationAction Continue
Write-Step "Created packages:"
foreach ($package in $NuGetPackages) {
    Write-Information "  📦 $($package.Name)" -InformationAction Continue
}
foreach ($package in $SymbolPackages) {
    Write-Information "  🔍 $($package.Name)" -InformationAction Continue
}
Write-Information "" -InformationAction Continue

# ============================================================================
# Step 9: Publish to NuGet
# ============================================================================

if ($DryRun) {
    Write-WarningMessage "DRY RUN MODE: Skipping publish to NuGet"
    Write-Information "" -InformationAction Continue
    Write-Information "Packages are ready in: $PackageDir" -InformationAction Continue
    Write-Information "To publish, run without -DryRun parameter" -InformationAction Continue
    exit 0
}

Write-Step "Publishing packages to NuGet ($NuGetSource)..."
Write-Information "" -InformationAction Continue

$publishSuccess = $true

foreach ($package in $NuGetPackages) {
    Write-Information "${ColorCyan}Publishing: $($package.Name)${ColorReset}" -InformationAction Continue

    try {
        dotnet nuget push $package.FullName `
            --api-key $NuGetApiKey `
            --source $NuGetSource `
            --skip-duplicate

        if ($LASTEXITCODE -eq 0) {
            Write-Success "Published: $($package.Name)"
        } else {
            Write-ErrorMessage "Failed to publish: $($package.Name)"
            $publishSuccess = $false
        }
    } catch {
        Write-ErrorMessage "Error publishing $($package.Name): $_"
        $publishSuccess = $false
    }

    Write-Information "" -InformationAction Continue
}

# ============================================================================
# Summary
# ============================================================================

Write-Information "" -InformationAction Continue
Write-Information "${ColorCyan}============================================${ColorReset}" -InformationAction Continue
if ($publishSuccess) {
    Write-Success "Publish completed successfully!"
    Write-Information "" -InformationAction Continue
    Write-Information "${ColorGreen}Your packages have been published to NuGet.${ColorReset}" -InformationAction Continue
    Write-Information "It may take a few minutes for them to appear in search results." -InformationAction Continue
} else {
    Write-ErrorMessage "Publish completed with errors"
    Write-Information "" -InformationAction Continue
    Write-Information "${ColorYellow}Some packages failed to publish. Please review the errors above.${ColorReset}" -InformationAction Continue
    exit 1
}
Write-Information "${ColorCyan}============================================${ColorReset}" -InformationAction Continue
Write-Information "" -InformationAction Continue
