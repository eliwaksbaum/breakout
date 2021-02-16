using UnityEngine;
using TMPro;

public class ScoreLine : MonoBehaviour
{
    public TextMeshPro nameText;
    public TextMeshPro scoreText;
    public GameObject dots;

    public void Format(string name, int score)
    {
        nameText.text = name;
        nameText.ForceMeshUpdate();
        float nameWidth = 2 * nameText.textBounds.extents.x;
        float dotsX = transform.position.x + nameWidth + .6f;
        dots.transform.position = new Vector3(dotsX, dots.transform.position.y, 0);

        scoreText.text = score.ToString();
        scoreText.ForceMeshUpdate();
        float scoreWidth = 2 * scoreText.textBounds.extents.x;
        float dotsEnd = scoreText.transform.position.x - (scoreWidth + .4f);
        SpriteRenderer dotSprite = dots.GetComponent<SpriteRenderer>();
        dotSprite.size = new Vector2(dotsEnd - dotsX, dotSprite.size.y);
    }
}