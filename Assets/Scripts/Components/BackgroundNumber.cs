using UnityEngine;

public class BackgroundNumber : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Release"))
        {
            Destroy(gameObject, .1f);
        }
    }
}
