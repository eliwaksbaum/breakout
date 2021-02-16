using UnityEngine;

public class TripleBall : Power
{
    protected override void DoPower(GameObject paddle)
    {
        BallSpliter splitter = paddle.GetComponent<BallSpliter>();
        splitter.ball.Split();
    }
}