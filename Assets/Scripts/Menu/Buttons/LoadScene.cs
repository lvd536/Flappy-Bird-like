using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private short sceneId;

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneId);
    }
}
