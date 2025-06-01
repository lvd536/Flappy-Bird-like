using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip flapClip;
    [SerializeField] private AudioClip dieClip;
    private readonly float jumpForce = 7f;
    public bool isDead;
    private Rigidbody2D _rb;
    private AudioSource _audioSource;
    
    public static PlayerController Singleton;
    private void Awake()
    {
        Singleton = this;
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = DataManager.Singleton.GetCurrentSkin();
        _rb = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = DataManager.Singleton.GetGameData().vfxVolume;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _audioSource.PlayOneShot(flapClip);
            _rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            _audioSource.PlayOneShot(dieClip);
            GameManager.Singleton.Death();
            isDead = true;
            gameObject.SetActive(false);
        }
    }
}
