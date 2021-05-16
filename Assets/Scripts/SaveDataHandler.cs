using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveDataHandler {
    //NUMBER OF SCORES TO DISPLAY
    static int length = 5;

    static string scorePath = Application.persistentDataPath + "/breakout.dat";

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
        BinaryFormatter bf = new BinaryFormatter();
        FileStream saveFile;
        saveFile = File.Open(scorePath, FileMode.OpenOrCreate);
        bf.Serialize(saveFile, scores);
        saveFile.Close();
    }

    static int[] ReadScores()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream saveFile = File.Open(scorePath, FileMode.Open);
        List<HighScore> highScores = (List<HighScore>)bf.Deserialize(saveFile);
        saveFile.Close();

        int[] oldScores = new int[length];
        for (int i = 0; i < highScores.Count; i++)
        {
            oldScores[i] = highScores[i].score;
        }
        return oldScores;
    }

    public static List<HighScore> GetScores()
    {
        if (!File.Exists(scorePath))
        {
            return new List<HighScore>();
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream saveFile = File.Open(scorePath, FileMode.Open);
            List<HighScore> scores = (List<HighScore>)bf.Deserialize(saveFile);
            saveFile.Close();
            return scores;
        }
    }
}
