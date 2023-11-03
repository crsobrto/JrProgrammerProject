using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    // All values stored in this MainManager class member will be shared by all instances of this MainManager class
    public static MainManager Instance;

    public Color TeamColor;

    // Awake is called as soon as an object is created
    private void Awake()
    {
        // Singleton: ensures that only a single instance of the MainManager class can ever exist
        if (Instance != null) // If there is already an instance of the MainManager class
        {
            Destroy(gameObject); // Destroy it to prevent multiple instances from being created
            return;
        }

        Instance = this; // "this" is the current instance of MainManager
        DontDestroyOnLoad(gameObject); // Don't destroy the GameObject attached to this script when the scene changes

        LoadColor();
    }

    [System.Serializable] // Required for JsonUtility
    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor; // "TeamColor" is saved in MainManager class

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json"; // Path to JSON save file
        if (File.Exists(path)) // If the save file exists
        {
            string json = File.ReadAllText(path); // Read the JSON text from the save file
            SaveData data = JsonUtility.FromJson<SaveData>(json); // Convert the JSON text to a SaveData instance

            TeamColor = data.TeamColor;
        }
    }
}
