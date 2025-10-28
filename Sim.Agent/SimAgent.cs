namespace Sim.Agent;

public class SimAgent
{
    private readonly Dictionary<NeedType, SimNeed> _needs = new();
    private EmotionType CurEmotion { get; set; } = EmotionType.Neutral;
    
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
    /// Returns a state describing the Sim's emotions based on their satisfactory levels.
    /// </summary>
    private TriLogic ComputeHappiness()
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
                // This is why I love this logic pattern
                case TriLogic.Unknown:
                default:
                    continue;
            }
        }

        if (satisfied < unsatisfied) return TriLogic.True;
        return satisfied > unsatisfied ? TriLogic.False : TriLogic.Unknown;
    }

    /// <summary>
    /// Evaluates which emotion a Sim should be feeling based on their needs.
    /// </summary>
    private void EvaluateEmotions()
    {
        var isHappy = ComputeHappiness();
        var energy = _needs[NeedType.Energy];
        var social = _needs[NeedType.Social];
        var fun =  _needs[NeedType.Fun];
        
        if (energy.Value < 25) CurEmotion = EmotionType.Tired;
        else switch (isHappy)
        {
            case TriLogic.True when fun.IsSatisfied() == TriLogic.True:
                CurEmotion = EmotionType.Playful;
                break;
            case TriLogic.True:
                CurEmotion = EmotionType.Happy;
                break;
            default:
            {
                CurEmotion = social.IsSatisfied() == TriLogic.False ? EmotionType.Lonely : EmotionType.Neutral;
                break;
            }
        }
    }
    
    /// <summary>
    /// Print a snapshot of the current the needs and emotion for debugging.
    /// </summary>
    public void PrintStatus()
    {
        Console.WriteLine($"=== Status ==={Environment.NewLine}Emotion: {CurEmotion}");
        foreach (var kvp in _needs)
            Console.WriteLine($"{kvp.Key}: {kvp.Value.Value:F1} {kvp.Value.IsSatisfied()}");
        Console.WriteLine();
    }
}