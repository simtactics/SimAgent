namespace Sim.Agent;

public class SimNeed(NeedType type, float value)
{
    public NeedType Type { get; } = type;
    /// <summary>
    /// Range: 0.0 (empty) to 100.0 (full)
    /// </summary>
    public float Value { get; private set; } = Math.Clamp(value, 0f, 100f);

    /// <summary>
    /// Updates the needs safely within range
    /// </summary>
    /// <param name="delta">1-100</param>
    public void Update(float delta)
    {
        Value = Math.Clamp(Value + delta, 0f, 100f);
    }

    /// <summary>
    /// Returns a ternary value representing if the need is satisfied.
    /// </summary>
    /// <returns></returns>
    public TriLogic IsSatisfied()
    {
        return Value switch
        {
            > 70f => TriLogic.True,
            < 70f => TriLogic.False,
            _ => TriLogic.Unknown // No null!
        };
    }
}