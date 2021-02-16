using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    TextMeshPro scoreText;
    public IntValue score;

    void Awake()
    {
        scoreText = GetComponent<TextMeshPro>();
        scoreText.text = "Your Score: " + score.Value.ToString();
        // scoreText.ForceMeshUpdate();

        // float textWidth = scoreText.textBounds.extents.x;
        // float fullWidth = scoreText.GetComponent<RectTransform>().rect.width;

        // scoreText.transform.position = new Vector3(fullWidth/2 - textWidth, scoreText.transform.position.y, 0);
    }
}