using TMPro;
using UnityEngine;

public class TextButton : MonoBehaviour
{
    TextMeshPro text;

    void Start()
    {
        text = GetComponent<TextMeshPro>();
    }

    void OnMouseEnter()
    {
        text.color = new Color(1, 1, .6f, 1);
    }

    void OnMouseExit()
    {
        text.color = Color.white;
    }
}