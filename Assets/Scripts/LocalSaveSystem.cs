using System.IO;

public class LocalSaveSystem : SaveSystem
{
    private string savePath;

    public LocalSaveSystem(string path)
    {
        savePath = path;
    }

    public void Save(SaveData data, SaveDataFormat format)
    {
        data.version = SaveData.CURRENT_VERSION;
        string serializedData = format.Serialize(data);
        File.WriteAllText(savePath, serializedData);
    }

    public SaveData Load(SaveDataFormat format)
    {
        if (!File.Exists(savePath))
        {
            return null;
        }

        string serializedData = File.ReadAllText(savePath);
        SaveData data = format.Deserialize<SaveData>(serializedData);

        if (data.version < SaveData.CURRENT_VERSION)
        {
            // Przetw�rz dane zgodnie z ich wersj�, aby by�y kompatybilne z aktualn� wersj�.
            // Na przyk�ad, je�li zmieni�e� nazw� pola, mo�esz tutaj zaktualizowa� star� nazw� na now�.
        }

        return data;
    }
}
