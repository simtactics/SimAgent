var sim = new SimAgent();
const int ticks = 5; // One sim minute is 30 ticks
var totalTicks = 0;
var lastTick = 0;

sim.PrintStatus();

// Run for 5 ticks
for (var tick = 0; tick < ticks; tick++)
{
    // Average day
    sim.ModifyNeed(NeedType.Hunger, -20f);
    sim.ModifyNeed(NeedType.Energy, -20f);
    sim.ModifyNeed(NeedType.Fun, -20f);
    
    totalTicks += tick;
    lastTick = tick + 1;
    Console.WriteLine($"Tick: {tick}");
    sim.PrintStatus();
}

// Eat and sleep
sim.ModifyNeed(NeedType.Hunger, 50f);
sim.ModifyNeed(NeedType.Energy, 50f);

Console.WriteLine($"Tick: {lastTick}");
sim.PrintStatus();
Console.WriteLine($"Total Ticks: {totalTicks}");