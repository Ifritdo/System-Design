using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float maxTime = 600.0f;
    public TMP_Text timerText;

    public delegate void TimeEvent(string message);
    public static event TimeEvent MessageOne = delegate { };
    public static event TimeEvent MessageTwo = delegate { };

    [SerializeField]
    private float messageTwoInvokeTime = 480f;

    private float currentTime;

    private void Start()
    {
        currentTime = maxTime;
        timerText = GetComponent<TMP_Text>();

        // Invocar eventos
        Invoke("InvokeMessageOne", 2f);  // Invocar después de 2 segundos.
        Invoke("InvokeMessageTwo", messageTwoInvokeTime);    // Usar el tiempo definido desde el Inspector.
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
    private void InvokeMessageOne()
    {
        MessageOne.Invoke("Preparado para el ataque, destruye a los enemigos");
    }

    private void InvokeMessageTwo()
    {
        MessageTwo.Invoke("Ya casi lo logras. En dos minutos terminará el ataque");
    }
}
