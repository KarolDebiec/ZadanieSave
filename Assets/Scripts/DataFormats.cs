using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

[System.Serializable]
public class PlayerData
{
    public Vector3 position;
    public int health;
}

public class JsonSaveDataFormat : SaveDataFormat
{
    public override string Serialize<T>(T data)
    {
        if (typeof(T) == typeof(PlayerData))
        {
            PlayerData playerData = data as PlayerData;
            // Definiuj, jak serializowaæ niestandardowe typy danych...
            return JsonUtility.ToJson(playerData);
        }

        return JsonUtility.ToJson(data);
    }

    public override T Deserialize<T>(string data)
    {
        if (typeof(T) == typeof(PlayerData))
        {
            // Definiuj, jak deserializowaæ niestandardowe typy danych...
            return (T)(object)JsonUtility.FromJson < PlayerData >(data);
        }
        return JsonUtility.FromJson<T>(data);
    }
}

public class BinarySaveDataFormat : SaveDataFormat
{
    public override string Serialize<T>(T data)
    {
        using (var memoryStream = new MemoryStream())
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(memoryStream, data);
            return System.Convert.ToBase64String(memoryStream.ToArray());
        }
    }

    public override T Deserialize<T>(string data)
    {
        var binaryData = System.Convert.FromBase64String(data);
        using (var memoryStream = new MemoryStream(binaryData, false))
        {
            var formatter = new BinaryFormatter();
            return (T)formatter.Deserialize(memoryStream);
        }
    }
}
