using UnityEngine;
using UnityEngine.UI;

public class VFX : MonoBehaviour
{
    private Slider _vfxSlider;
    private DataManager _dataManager;
    private GameData _gameData;

    private void Start()
    {
        _vfxSlider = GetComponent<Slider>();
        _dataManager  = DataManager.Singleton;
        _gameData = _dataManager.GetGameData();
        _vfxSlider.value = _gameData.vfxVolume;
    }

    public void UpdateVFXSlider()
    {
        _gameData.vfxVolume = _vfxSlider.value;
        _dataManager.SaveGameData(_gameData);
    }
}