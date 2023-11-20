// EndSceneController.cs
using UnityEngine;

public class EndSceneController : MonoBehaviour
{
    public SceneController sceneController;

    private void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
    }

    public void OnReplayButtonClicked()
    {
        // Carga la escena principal directamente.
        sceneController.LoadScene("MyMainGame");
    }

    public void OnMainMenuButtonClicked()
    {
        // Carga el menú principal directamente.
        sceneController.LoadScene("MainMenu");
    }

    public void OnExitButtonClicked()
    {
        // Aquí puedes agregar lógica adicional antes de salir del juego.
        // Por ejemplo, guardar datos, mostrar mensajes, etc.
        Application.Quit();
    }
}
