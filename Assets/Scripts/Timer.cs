using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float maxTime = 300.0f; // Tiempo m�ximo en segundos (5 minutos por defecto).
    public TMP_Text timerText;    // Enlaza el objeto de texto Mesh Pro para mostrar el temporizador.

    private float currentTime;     // Tiempo actual restante.

    private void Start()
    {
        // Configura el tiempo actual al valor m�ximo desde el Inspector.
        currentTime = maxTime;
        // Obt�n una referencia al componente TMP_Text desde el Inspector.
        timerText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        // Actualiza el temporizador.
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            // Si el tiempo llega a 0, puedes realizar una acci�n aqu�, como cargar una escena de derrota.
            Debug.Log("Tiempo agotado");
        }
    }

    private void UpdateTimerText()
    {
        // Actualiza el texto del temporizador para mostrar minutos y segundos.
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("Tiempo: {0:00}:{1:00}", minutes, seconds);
    }
}