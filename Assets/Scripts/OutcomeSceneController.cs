using UnityEngine;
using TMPro;

public class OutcomeSceneController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        // Recupera el puntaje almacenado.
        int playerScore = PlayerPrefs.GetInt("PlayerScore", 0);

        // Muestra el puntaje en el texto.
        scoreText.text = "Your Score: " + playerScore;
    }
}