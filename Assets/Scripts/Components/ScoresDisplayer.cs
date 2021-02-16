using UnityEngine;

public class ScoresDisplayer : MonoBehaviour
{
    public HighScoresList highScores;
    public GameObject scoreLines;
    public GameObject scoreLinePrefab;

    void Start()
    {
        if (highScores.scoreList == null)
        {
            highScores.scoreList = SaveDataHandler.GetScores();
        }
        for (int i = 0; i < highScores.scoreList.Count; i++)
        {
            GameObject number = scoreLines.transform.GetChild(i).gameObject;
            Vector3 position = number.transform.position;
            GameObject line = Instantiate(scoreLinePrefab, new Vector3 (position.x - .2f, position.y + .25f, 0), Quaternion.identity);
            line.GetComponent<ScoreLine>().Format(highScores.scoreList[i].name, highScores.scoreList[i].score);
        }
    }
}