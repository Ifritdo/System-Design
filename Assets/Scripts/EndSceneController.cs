using UnityEngine;

public class EndSceneController : MonoBehaviour
{
    public SceneController sceneController;
    private string lastPlayedScene;

    private void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
        // Recupera la �ltima escena jugada almacenada en PlayerPrefs.
        lastPlayedScene = PlayerPrefs.GetString("LastPlayedScene", "MainMenu");
    }

    public void OnReplayButtonClicked()
    {
        if (!string.IsNullOrEmpty(lastPlayedScene) && sceneController != null)
        {
            sceneController.LoadScene(lastPlayedScene);
        }
        else
        {
            Debug.LogError("Error al cargar la �ltima escena jugada.");
        }
    }

    public void OnMainMenuButtonClicked()
    {
        // Carga el men� principal directamente.
        sceneController.LoadScene("MainMenu");
    }
    public void OnSpaceStationButtonClicked()
    {
        // Carga la escena ChooseLevel al presionar el bot�n Space Station.
        sceneController.LoadScene("ChooseLevel");
    }

    public void OnExitButtonClicked()
    {
        // Aqu� puedes agregar l�gica adicional antes de salir del juego.
        // Por ejemplo, guardar datos, mostrar mensajes, etc.
        Application.Quit();
    }
}
