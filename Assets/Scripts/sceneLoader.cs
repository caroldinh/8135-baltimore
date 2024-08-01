using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class sceneLoader : MonoBehaviour
{
    public int sceneNumber;
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void LoadNextScene()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}