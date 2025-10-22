namespace Sim.Agent;

public class SimNeed
{
    public Needs Need;
    public float Value;
    public TernaryState State;

    /// <summary>
    /// Initializes a Sim's need and current state.
    /// </summary>
    /// <param name="need">Name of the need</param>
    /// <param name="value">Value from 0 to 100</param>
    public SimNeed(Needs need, float value)
    {
        Need = need;
        Value = value;
        State = DetermineState();
    }
    
    /// <summary>
    /// Determines the ternary state from numeric values and
    /// influences the emotional state.
    /// </summary>
    /// <returns></returns>
    TernaryState DetermineState()
    {
        return Value switch
        {
            <20 => TernaryState.False,
            >60 => TernaryState.True,
            _ => TernaryState.Unknown
        };
    }

    /// <summary>
    /// Updates and recalculates the state
    /// </summary>
    /// <param name="dt">Delta value</param>
    public void Update(float dt)
    {
        Value += dt;
        State = DetermineState();
    }

}
