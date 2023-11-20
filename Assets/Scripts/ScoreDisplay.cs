using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    private TMP_Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        // Actualiza el texto del puntaje mostrando el puntaje actual del ScoreManager.
        scoreText.text = "Score: " + ScoreManager.instance.score;
    }
}