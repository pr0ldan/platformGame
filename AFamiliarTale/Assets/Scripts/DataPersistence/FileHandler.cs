using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileHandler
{
    private string DirPath = "";

    private string FileName = "";

    public FileHandler(string DirPath, string FileName)
    {
        this.DirPath = DirPath;
        this.FileName = FileName;
    }

    public GameData Load(string Id)
    {
        string fullPath = Path.Combine(DirPath, Id, FileName);

        GameData loaded = null;

        if(File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using(FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream)) 
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                loaded = JsonUtility.FromJson<GameData>(dataToLoad);
            }

            catch(Exception e)
            {
                Debug.LogError("Error while loading: " + fullPath + "\n" + e);
            }
        }

        return loaded;
    }

    public void Save(GameData data, string Id)
    {
        string fullPath = Path.Combine(DirPath, Id, FileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataStored = JsonUtility.ToJson(data, true);

            using(FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataStored);
                }

            }
        }

        catch(Exception e) 
        {
            Debug.LogError("Error while saving: " + fullPath + "\n" + e);
        }
    }

    public Dictionary<string, GameData> LoadAllFiles()
    {
        Dictionary<string, GameData> fileDictionary = new Dictionary<string, GameData>();

        IEnumerable<DirectoryInfo> dirInfo = new DirectoryInfo(DirPath).EnumerateDirectories();
        foreach (DirectoryInfo dir in dirInfo) 
        {
            string Id = "";//dirInfo.Name;

            string fullPath = Path.Combine(DirPath, Id, FileName);
            if(!File.Exists(fullPath))
            {
                Debug.LogWarning("Skipping directory because of no data");
                continue;
            }

            GameData IdData = Load(Id);

            if(IdData != null) 
            {
                fileDictionary.Add(Id, IdData);
            }

            else
            {
                Debug.LogError("Something went wrong with the file: " + Id);
            }
        }

        return fileDictionary;
    }
}
