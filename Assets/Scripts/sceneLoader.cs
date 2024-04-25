using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class sceneLoader : MonoBehaviour
{
    public string sceneName;
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextScene()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}