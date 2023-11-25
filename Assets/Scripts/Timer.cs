using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float maxTime = 600.0f;  // Cambié el tiempo máximo a 10 minutos (600 segundos).
    public TMP_Text timerText;
    private float currentTime;

    private void Start()
    {
        currentTime = maxTime;
        timerText = GetComponent<TMP_Text>();

        // Invocar eventos al alcanzar la mitad y el final del tiempo
        Invoke("InvokeOnTimeReachedHalfway", 2f);  // Invocar después de 2 segundos.
        Invoke("InvokeOnTimeReachedEnd", 480f);    // Invocar después de 480 segundos (8 minutos).
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            Debug.Log("Tiempo agotado");
            // También puedes disparar un evento aquí si lo prefieres.
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("Tiempo: {0:00}:{1:00}", minutes, seconds);
    }

    // Métodos para invocar eventos
    private void InvokeOnTimeReachedHalfway()
    {
        GameEvents.OnTimeReachedHalfway.Invoke();
    }

    private void InvokeOnTimeReachedEnd()
    {
        GameEvents.OnTimeReachedEnd.Invoke();
    }
}
