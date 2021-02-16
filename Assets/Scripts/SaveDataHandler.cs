using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class SaveDataHandler {
    //NUMBER OF SCORES TO DISPLAY
    static int length = 5;

    static string scorePath = Application.dataPath + "/HighScores.json";
    static string paddlePath = Application.dataPath + "/PaddleProgress.json";

    public static bool IsNewRecord(int score)
    {
        if (!File.Exists(scorePath))
        {
            return true;
        }
        else
        {
            int[] oldScores = ReadScores();
            return (score > oldScores[oldScores.Length - 1]);
        }
    }

    public static void AddNewScore(int score, string name)
    {
        HighScore newScore = new HighScore(score, name);
        List<HighScore> scores = new List<HighScore> (GetScores());
        scores.Add(newScore);
        scores.Sort((x,y) => y.score - x.score);
        if (scores.Count > length)
        {
            scores.RemoveAt(scores.Count - 1);
        }
        WriteScores(scores);
    }

    static void WriteScores(List<HighScore> scores)
    {
        StreamWriter sw;
        if (!File.Exists(scorePath))
        {
            sw = File.CreateText(scorePath);
        }
        else
        {
            sw = new StreamWriter(scorePath);
        }
        foreach (HighScore score in scores)
        {
            string json = JsonUtility.ToJson(score);
            sw.WriteLine(json);
        }
        sw.Close();
    }

    public static int[] ReadScores()
    {
        StreamReader sr = new StreamReader(scorePath);
        int[] oldScores = new int[5];
        int i = 0;
        string line;
        while((line = sr.ReadLine()) != null)
        {
            oldScores[i] = JsonUtility.FromJson<HighScore>(line).score;
            i += 1;
        }
        sr.Close();
        return oldScores;
    }

    public static List<HighScore> GetScores()
    {
        if (!File.Exists(scorePath))
        {
            return new List<HighScore>();
        }
        StreamReader sr = new StreamReader(scorePath);
        List<HighScore> scores = new List<HighScore>();
        string line;
        while((line = sr.ReadLine()) != null)
        {
            scores.Add(JsonUtility.FromJson<HighScore>(line));
        }
        sr.Close();
        return scores;
    }
}
