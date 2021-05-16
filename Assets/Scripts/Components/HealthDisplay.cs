using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    public IntValue publicHealth;
    public GameObject[] hearts;
    int localHealth;

    void SetHearts(int health)
    {
        for (int i = 0; i < 3; i++)
        {
            if (i + 1 > health)
            {
                hearts[i].SetActive(false);
            }
            else
            {
                hearts[i].SetActive(true);
            }
        }
        localHealth = health;
    }

    void Update()
    {
        if (localHealth != publicHealth.Value)
        {
            SetHearts(publicHealth.Value);
        }
    }
}