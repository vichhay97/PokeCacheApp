using var httpClient = new HttpClient();
var CacheService = new CacheService(httpClient);

Console.Clear();
Console.WriteLine("=== POKÉMON IN-MEMORY CACHE SERVICE ===");
Console.WriteLine("Type a Pokémon to fetch its profile. Type 'exit' to quit.");

while (true)
{
    Console.Write("\nEnter Pokémon name: ");
    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input)) continue;
    if (input.Trim().ToLower() == "exit") break;

    var (pokemon, isCached) = await CacheService.GetPokemonAsync(input);

    if (pokemon == null)
    {
        Console.WriteLine($"[ERROR] Pokémon '{input}'¨not found.");
        continue;
    }

    double weightKg = pokemon.Weight / 10.0;
    double heightMeters = pokemon.Height / 10.0;
    int totalStats = pokemon.Stats.Sum(s => s.BaseStat);
    string typesList = string.Join(", ", pokemon.Types.Select(t => t.Type.Name.ToUpper()));
    string statusMsg = isCached ? "In-Memory Cache" : "PokeAPI Network Call";

    Console.WriteLine("\n==================================================");
    Console.WriteLine($"POKÉMON PROFILE: {pokemon.Name.ToUpper()} (ID: {pokemon.Id})");
    Console.WriteLine("==================================================");
    Console.WriteLine($"Types:        {typesList}");
    Console.WriteLine($"Physical:     {heightMeters} m | {weightKg} kg");
    Console.WriteLine($"Battle Power: {totalStats} Total Base Stats");
    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine($"[STATUS] Source: {statusMsg}");
    Console.WriteLine("==================================================");
}