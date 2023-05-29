using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockCloudService
{
    private Dictionary<string, string> data;

    public MockCloudService()
    {
        data = new Dictionary<string, string>();
    }

    public void Upload(string key, string value)
    {
        if (data.ContainsKey(key))
        {
            data[key] = value;
        }
        else
        {
            data.Add(key, value);
        }
    }

    public string Download(string key)
    {
        if (data.ContainsKey(key))
        {
            return data[key];
        }
        else
        {
            return null;
        }
    }
}