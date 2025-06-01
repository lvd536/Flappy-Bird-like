using System.IO;
using UnityEngine;

public class StorageService : IStorageService
{
    private string _directory;
    private string _filePath;

    public StorageService()
    {
        _directory = Application.persistentDataPath + "/saves";
        _filePath = _directory + "/GameData.save";
    }
    
    public object Load(object obj)
    {
        if (!File.Exists(_filePath))
        {
            if (obj != null)
            {
                Save(obj);
                return obj;
            }
            return null;
        }
        var file = File.ReadAllText(_filePath);
        var savedData = JsonUtility.FromJson(file, obj.GetType());
        return savedData;
    }

    public void Save(object obj)
    {
        if (!Directory.Exists(_directory)) Directory.CreateDirectory(_directory);
        string jsonData = JsonUtility.ToJson(obj);
        File.WriteAllText(_filePath, jsonData);
    }
}
