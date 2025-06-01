using TMPro;
using UnityEngine;

public class Select : MonoBehaviour
{
    [SerializeField] private short skinId;
    [SerializeField] private TextMeshProUGUI text;

    private void Update()
    {
        if (DataManager.Singleton.GetGameData().currentSkinId != skinId)
        {
            text.text = "Select";
        }
    }
    
    public void OnClick()
    {
        DataManager dataManager = DataManager.Singleton;
        GameData _data = dataManager.GetGameData();
        _data.currentSkinId = skinId;
        text.text = "Selected";
        dataManager.SaveGameData(_data);
    }
}
