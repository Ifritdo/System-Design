using UnityEngine;

public class OutcomeManager : MonoBehaviour
{
    public Player playerShip;
    public float maxTime = 300;
    public SceneController sceneController;

    private float timer;

    private void Start()
    {
        timer = maxTime;
        sceneController = FindObjectOfType<SceneController>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            CheckOutcomeConditions();
        }
    }

    private void CheckOutcomeConditions()
    {
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
        // Guarda la última escena jugada.
        sceneController.SetLastPlayedScene(sceneController.CurrentScene);

        PlayerPrefs.SetInt("PlayerScore", ScoreManager.instance.score);
        PlayerPrefs.Save();

        // Carga la escena de victoria utilizando el SceneController.
        sceneController.LoadScene("EndSceneV");
    }

    private void LoadDefeatScene()
    {
        // Guarda la última escena jugada.
        sceneController.SetLastPlayedScene(sceneController.CurrentScene);

        PlayerPrefs.SetInt("PlayerScore", ScoreManager.instance.score);
        PlayerPrefs.Save();

        // Carga la escena de derrota utilizando el SceneController.
        sceneController.LoadScene("EndSceneD");
    }
}
