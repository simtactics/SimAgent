namespace Sim.Agent;

public class SimAgent
{
    private readonly Dictionary<NeedType, SimNeed> _needs = new();
    public EmotionType CurEmotion { get; set; } = EmotionType.Neutral;
    
    /// <summary>
    /// Initialize basic sample needs for testing.
    /// </summary>
    public SimAgent()
    {
        foreach (var needType in Enum.GetValues(typeof(NeedType)).Cast<NeedType>())
        {
            _needs[needType] = new SimNeed(needType, 100f);
        }
    }

    /// <summary>
    /// Updates all needs and recalculates the emotion based on state
    /// </summary>
    public void ModifyNeed(NeedType type, float delta)
    {
        if (!_needs.TryGetValue(type, out var need)) return;
        need.Update(delta);
        EvaluateEmotions();
       
    }
    
    /// <summary>
    /// Determine emotion from needs using ternary logic
    /// </summary>
    TriLogic ComputeHappiness()
    {
        var satisfied = 0;
        var unsatisfied = 0;

        foreach (var state in _needs.Values.Select(need => need.IsSatisfied()))
        {
            switch (state)
            {
                case TriLogic.True:
                    satisfied++;
                    break;
                case TriLogic.False:
                    unsatisfied++;
                    break;
            }
        }

        if (satisfied < unsatisfied) return TriLogic.True;
        return satisfied > unsatisfied ? TriLogic.False : TriLogic.Unknown;
    }

    void EvaluateEmotions()
    {
        var isHappy = ComputeHappiness();
        var energy = _needs[NeedType.Energy];
        var social = _needs[NeedType.Social];
        var fun =  _needs[NeedType.Fun];
        
        if (energy.Value < 25) CurEmotion = EmotionType.Tired;
        else if (isHappy == TriLogic.True && fun.IsSatisfied() == TriLogic.True) CurEmotion = EmotionType.Playful;
        else if (isHappy == TriLogic.True) CurEmotion = EmotionType.Happy;
        else if (social.IsSatisfied() ==   TriLogic.False) CurEmotion = EmotionType.Lonely;
        else if (isHappy == TriLogic.False) CurEmotion = EmotionType.Sad;
        else CurEmotion = EmotionType.Neutral;
    }
    
    /// <summary>
    /// Print status to console for testing
    /// </summary>
    public void PrintStatus()
    {
        Console.WriteLine($"=== Status ==={Environment.NewLine}Emotion: {CurEmotion}");
        foreach (var kvp in _needs)
            Console.WriteLine($"{kvp.Key}: {kvp.Value.Value:F1} {kvp.Value.IsSatisfied()}");
        Console.WriteLine();
    }
}