using System.Collections;
using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI maxScoreText;
    [SerializeField] private TextMeshProUGUI lastScoreText;

    public static Stats Singleton;
    
    private void Awake()
    {
        Singleton = this;
    }

    private void OnEnable()
    {
        if (DataManager.Singleton)
        {
            DataManager data = DataManager.Singleton;
            moneyText.text = data.GetGameData().money.ToString();
            maxScoreText.text = data.GetGameData().bestScore.ToString();
            lastScoreText.text = data.GetGameData().score.ToString();
        }
    }
    
    public void UpdateValues(DataManager data)
    {
        moneyText.text = data.GetGameData().money.ToString();
        maxScoreText.text = data.GetGameData().bestScore.ToString();
        lastScoreText.text = data.GetGameData().score.ToString();
    }
}
