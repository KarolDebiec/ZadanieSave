using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData 
{
    public const int CURRENT_VERSION = 1; // Aktualizuj to, gdy format zapisywanych danych siê zmienia.
    public int version;
    private Dictionary<string, object> data;
    public PlayerData playerData;
    public SaveData()
    {
        data = new Dictionary<string, object>();
    }

    public void Save(SaveDataFormat format, string path)
    {
        string serializedData = format.Serialize(data);
        File.WriteAllText(path, serializedData);
    }
    public void UpdateToLatestVersion()
    {
        while (version < CURRENT_VERSION)
        {
            UpdateToNextVersion();
        }
    }

    private void UpdateToNextVersion()
    {
        // Update data to the next version...
        version++;
    }

}
