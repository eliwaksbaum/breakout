using System;
using System.Collections.Generic;

[Serializable]
public struct HighScore
{
    public int score;
    public string name;

    public HighScore (int _score, string _name)
    {
        score = _score;
        name = _name;
    }
}