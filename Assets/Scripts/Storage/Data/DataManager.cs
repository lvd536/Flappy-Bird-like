using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private Sprite[] skinRenderers;
    private GameData _gameData;
    private StorageService _storageService;
    
    public static DataManager Singleton;
    
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DataManager");
        if (objs.Length > 1) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        Singleton = this;
        _storageService = new StorageService();
        _gameData = (GameData) _storageService.Load(new GameData());
    }

    private void Start()
    {
        Stats.Singleton.UpdateValues(this);
    }
    
    public Sprite GetCurrentSkin()
    {
        short currentSkinId = _gameData.currentSkinId;
        return skinRenderers[currentSkinId];
    }

    public List<short> GetAvailableSkinIds()
    {
        List<short> result = new List<short>();
        foreach (var s in _gameData.bothSkinIds)
        {
            if (s > 0)
            {
                result.Add(s);
            }
        }

        if (result.Count == 0) result = null;
        return result;
    }
    
    public GameData GetGameData()
    {
        return _gameData;
    }

    public void SaveGameData(GameData data)
    {
        _storageService.Save(_gameData);
    }
}
