using UnityEngine;

public class Pipe : MonoBehaviour
{
    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = PlayerController.Singleton;
    }
    private void Update()
    {
        if (transform.position.x < _playerController.gameObject.transform.position.x - 5f)
        {
            Destroy(gameObject);
        }
    }
}
