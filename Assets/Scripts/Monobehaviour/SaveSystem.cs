using System.IO;
using UnityEngine;

public sealed class SaveSystem : MonoBehaviour
{
    public static readonly string saveFolder = Application.persistentDataPath + "/Saves/";

    public static void Init()
    {
        if(!Directory.Exists(saveFolder))
        {
            Directory.CreateDirectory(saveFolder);
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
        File.WriteAllText(saveFolder + "Save.txt", saveString);
    }

    private static string Load()
    {
        if(File.Exists(saveFolder + "save.txt"))
        {
            return File.ReadAllText(saveFolder + "save.txt");
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
