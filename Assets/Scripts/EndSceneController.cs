using UnityEngine;

public class EndSceneController : MonoBehaviour
{
    public SceneController sceneController;
    private string lastPlayedScene;

    private void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
        // Recupera la última escena jugada almacenada en PlayerPrefs.
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
            Debug.LogError("Error al cargar la última escena jugada.");
        }
    }

    public void OnMainMenuButtonClicked()
    {
        // Carga el menú principal directamente.
        sceneController.LoadScene("MainMenu");
    }
    public void OnSpaceStationButtonClicked()
    {
        // Carga la escena ChooseLevel al presionar el botón Space Station.
        sceneController.LoadScene("ChooseLevel");
    }

    public void OnExitButtonClicked()
    {
        // Aquí puedes agregar lógica adicional antes de salir del juego.
        // Por ejemplo, guardar datos, mostrar mensajes, etc.
        Application.Quit();
    }
}
