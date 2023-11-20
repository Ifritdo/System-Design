// OutcomeManager.cs
using UnityEngine;

public class OutcomeManager : MonoBehaviour
{
    public Player playerShip; // Asegúrate de asignar tu nave desde el Inspector.
    public float maxTime = 300; // Tiempo máximo en segundos para tu juego.
    public string victorySceneName = "EndSceneV"; // Nombre de la escena de victoria.
    public string defeatSceneName = "EndSceneD"; // Nombre de la escena de derrota.
    public SceneController sceneController;

    private float timer;

    private void Start()
    {
        timer = maxTime;
        sceneController = FindObjectOfType<SceneController>();
    }

    private void Update()
    {
        // Reduce el temporizador con el tiempo transcurrido en segundos.
        timer -= Time.deltaTime;

        // Comprueba si el temporizador ha alcanzado 0.
        if (timer <= 0)
        {
            // Temporizador agotado, verifica otras condiciones.
            CheckOutcomeConditions();
        }
    }

    private void CheckOutcomeConditions()
    {
        // Agrega aquí tus condiciones de victoria y derrota.
        if (playerShip.health > 0)
        {
            // El jugador ganó.
            LoadVictoryScene();
        }
        else
        {
            // El jugador perdió.
            LoadDefeatScene();
        }
    }

    private void LoadVictoryScene()
    {
        PlayerPrefs.SetInt("PlayerScore", ScoreManager.instance.score);
        PlayerPrefs.Save();

        // Carga la escena de victoria utilizando el SceneController.
        sceneController.LoadScene("EndSceneV");
    }

    private void LoadDefeatScene()
    {
        PlayerPrefs.SetInt("PlayerScore", ScoreManager.instance.score);
        PlayerPrefs.Save();

        // Carga la escena de derrota utilizando el SceneController.
        sceneController.LoadScene("EndSceneD");
    }
}