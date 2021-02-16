using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class HighScoresList : ScriptableObject
{
    [System.NonSerialized] public List<HighScore> scoreList;
}