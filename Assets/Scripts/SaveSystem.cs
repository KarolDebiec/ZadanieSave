using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SaveSystem
{
    void Save(SaveData data, SaveDataFormat format);
    SaveData Load(SaveDataFormat format);
}
