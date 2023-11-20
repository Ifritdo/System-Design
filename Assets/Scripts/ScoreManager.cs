using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Hacemos ScoreManager un Singleton
    public static ScoreManager instance;

    public int score = 0;

    private void Awake()
    {
        // Verificamos si ya hay una instancia existente de ScoreManager.
        if (instance == null)
        {
            instance = this; // Si no hay una instancia, establecemos esta como la instancia actual.
            DontDestroyOnLoad(gameObject); // Evita que se destruya cuando cambias de escena.
        }
        else
        {
            // Si ya hay una instancia, destruimos esta.
            Destroy(gameObject);
        }
    }

    // Método para añadir puntos al puntaje del jugador.
    public void AddPoints(int points)
    {
        score += points;
    }
}