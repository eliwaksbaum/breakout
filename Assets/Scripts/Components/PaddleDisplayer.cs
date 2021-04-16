using UnityEngine;
using TMPro;

public class PaddleDisplayer : MonoBehaviour
{
    public HighScoresList scores;
    public PaddlesData data;

    public TextMeshPro unlockText;
    public GameObject locked;

    public SpriteValue paddleSprite;

    SpriteRenderer paddleRenderer;
    bool unlocked;
    public bool Unlocked {get {return unlocked;}}
    int lastIndex;


    void Start()
    {
        if (scores.scoreList == null)
        {
            scores.scoreList = SaveDataHandler.GetScores();
        }
        paddleRenderer = GetComponent<SpriteRenderer>();
        Display(0);
    }

    void Display(int index)
    {
        if (index >= data.paddles.Length)
        {
            index = 0;
        }
        if (index < 0)
        {
            index = data.paddles.Length - 1;
        }
        lastIndex = index;

        PaddlesData.PaddleChoice currentPaddle = data.paddles[index];
        int highScore = scores.scoreList.Count == 0 ? 0 : scores.scoreList[0].score;
        unlocked = highScore >= currentPaddle.threshold;

        if (unlocked)
        {
            locked.SetActive(false);
            paddleRenderer.sprite = currentPaddle.sprite;
            paddleSprite.Value = currentPaddle.sprite;
        }
        else
        {
            unlockText.text = "Score " + currentPaddle.threshold.ToString() + " points to unlock";
            locked.SetActive(true);
        }
    }

    public void DisplayNext(int direction)
    {
        Display(lastIndex + direction);
    }
}