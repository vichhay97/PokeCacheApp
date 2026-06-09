# Pokémon In-Memory Cache Service

A lightweight, high-performance .NET 9 console application demonstrating asynchronous external API integration, strongly-typed JSON serialization, and efficient in-memory caching patterns.

## Architecture & Core Features

This micro-utility is designed to prioritize performance and data integrity by treating network calls as expensive operations. 

* **In-Memory Caching:** Utilizes a `Dictionary` mapped with `StringComparer.OrdinalIgnoreCase` to serve repeated data instantly, eliminating redundant HTTP calls and bypassing casing issues.
* **Defensive I/O:** Leverages `HttpClient` gracefully, catching specific network exceptions (e.g., `404 Not Found`) to prevent application crashes on invalid user input.
* **Data Transformation:** Parses complex, nested JSON arrays from the PokeAPI and uses C# LINQ to aggregate business metrics (e.g., converting decimeters/hectograms to standard metric units, calculating total battle stats).

## Tech Stack

* **Framework:** .NET 9.0
* **Language:** C# 13
* **Libraries:** Native `System.Text.Json` and `System.Net.Http` (Zero external NuGet dependencies)

## Getting Started

### Prerequisites
Ensure you have the [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) installed on your machine.

### Installation & Execution
1. Clone the repository:
   ```bash
   git clone [https://github.com/YOUR_GITHUB_USERNAME/PokeCacheApp.git](https://github.com/YOUR_GITHUB_USERNAME/PokeCacheApp.git)
2. Navigate to the project directory:
   ```bash
   cd PokeCacheApp
3. Run the application:
   ```bash
   dotnet run