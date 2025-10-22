namespace Sim.Agent;

public class SimEmotion
{
    public string Feeling;
    public EmotionState Intensity;
    
    public SimEmotion(string feeling, EmotionState intensity)
    {
        Feeling = feeling;
        Intensity = intensity;
    }
    
}