using UnityEngine;

public class SizeDown : Power
{
    public PaddleSizes sizes;

    protected override void DoPower(GameObject paddle)
    {
        if (sizes.currentSize <= 0)
        {
            return;
        }
        else
        {
            SpriteRenderer paddleSprite = paddle.GetComponent<SpriteRenderer>();
            paddleSprite.size = new Vector2(sizes.sizes[sizes.currentSize - 1], paddleSprite.size.y);
            sizes.currentSize -= 1;
            paddle.GetComponent<Paddle>().FindLimits();
        }
    }
}