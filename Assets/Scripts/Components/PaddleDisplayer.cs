using UnityEngine;
using TMPro;

public class PaddleDisplayer : MonoBehaviour
{
    public HighScoresList scores;
    public PaddlesData data;

    public TextMeshPro unlockText;
    public GameObject locked;

    public SpriteValue paddleSprite;

    public GameObject right;
    public GameObject left;

    SpriteRenderer paddleRenderer;
    bool unlocked;
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

    public void Display(int index)
    {
        if (index >= data.paddles.Length) {index = 0;}
        if (index < 0) {index = data.paddles.Length - 1;}
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

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouse3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouse2 = new Vector2 (mouse3.x, mouse3.y);
            RaycastHit2D mouseHit = Physics2D.CircleCast(mouse2, 1, new Vector2(1f, 1f));
            if (mouseHit.collider != null)
            {
                if (mouseHit.collider.gameObject == left)
                {
                    Display(lastIndex - 1);
                }
                if (mouseHit.collider.gameObject == right)
                {
                    Display(lastIndex + 1);
                }
            }
        }
    }
}