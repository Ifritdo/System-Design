using UnityEngine;
using TMPro;

public class MessageManager : MonoBehaviour
{
    public TMP_Text MessageOneText;
    public TMP_Text MessageTwoText;

    private void OnEnable()
    {
        Timer.MessageOne += ShowMessageOne;
        Timer.MessageTwo += ShowMessageTwo;
    }

    private void OnDisable()
    {
        Timer.MessageOne -= ShowMessageOne;
        Timer.MessageTwo -= ShowMessageTwo;
    }

    private void ShowMessageOne(string message)
    {
        // Mostrar el mensaje de la mitad del tiempo.
        MessageOneText.gameObject.SetActive(true);
        MessageOneText.text = message;
        Invoke("HideMessageOne", 2f);  // Ocultar después de 2 segundos.
    }

    private void HideMessageOne()
    {
        MessageOneText.gameObject.SetActive(false);
    }

    private void ShowMessageTwo(string message)
    {
        // Mostrar el mensaje al final del tiempo.
        MessageTwoText.gameObject.SetActive(true);
        MessageTwoText.text = message;
        Invoke("HideMessageTwo", 2f);  // Ocultar después de 2 segundos.
    }

    private void HideMessageTwo()
    {
        MessageTwoText.gameObject.SetActive(false);
    }
}
