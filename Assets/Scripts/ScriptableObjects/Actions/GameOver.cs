using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : Callable
{
    public IntValue score;
    public AudioClip backClip;
    public AudioClip newHSClip;

    public override void Call()
    {
        if (SaveDataHandler.IsNewRecord(score.Value))
        {
            Sounds.PlayAudio(newHSClip);
            SceneManager.LoadScene("EnterNewScore");
        }
        else
        {
            Sounds.PlayAudio(backClip);
            SceneManager.LoadScene("Start");
        }
    }
}