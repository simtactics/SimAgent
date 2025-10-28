using System.Text.Json.Serialization;

namespace Sim.Agent;

public record SIF(
	[property: JsonPropertyName("name")]
	string Name,
	[property: JsonPropertyName("needs")]
	ModifyNeeds Needs,
	[property: JsonPropertyName("script")]
	string Script,
	[property: JsonPropertyName("sprites")]
	Sprites Sprites
);

public record ModifyNeeds(
	[property: JsonPropertyName("bladder")]
	float Bladder,
	[property: JsonPropertyName("energy")]
	float Energy,
	[property: JsonPropertyName("fun")]
	float Fun,
	[property: JsonPropertyName("hunger")]
	float Hunger,
	[property: JsonPropertyName("hygiene")]
	float Hygiene,
	[property: JsonPropertyName("social")]
	float Social
);

public record Sprites(
	[property: JsonPropertyName("east")]
	string East,
	[property: JsonPropertyName("north")]
	string North,
	[property: JsonPropertyName("south")]
	string South,
	[property: JsonPropertyName("west")]
	string West
);