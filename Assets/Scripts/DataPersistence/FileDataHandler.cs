using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Net.NetworkInformation;


public class FileDataHandler
{
    private string dataDirPath = "";

    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load(string profileId)
    {
        // use Path.Combine to account for different types together 
        string fullPath = Path.Combine(dataDirPath, profileId, dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {

                // Load the serialized data from the file
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                // Change from json to game readable format
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to load data from file: " + fullPath + "\n" + e);
            }

        }
        return loadedData;
    }


    public void Save(GameData data, string profileId)
    {
        string fullPath = Path.Combine(dataDirPath, profileId, dataFileName);
           try
           {
               Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

               // serialize game data to Json
               string dataToStore = JsonUtility.ToJson(data, true);

               // write serialized date to file
               using (FileStream stream = new FileStream(fullPath, FileMode.Create))
               {
                   using (StreamWriter writer = new StreamWriter(stream))
                   {
                       writer.Write(dataToStore);
                   }
               }
           }

           catch (Exception e)
           {
               Debug.LogError("Error occured when trying to save data to file:" + fullPath + "\n");
           }
    }

    public Dictionary<string, GameData> LoadAllProfiles()
    {
        InitProfiles();

        Dictionary<string, GameData> profileDictionary = new Dictionary<string, GameData>();

        IEnumerable<DirectoryInfo> dirInfos = new DirectoryInfo(dataDirPath).EnumerateDirectories();

        foreach (DirectoryInfo dirInfo in dirInfos)
        {
            string profileId = dirInfo.Name;

            string fullPath = Path.Combine(dataDirPath, profileId, dataFileName);

            if (!File.Exists(fullPath))
            {
                Debug.LogWarning("Skipping directory when loading all profiles because it does not contain data: " + profileId);
                GameData newData = new GameData();
                profileDictionary.Add(profileId, newData);
                continue;
            }

            GameData profileData = Load(profileId);

            if (profileData != null)
            {
                profileDictionary.Add(profileId, profileData);
            }
            else
            {
                Debug.LogError("Tried to load profile but something went wrong. ProfileId: " + profileId);
            }

        }
        return profileDictionary;
    }

    public void InitProfiles()
    {
        for (int i = 0; i < 3; i++)
        {
            string directoryPath = Path.Combine(dataDirPath, i.ToString());

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Debug.Log("Directory created at: " + directoryPath);
            }
            else
            {
                Debug.Log("Directory exists at: " + directoryPath);
            }

        }
    }

}