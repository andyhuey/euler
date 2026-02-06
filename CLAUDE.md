# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build and run

- Build a specific project: `dotnet build Euler7/Problems70to79/Problems70to79.csproj`
- Run the active project: `dotnet run --project Euler7/Problems70to79/Problems70to79.csproj`
- Older projects (Euler0–Euler6) target .NET Framework 4.5 (legacy `.csproj` format) and require `msbuild`: `msbuild Euler0/Projects1to10/Projects1to10.csproj`
- `Euler7` uses SDK-style `.csproj` targeting .NET 8.0 and supports `dotnet build`/`dotnet run`.
- F# project: `msbuild EulerFS0/EulerFS0/EulerFS0.fsproj`
- No automated tests or linting — each project is a console app that prints its answer. To run a different problem, edit `Program.cs` to call the desired problem class.
- `Euler7` is the currently-active project (its `Program.cs` runs `Problem76.Run()`).

## Architecture

- Collection of Project Euler (projecteuler.net) solutions organized into separate console apps, ~10 problems each.
- `Euler0` through `Euler7`: C# solutions. `EulerFS0`: F# reimplementations of select problems.
- Each project has a `Program.cs`/`Program.fs` entry point that instantiates one problem and calls its solution method. A `Stopwatch` is used in newer projects to time execution.

## Conventions

- Namespace matches the project's problem range (e.g., `Projects1to10`, `Problems70to79`).
- Problem classes are named `ProblemXX`. Older projects (Euler0–Euler6) use instance methods like `soln1()`, `soln2()`. Euler7 uses a static `Run()` method that handles its own instantiation and output.
- Multiple solution approaches for the same problem are kept as separate methods (e.g., `Soln1` through `Soln5`).
- Shared helpers are local to each project (e.g., `Utils.cs` in Euler7 with `gcd` and `getPrimes`). There is no shared utility library across projects.
