using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Data;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("Configuation for File Storage")]

    [SerializeField] private string fileName;

    private GameData gameData;

    private List<DataInterface> dataPersistenceObjects;

    private FileHandler fileHandler;

    private string selectedId = "testing";

    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistence Manager in the scene.");
        }

        instance = this;
    }

    private void Start()
    {
        this.fileHandler = new FileHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void ChangeSelectedId(string newId)
    {
        this.selectedId = newId;

        LoadGame();
    }

    //For creating a new data file
    public void NewGame()
    {
        this.gameData = new GameData();
        SaveGame();
    }

    //For loading save data from a file 
    public void LoadGame()
    {
        this.gameData = fileHandler.Load(selectedId);

        if(this.gameData == null)
        {
            Debug.Log("No data file was found. Please start a new game before data can be loaded.");
            return;
        }

        foreach(DataInterface dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        Debug.Log("Loaded successfully!");
    }
    
    //For saving game data to file
    public void SaveGame()
    {
        if(this.gameData == null)
        {
            Debug.LogWarning("No data found. Create a new game before data can be saved.");
        }

        foreach(DataInterface dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        Debug.Log("Saved successfully!");
        fileHandler.Save(gameData, selectedId);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<DataInterface> FindAllDataPersistenceObjects()
    {
        IEnumerable<DataInterface> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<DataInterface>();

        return new List<DataInterface>(dataPersistenceObjects);
    }

    public bool HasGameData()
    {
        return gameData != null;
    }

    public Dictionary<string, GameData> GetAllFilesGameData()
    {
        return fileHandler.LoadAllFiles();
    }
}
