using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    public IntValue health;
    public GameObject[] hearts;

    void SetHearts()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i + 1 > health.Value)
            {
                hearts[i].SetActive(false);
            }
            else
            {
                hearts[i].SetActive(true);
            }
        }
    }

    void OnEnable()
    {
        health.ChangeEvent += SetHearts;
    }

    void OnDisable()
    {
        health.ChangeEvent -= SetHearts;
    }
}