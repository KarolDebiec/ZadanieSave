using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private string savePath;

    private string saveKey = "playerData";
    private MockCloudService cloudService;

    private void Start()
    {
        savePath = Application.persistentDataPath + "/savefile.json";
    }

    public void SavePlayerData()
    {
        PlayerData playerData = new PlayerData();
        playerData.position = player.transform.position;
        playerData.health = player.GetComponent<Health>().currentHealth;

        SaveData data = new SaveData();
        data.playerData = playerData;

        SaveDataFormat format = new JsonSaveDataFormat();
        SaveSystem saveSystem = new LocalSaveSystem(savePath);

        saveSystem.Save(data, format);
        Debug.Log("Player data saved.");
    }

    public void LoadPlayerData()
    {
        SaveDataFormat format = new JsonSaveDataFormat();
        SaveSystem saveSystem = new LocalSaveSystem(savePath);

        SaveData data = saveSystem.Load(format);

        if (data != null)
        {
            player.transform.position = data.playerData.position;
            player.GetComponent<Health>().currentHealth = data.playerData.health;
            Debug.Log("Player data loaded.");
        }
        else
        {
            Debug.Log("No save data found.");
        }
    }
    public void SavePlayerCloudData()
    {
        PlayerData playerData = new PlayerData();
        playerData.position = player.transform.position;
        playerData.health = player.GetComponent<Health>().currentHealth;

        SaveData data = new SaveData();
        data.playerData = playerData;

        SaveDataFormat format = new JsonSaveDataFormat();
        SaveSystem saveSystem = new CloudSaveSystem(cloudService, saveKey);

        saveSystem.Save(data, format);
        Debug.Log("Player data saved to cloud.");
    }

    public void LoadPlayerCloudData()
    {
        SaveDataFormat format = new JsonSaveDataFormat();
        SaveSystem saveSystem = new CloudSaveSystem(cloudService, saveKey);

        SaveData data = saveSystem.Load(format);

        if (data != null)
        {
            player.transform.position = data.playerData.position;
            player.GetComponent<Health>().currentHealth = data.playerData.health;
            Debug.Log("Player data loaded from cloud.");
        }
        else
        {
            Debug.Log("No save data found in cloud.");
        }
    }
}
