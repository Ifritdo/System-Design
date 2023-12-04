using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private string lastPlayedScene;
    public string LastPlayedScene => lastPlayedScene;

    public string CurrentScene => SceneManager.GetActiveScene().name;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SetLastPlayedScene(string sceneName)
    {
        lastPlayedScene = sceneName;
        PlayerPrefs.SetString("LastPlayedScene", lastPlayedScene);
        PlayerPrefs.Save();
    }
}
