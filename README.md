# DeepSigma.UnitTest

A lightweight C# test helper package and example project for standardizing xUnit-based unit test setup in .NET projects.

## Overview

`DeepSigma.UnitTest` packages the core pieces needed for an xUnit test project and demonstrates a clean, readable structure for common test patterns:

- standard `[Fact]` tests
- parameterized `[Theory]` tests with `InlineData`
- exception assertions with `Assert.Throws`
- data-driven tests using `MemberData` and CSV input
- xUnit runner configuration via `xunit.runner.json`

This repository is useful both as:

1. a small reusable package for xUnit-based test infrastructure, and
2. a reference implementation for organizing unit tests in modern .NET projects.

## What’s in the repository

```text
Dotnet.DeepSigma.UnitTest/
├── DeepSigma.UnitTest/
│   ├── DeepSigma.UnitTest.csproj
│   ├── DeepSigma.UnitTest.sln
│   ├── Examples.cs
│   ├── TestData.csv
│   └── xunit.runner.json
├── LICENSE
└── README.md
```

## Features

- Targets **.NET 10.0**
- Enables **nullable reference types**
- Enables **implicit usings**
- Generates XML documentation during build
- Configures the project to be **packable**
- Includes xUnit dependencies and test SDK wiring
- Shows several practical unit testing patterns in a single example file

## Tech stack

- **.NET**: `net10.0`
- **Test framework**: `xunit`
- **Test SDK**: `Microsoft.NET.Test.Sdk`
- **Runner support**:
  - `xunit.runner.console`
  - `xunit.runner.visualstudio`

## Included examples

The `Examples.cs` file demonstrates several useful patterns.

### 1. Basic test with `[Fact]`

```csharp
[Fact]
public void Add_SimpleValuesShouldCalculate()
{
    double expected = 2;
    double actual = Add(1, 1);

    Assert.Equal(expected, actual);
}
```

### 2. Parameterized test with `[Theory]` and `InlineData`

```csharp
[Theory]
[InlineData(1, 1, 2)]
[InlineData(0, 0, 0)]
[InlineData(0, 2, 2)]
public void Add_SimpleValuesShouldCalculate_Inline(double x, double y, double expected)
{
    double actual = Add(x, y);
    Assert.Equal(expected, actual);
}
```

### 3. Exception assertions

```csharp
[Fact]
public void LoadTextFile_InvalidNameShouldFail()
{
    Assert.Throws<FileNotFoundException>(() => LoadTextFile(""));
}
```

```csharp
[Fact]
public void LoadTextFile_ArgumentInvalidException()
{
    Assert.Throws<ArgumentException>("ArgExcept", () => LoadTextFile2(""));
}
```

### 4. CSV-backed data-driven tests

```csharp
[Theory]
[MemberData(nameof(GetTestDataFromCsv))]
public void MyCSVTest_ShouldBeFalse(string stringValue, int intValue, bool boolValue)
{
    Assert.True(stringValue.Length >= 1);
    Assert.True(intValue >= 0);
    Assert.True(boolValue == false);
}
```

## Project configuration

The project file is configured to:

- build as a packable library
- generate a package on build
- include test framework dependencies
- copy `TestData.csv` and `xunit.runner.json` to the output directory

That makes the repository a good starting point for teams that want a repeatable unit test project template.

## Getting started

### Prerequisites

- .NET 10 SDK or newer compatible preview/sdk matching `net10.0`

### Clone the repository

```bash
git clone https://github.com/DeepSigma-LLC/Dotnet.DeepSigma.UnitTest.git
cd Dotnet.DeepSigma.UnitTest/DeepSigma.UnitTest
```

### Restore dependencies

```bash
dotnet restore
```

### Build the project

```bash
dotnet build
```

### Run tests

```bash
dotnet test
```

## Using this project as a template

You can use this repository as a starting point for your own xUnit test project:

1. Clone the repository.
2. Rename the project and solution files for your domain.
3. Replace the sample tests in `Examples.cs` with your real tests.
4. Update or remove `TestData.csv` based on your data-driven test needs.
5. Adjust package metadata in `DeepSigma.UnitTest.csproj`.

## Using the package in another project

This repository is configured to generate a NuGet package on build. If you are publishing it to a package feed, reference the package from your test project and then add your own test classes on top of the provided setup.

A typical workflow would be:

```bash
dotnet pack -c Release
```

Then publish the resulting package to your preferred NuGet feed.

## Why this repository is useful

Many test projects start with the same repeated setup:

- xUnit package installation
- test SDK installation
- runner configuration
- sample patterns for facts, theories, and exception tests
- file-based test data plumbing

This repository consolidates that setup into a compact example, which can save time when bootstrapping new test projects.

## Notes

- The repository currently includes **sample tests** and helper methods intended to demonstrate structure and conventions.
- The examples are intentionally simple, which makes the project a strong baseline for internal templates, starter repos, or shared testing packages.
- Because the target framework is `net10.0`, consumers should ensure their SDK/tooling matches that target.

## License

This project is licensed under the **MIT License**. See `LICENSE` for details.
