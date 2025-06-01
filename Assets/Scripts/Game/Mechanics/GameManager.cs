using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject deathUI;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private int _currentScore;

    public static GameManager Singleton;

    private void Awake()
    {
        Singleton = this;
    }
    
    public void Death()
    {
        gameUI.SetActive(false);
        deathUI.SetActive(true);
        DeathUI.Singleton.UpdateValues();
        
    }

    public void AddScore(int score)
    {
        _currentScore = int.Parse(scoreText.text) + score;
        scoreText.text = _currentScore.ToString();
    }

    public int GetScore()
    {
        return _currentScore;
    }
}
