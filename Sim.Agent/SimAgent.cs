namespace Sim.Agent;

public class SimAgent
{
    List<SimNeed> Need;
    SimEmotion Emotion;

    /// <summary>
    /// Initialize basic sample needs for testing.
    /// </summary>
    public SimAgent()
    {
        Need = [];
        
        var rng =  new Random();
        var rngHunger = rng.Next(20, 100);
        var rngFun = rng.Next(20, 100);
        var rngEneregy =  rng.Next(20, 100);
        
        Need.Add(new SimNeed(Needs.Hunger, rngHunger));
        Need.Add(new SimNeed(Needs.Fun, rngFun));
        Need.Add(new SimNeed(Needs.Energy, rngEneregy));
    }
    
    /// <summary>
    /// Updates all needs and recalculates the emotion based on state
    /// </summary>
    public void Update()
    {
        foreach (var need in Need)
            need.Update(-5);
        
        EvaluateEmotions();
    }
    
    /// <summary>
    /// Determine emotion from needs using ternary logic
    /// </summary>
    void EvaluateEmotions()
    {
        var positive = 0;
        var negative = 0;
        
        foreach (var need in Need)
            switch (need.State)
            {
                case TernaryState.True:
                    positive++;
                    break;
                case TernaryState.False:
                    negative++;
                    break;
            }
        
        // Sample emotion logic based on tally
        if (negative >= 2)
            Emotion = new SimEmotion("Uncomfortable", EmotionState.Strong);
        else if (positive >= 2)
            Emotion = new SimEmotion("Happy", EmotionState.Strong);
        else
            Emotion = new SimEmotion("Neutral", EmotionState.Neutral);
    }
    
    /// <summary>
    /// Print status to console for testing
    /// </summary>
    public void PrintStatus()
    {
        Console.WriteLine("=== Sim Status ===");
        foreach (var need in Need)
            Console.WriteLine($"{need.Need}: {need.Value} ({need.State})");
        
        Console.WriteLine($"Emotions: {Emotion.Feeling} (Intensity: {Emotion.Intensity}){Environment.NewLine}");
    }
}