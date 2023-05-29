using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSaveSystem : SaveSystem
{
    private MockCloudService cloudService;
    private string saveKey;

    public CloudSaveSystem(MockCloudService service, string key)
    {
        cloudService = service;
        saveKey = key;
    }

    public void Save(SaveData data, SaveDataFormat format)
    {
        string serializedData = format.Serialize(data);
        cloudService.Upload(saveKey, serializedData);
    }

    public SaveData Load(SaveDataFormat format)
    {
        string serializedData = cloudService.Download(saveKey);
        if (serializedData == null)
        {
            return null;
        }

        return format.Deserialize<SaveData>(serializedData);
    }
}
