using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaveDataFormat
{
    public abstract string Serialize<T>(T data);
    public abstract T Deserialize<T>(string data);
}
