using System.Text.Json.Serialization;

namespace Sim.Agent;

public record SIF(
	[property: JsonPropertyName("name")] string Name,
	[property: JsonPropertyName("needs")] ModifyNeeds Needs,
	[property: JsonPropertyName("script")] string Script,
	[property: JsonPropertyName("mesh")] string mesh
);

public record ModifyNeeds(
	[property: JsonPropertyName("bladder")] float Bladder,
	[property: JsonPropertyName("energy")] float Energy,
	[property: JsonPropertyName("fun")] float Fun,
	[property: JsonPropertyName("hunger")] float Hunger,
	[property: JsonPropertyName("hygiene")] float Hygiene,
	[property: JsonPropertyName("social")] float Social
);