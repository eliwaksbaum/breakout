using UnityEngine.SceneManagement;

public class GameOver : Callable
{
    public IntValue score;
    //public HighScores hsValue;

    public override void Call()
    {
        if (SaveDataHandler.IsNewRecord(score.Value))
        {
            //hsValue.scoreList = HighScoresHandler.GetScores();
            SceneManager.LoadScene("EnterNewScore");
        }
        else
        {
            SceneManager.LoadScene("Start");
        }
    }
}