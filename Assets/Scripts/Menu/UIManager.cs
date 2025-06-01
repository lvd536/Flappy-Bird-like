using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainUI;
    [SerializeField] private GameObject shopUI;
    [SerializeField] private GameObject optionsUI;

    public void ShopUISetActive(bool active)
    {
        shopUI.SetActive(active);
        mainUI.SetActive(!active);
    }

    public void OptionsUISetActive(bool active)
    {
        optionsUI.SetActive(active);
        mainUI.SetActive(!active);
    }
}
