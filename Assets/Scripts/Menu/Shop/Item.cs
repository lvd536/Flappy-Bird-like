using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private int price;
    [SerializeField] private short skinId;
    [SerializeField] private GameObject selectBtn;
    private bool _both;
    private Image _image;
    private DataManager _data;

    private void Start()
    {
        _data = DataManager.Singleton;
        _image = GetComponent<Image>();
        var bothSkins = _data.GetGameData().bothSkinIds;
        foreach (var s in bothSkins)
        {
            if (s.Equals(skinId))
            {
                _image.color = Color.green;
                _both = true;
                selectBtn.SetActive(true);
                return;
            }
        }
    }

    public void OnClick()
    {
        GameData data = _data.GetGameData();
        if (!_both && data.money >= price) 
        {
            data.money -= price;
            data.currentSkinId = skinId;
            for (int i = 0; i < data.bothSkinIds.Length; i++)
            {
                if (data.bothSkinIds[i] <= 0)
                {
                    data.bothSkinIds[i] = skinId;
                    break;
                }
            }
            _image.color = Color.green;
            selectBtn.SetActive(true);
            _data.SaveGameData(data);
            Stats.Singleton.UpdateValues(_data);
        }
    }
}