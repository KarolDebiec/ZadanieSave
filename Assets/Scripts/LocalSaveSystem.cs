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
            // Przetwórz dane zgodnie z ich wersj¹, aby by³y kompatybilne z aktualn¹ wersj¹.
            // Na przyk³ad, jeœli zmieni³eœ nazwê pola, mo¿esz tutaj zaktualizowaæ star¹ nazwê na now¹.
        }

        return data;
    }
}
