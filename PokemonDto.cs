using System.Text.Json.Serialization;

public record PokemonDto(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("weight")] int Weight,
    [property: JsonPropertyName("height")] int Height,
    [property: JsonPropertyName("stats")] List<StatSlot> Stats,
    [property: JsonPropertyName("types")] List<TypeSlot> Types
);

public record StatSlot(
    [property: JsonPropertyName("base_stat")] int BaseStat,
    [property: JsonPropertyName("stat")] StatDetail Stat
);

public record StatDetail(
    [property: JsonPropertyName("name")] string Name
);

public record TypeSlot(
    [property: JsonPropertyName("type")] TypeDetail Type
);

public record TypeDetail(
    [property: JsonPropertyName("name")] string Name
);