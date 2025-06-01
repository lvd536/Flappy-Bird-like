using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private AudioClip pointClip;
    private AudioSource _audioSource;
    private GameData _gameData;

    private void Start()
    {
        _gameData = DataManager.Singleton.GetGameData();
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _audioSource.volume = _gameData.vfxVolume;
            _audioSource.PlayOneShot(pointClip);
            GameManager.Singleton.AddScore(1);
        }
    }
}
