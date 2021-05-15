using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NameInput : MonoBehaviour
{
    TMP_InputField nameField;
    public IntValue score;

    void Start()
    {
        nameField = GetComponent<TMP_InputField>();
        nameField.Select();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (nameField.text.Length > 0)
            {
                SaveDataHandler.AddNewScore(score.Value, nameField.text.ToUpper());
                SceneManager.LoadScene("HighScores");
            }
            else
            {
                nameField.ActivateInputField();
            }
        }
    }
}
