using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ComputerController : MonoBehaviour
{
    public GameObject confirmationPanel;
    public TextMeshProUGUI confirmationText;
    public SceneController sceneController;

    private string correspondingScene;
    private Dictionary<string, string> computerMessages;

    private void Start()
    {
        confirmationPanel.SetActive(false);
        InitializeMessages();
    }

    private void InitializeMessages()
    {
        computerMessages = new Dictionary<string, string>();
        computerMessages["LevelAcces1"] = "Est�s por acceder a la simulaci�n de prueba, nivel de dificultad 1. �Quieres acceder?";
        computerMessages["LevelAcces2"] = "Est�s por acceder a la simulaci�n de prueba, nivel de dificultad 2. �Quieres acceder?";
        computerMessages["LevelAcces3"] = "Est�s por acceder a la simulaci�n de prueba, nivel de dificultad 3. �Quieres acceder?";
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
        // Obt�n el nombre del objeto actual.
        string currentObjectName = gameObject.name;

        // Verifica si el objeto actual tiene un mensaje asociado.
        if (computerMessages.ContainsKey(currentObjectName))
        {
            confirmationText.text = computerMessages[currentObjectName];
            confirmationPanel.SetActive(true);
        }
        else
        {
            Debug.LogError($"No se encontr� un mensaje para el objeto {currentObjectName} en ComputerController.");
        }
    }

    private void HideConfirmationPanel()
    {
        confirmationPanel.SetActive(false);
    }

    public void OnConfirmButtonClicked()
    {
        // Verifica si la referencia a SceneController es v�lida antes de intentar cargar la escena.
        if (sceneController != null)
        {
            // Carga la escena correspondiente al nivel.
            sceneController.LoadScene(correspondingScene);
        }
        else
        {
            Debug.LogError("No se ha asignado una referencia v�lida a SceneController en ComputerController.");
        }
    }

    public void OnCancelButtonClicked()
    {
        // Oculta el panel de confirmaci�n.
        HideConfirmationPanel();
    }

    // Establece la escena correspondiente al nivel (MyMainGame, MyMainGame1, etc.).
    public void SetCorrespondingScene(string sceneName)
    {
        correspondingScene = sceneName;
    }
}

