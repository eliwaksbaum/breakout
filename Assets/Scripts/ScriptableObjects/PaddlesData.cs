using UnityEngine;

[CreateAssetMenu]
public class PaddlesData : ScriptableObject
{
    [System.Serializable]
    public struct PaddleChoice
    {
        public int threshold;
        public Sprite sprite;
    }

    public PaddleChoice[] paddles;
}