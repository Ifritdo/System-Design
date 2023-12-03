using UnityEngine;
using UnityEngine.UI;

public class ChooseLevelController : MonoBehaviour
{
    public SceneController sceneController;
    public GameObject confirmationPanel;
    public Text confirmationText;

    private string selectedLevel;

    private void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
        confirmationPanel.SetActive(false);
    }

    public void OnComputerClicked(string levelName)
    {
        selectedLevel = levelName;
        if (confirmationPanel != null)
        {
            confirmationText.text = $"Estás por acceder a la simulación de prueba, nivel de dificultad {selectedLevel.Substring(selectedLevel.Length - 1)}. ¿Quieres acceder?";
            confirmationPanel.SetActive(true);
        }
    }

    public void OnConfirmButtonClicked()
    {
        sceneController.LoadScene(selectedLevel);
    }

    public void OnCancelButtonClicked()
    {
        confirmationPanel.SetActive(false);
    }
}
