using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    public string sceneName;
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}