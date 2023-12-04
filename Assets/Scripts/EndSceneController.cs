using UnityEngine;

public class EndSceneController : MonoBehaviour
{
    public SceneController sceneController;

    private void Start()
    {
        // Puedes obtener la �ltima escena jugada desde el SceneController.
        string lastPlayedScene = sceneController.LastPlayedScene;
        Debug.Log($"Last Played Scene: {lastPlayedScene}");
    }

    public void OnReplayButtonClicked()
    {
        // Carga la �ltima escena jugada almacenada en el SceneController.
        sceneController.LoadScene(sceneController.LastPlayedScene);
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
