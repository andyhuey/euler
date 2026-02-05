# Copilot instructions for this repository

## Build, test, lint
- Build a specific solution: `msbuild Euler0\\Euler0.sln` (repeat for Euler1..Euler7, or EulerFS0)
- Build a specific project: `msbuild Euler0\\Projects1to10\\Projects1to10.csproj`
- Run a single “test”/problem: update the `Program.cs` in the target project to instantiate the desired `ProblemXX` and call its `soln*` method, then run the built EXE from `bin\\Debug\\`.
- F# project: `msbuild EulerFS0\\EulerFS0.sln` (entry point is `EulerFS0\\EulerFS0\\Program.fs`)
- No automated test or lint tooling is configured in this repo.

## High-level architecture
- This repo is a collection of separate Project Euler solution apps, grouped by problem ranges.
  - `Euler0` through `Euler7` are C# solutions in individual Visual Studio solutions, each containing one console app project covering ~10 problems.
  - `EulerFS0` is an F# console app with its own solution and project.
- `Euler7` is the currently-active solution (its `Program.cs` runs `Problem76.Run()`).
- Each project has a `Program.cs` (or `Program.fs`) entry point that picks a single problem to run and prints its answer.
- Individual problems live in `ProblemXX.cs` (or `.fs`) files and expose one or more `soln*` methods.

## Key conventions
- Namespace matches the problem range (e.g., `Projects1to10`, `Problems20to29`, `Problems70to79`).
- C# problem classes are named `ProblemXX`, typically with `soln1()` (and sometimes `soln2`, etc.) methods.
- For C# projects, switching which problem runs is done by editing the `Program.cs` in that project.
- Some shared helpers exist only within a specific range (e.g., `Euler7\\Problems70to79\\Utils.cs`).
