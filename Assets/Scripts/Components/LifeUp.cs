using UnityEngine;

public class LifeUp : Power
{
    public IntValue health;

    protected override void DoPower(GameObject paddle)
    {
        if (health.Value < 3)
        {
            health.addValue(1);
        }
    }
}