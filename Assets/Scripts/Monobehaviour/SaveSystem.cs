using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";

    public static void Init()
    {
        if(!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static void SaveBestScore(int score)
    {
        SaveContent content = new SaveContent { bestScore = score };

        string json = JsonUtility.ToJson(content);
        Save(json);
    }

    public static int GetBestScore()
    {
        string saveString = Load();
        SaveContent saveContent = JsonUtility.FromJson<SaveContent>(saveString);
        return saveContent != null ? saveContent.bestScore : 0;
    }

    private static void Save(string saveString)
    {
        File.WriteAllText(SAVE_FOLDER + "Save.txt", saveString);
    }

    private static string Load()
    {
        if(File.Exists(SAVE_FOLDER + "save.txt"))
        {
            return File.ReadAllText(SAVE_FOLDER + "save.txt");
        }
        else
        {
            return null;
        }
    }
}

public class SaveContent
{
    public int bestScore;
}
