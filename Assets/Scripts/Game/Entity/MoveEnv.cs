using UnityEngine;

public class MoveEnv : MonoBehaviour
{
    private float speed = 1.5f;
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = PlayerController.Singleton;
        CalculateSpeedByScore();
    } 
    private void FixedUpdate()
    {
        if (!_playerController.isDead) transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void CalculateSpeedByScore()
    {
        int bestScore = DataManager.Singleton.GetGameData().bestScore;
        float spread = bestScore * 0.001f;
        speed += spread;
        Debug.Log(speed);
    }
}