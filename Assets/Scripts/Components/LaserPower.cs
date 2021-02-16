using UnityEngine;

public class LaserPower : Power
{
    protected override void DoPower(GameObject paddle)
    {
        LaserShooter shooter = paddle.GetComponent<LaserShooter>();
        shooter.StartCoroutine(shooter.coroutine);
    }
}