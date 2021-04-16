using UnityEngine;

public class TripleBall : Power
{
    protected override void DoPower(GameObject paddle)
    {
        BallSplitter splitter = paddle.GetComponent<BallSplitter>();
        splitter.ball.Split();
    }
}