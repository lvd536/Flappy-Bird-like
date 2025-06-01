using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource _audioSource;
    
    private void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1) Destroy(gameObject);
        DontDestroyOnLoad(this);
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = DataManager.Singleton.GetGameData().musicVolume;
    }

    private void Update()
    {
        var currentData = DataManager.Singleton.GetGameData();
        if (_audioSource.volume != currentData.musicVolume) _audioSource.volume = currentData.musicVolume;
    }
}
