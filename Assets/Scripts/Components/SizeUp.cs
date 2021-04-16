using UnityEngine;

public class SizeUp : Power
{
    public PaddleSizes data;

    protected override void DoPower(GameObject paddle)
    {
        if (data.currentSize >= data.sizes.Length - 1)
        {
            return;
        }
        else
        {
            SpriteRenderer paddleSprite = paddle.GetComponent<SpriteRenderer>();
            paddleSprite.size = new Vector2(data.sizes[data.currentSize + 1], paddleSprite.size.y);
            data.currentSize += 1;
            paddle.GetComponent<Paddle>().FindLimits();
        }
    }
}