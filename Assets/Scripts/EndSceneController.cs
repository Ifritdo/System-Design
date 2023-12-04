using UnityEngine;

public class EndSceneController : MonoBehaviour
{
    public SceneController sceneController;

    private void Start()
    {
        // Puedes obtener la última escena jugada desde el SceneController.
        string lastPlayedScene = sceneController.LastPlayedScene;
        Debug.Log($"Last Played Scene: {lastPlayedScene}");
    }

    public void OnReplayButtonClicked()
    {
        // Carga la última escena jugada almacenada en el SceneController.
        sceneController.LoadScene(sceneController.LastPlayedScene);
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
