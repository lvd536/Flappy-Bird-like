using UnityEngine;
using UnityEngine.UI;

public class MainMusic : MonoBehaviour
{
    private Slider _musicSlider;
    private DataManager _dataManager;
    private GameData _gameData;

    private void Start()
    {
        _musicSlider = GetComponent<Slider>();
        _dataManager  = DataManager.Singleton;
        _gameData = _dataManager.GetGameData();
        _musicSlider.value = _gameData.musicVolume;
    }

    public void UpdateMusicSlider()
    {
        _gameData.musicVolume = _musicSlider.value;
        _dataManager.SaveGameData(_gameData);
    }
}