using TMPro;
using UnityEngine;

public class DeathUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    public static DeathUI Singleton;

    private void Awake()
    {
        Singleton = this;
    }
    
    public void UpdateValues()
    {
        DataManager dataManager = DataManager.Singleton;
        GameData currentData = dataManager.GetGameData();
        int score = GameManager.Singleton.GetScore();
        currentData.score = score;
        if (score > currentData.bestScore) currentData.bestScore = score;
        scoreText.text = "Score: " + score;
        bestScoreText.text = "Best score: " + currentData.bestScore;
        dataManager.SaveGameData(currentData);
    }
}
