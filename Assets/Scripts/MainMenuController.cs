using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public SceneController sceneController;

    private void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
    }

    public void OnPlayButtonClicked()
    {
        Debug.Log("OnPlayButtonClicked");
        // Configura la próxima escena antes de cargar la escena principal.
        PlayerPrefs.SetString("NextScene", "ChooseLevel");
        sceneController.LoadScene("ChooseLevel");
    }

    public void OnExitButtonClicked()
    {
        // Aquí puedes agregar lógica adicional antes de salir del juego.
        // Por ejemplo, guardar datos, mostrar mensajes, etc.
        Application.Quit();
    }
}
