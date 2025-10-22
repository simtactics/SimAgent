var sim = new SimAgent();
const int ticks = 5;

// Run for 5 ticks
for (var tick = 0; tick < ticks; tick++)
{
    Console.WriteLine($"Tick {tick}");
    sim.Update();
    sim.PrintStatus();
}
