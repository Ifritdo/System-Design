using UnityEngine;
using TMPro;

public class MessageManager : MonoBehaviour
{
    public TMP_Text halfwayMessageText;
    public TMP_Text endMessageText;

    private void OnEnable()
    {
        // Suscribe los métodos a los eventos
        GameEvents.OnTimeReachedHalfway.AddListener(ShowHalfwayMessage);
        GameEvents.OnTimeReachedEnd.AddListener(ShowEndMessage);
    }

    private void OnDisable()
    {
        // Desuscribe los métodos de los eventos cuando el objeto se desactiva o se destruye
        GameEvents.OnTimeReachedHalfway.RemoveListener(ShowHalfwayMessage);
        GameEvents.OnTimeReachedEnd.RemoveListener(ShowEndMessage);
    }

    private void ShowHalfwayMessage()
    {
        // Activa el objeto de texto y establece el mensaje
        halfwayMessageText.gameObject.SetActive(true);
        halfwayMessageText.text = "Preparado para el ataque, destruye a los enemigos";

        // Desactiva el objeto de texto después de 2 segundos
        Invoke("HideHalfwayMessage", 2f);
    }

    private void ShowEndMessage()
    {
        // Activa el objeto de texto y establece el mensaje
        endMessageText.gameObject.SetActive(true);
        endMessageText.text = "Ya casi lo logras. En dos minutos terminará el ataque";

        // Desactiva el objeto de texto después de 2 segundos
        Invoke("HideEndMessage", 2f);
    }

    private void HideHalfwayMessage()
    {
        // Desactiva el objeto de texto
        halfwayMessageText.gameObject.SetActive(false);
    }

    private void HideEndMessage()
    {
        // Desactiva el objeto de texto
        endMessageText.gameObject.SetActive(false);
    }
}
