using UnityEngine;
using UnityEngine.UI;

public class ComputerController : MonoBehaviour
{
    public GameObject confirmationPanel;
    public Text confirmationText;
    public SceneController sceneController;  // Agrega un campo para SceneController

    private string correspondingScene;

    private void Start()
    {
        confirmationPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowConfirmationPanel();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HideConfirmationPanel();
        }
    }

    private void ShowConfirmationPanel()
    {
        confirmationPanel.SetActive(true);
    }

    private void HideConfirmationPanel()
    {
        confirmationPanel.SetActive(false);
    }

    public void OnConfirmButtonClicked()
    {
        // Verifica si la referencia a SceneController es válida antes de intentar cargar la escena.
        if (sceneController != null)
        {
            // Carga la escena correspondiente al nivel.
            sceneController.LoadScene(correspondingScene);
        }
        else
        {
            Debug.LogError("No se ha asignado una referencia válida a SceneController en ComputerController.");
        }
    }

    public void OnCancelButtonClicked()
    {
        // Oculta el panel de confirmación.
        HideConfirmationPanel();
    }

    // Establece la escena correspondiente al nivel (MyMainGame, MyMainGame1, etc.).
    public void SetCorrespondingScene(string sceneName)
    {
        correspondingScene = sceneName;
        confirmationText.text = $"Estás por acceder a la simulación de prueba, nivel de dificultad {sceneName.Substring(sceneName.Length - 1)}. ¿Quieres acceder?";
    }
}
