namespace Sim.Agent;

public class SimNeed(NeedType type, float value)
{
    public NeedType Type { get; } = type;
    public float Value { get; private set; } = Math.Clamp(value, 0f, 100f);

    public void Update(float delta)
    {
        Value = Math.Clamp(Value + delta, 0f, 100f);
    }

    public TriLogic IsSatisfied()
    {
        return Value switch
        {
            > 70f => TriLogic.True,
            < 70f => TriLogic.False,
            _ => TriLogic.Unknown
        };
    }
}