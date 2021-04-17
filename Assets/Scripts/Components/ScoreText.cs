using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public IntValue score;
    TextMeshPro scoreText;

    void Start()
    {
        scoreText = GetComponent<TextMeshPro>();
        scoreText.text = "Score: " + score.Value.ToString();
    }

    void Update()
    {
        scoreText.text = "Score: " + score.Value.ToString();
    }
}