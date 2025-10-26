var sim = new SimAgent();
const int ticks = 5;

sim.PrintStatus();

// Run for 5 ticks
for (var tick = 0; tick < ticks; tick++)
{
    Console.WriteLine($"Tick {tick}");
    sim.ModifyNeed(NeedType.Hunger, -20f);
    sim.ModifyNeed(NeedType.Energy, -20f);
    sim.ModifyNeed(NeedType.Fun, -20f);
    sim.PrintStatus();
}

sim.ModifyNeed(NeedType.Hunger, 50f);
sim.ModifyNeed(NeedType.Energy, 50f);
sim.PrintStatus();