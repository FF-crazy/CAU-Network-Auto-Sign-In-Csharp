# CAU Network Auto Sign-In (C#)

This project provides a C# console application that mirrors the behaviour of the Kotlin version for automatically logging into the CAU network.

## Usage

1. Set the environment variables `CAU_USERNAME` and `CAU_PASSWORD` or supply them via command line options.
2. Build the project with the .NET SDK.
3. Run the application:
   ```
   dotnet run --project AutoSignIn.csproj -- --url=https://example.com/login
   ```
   Optional arguments:
   * `--username=<name>` – overrides `CAU_USERNAME`
   * `--password=<pass>` – overrides `CAU_PASSWORD`
   * `--url=<endpoint>` – sign-in endpoint (default `https://example.com/login`)

The actual sign-in URL must be replaced with the real CAU network portal endpoint.
