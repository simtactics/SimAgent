using System.Text.Json;

var sim = new SimAgent();
const int ticks = 5; // One sim minute is 30 ticks
var totalTicks = 0;

var bedFile = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "bed.json"));
var fridgeFile = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "fridge.json"));
var bed = JsonSerializer.Deserialize<SIF>(bedFile);
var fridge = JsonSerializer.Deserialize<SIF>(fridgeFile);

// Run for 5 ticks
for (var tick = 0; tick < ticks; tick++)
{
    // Average day
    sim.ModifyNeed(NeedType.Hunger, -20f);
    sim.ModifyNeed(NeedType.Energy, -20f);
    sim.ModifyNeed(NeedType.Fun, -20f);
    
    totalTicks += tick;
    sim.PrintStatus();
}

// Eat and sleep
sim.ModifyNeed(NeedType.Hunger, bed.Needs.Energy);
sim.ModifyNeed(NeedType.Energy, fridge.Needs.Hunger);

sim.PrintStatus();
Console.WriteLine($"Total Ticks: {totalTicks}");