using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab; // Prefab del Boss
    public Vector3 spamPosition; // Posición de aparición del Boss

    private bool bossSpawned = false; // Para asegurarse de que solo se instancie un Boss

    // Referencia al spawner de enemigos normales
    public EnemySpawner enemySpawner;

    // Temporizador para controlar la aparición del Boss después de cierto tiempo
    private float timer = 0f;
    public float timeToSpawnBoss = 900f; // 15 minutos en segundos

    private void Update()
    {
        // Verificar si el Boss no ha sido instanciado y activar el spawner del Boss
        if (!bossSpawned)
        {
            // Coloca aquí la condición para activar el spawner del Boss con un temporizador
            timer += Time.deltaTime;
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Q))
            {
                MostrarBoss();
            }
            else if (timer >= timeToSpawnBoss)
            {
                MostrarBoss();
            }
        }
    }

    private void MostrarBoss()
    {
        print("BOSS");
        // Desactivar el spawner de enemigos normales
        if (enemySpawner != null)
        {
            enemySpawner.enabled = false;
        }

        // Instanciar el Boss y realizar configuraciones
        Instantiate(bossPrefab, spamPosition, Quaternion.identity);
        // Configuraciones adicionales del Boss...

        bossSpawned = true; // Marcar que el Boss ha sido instanciado
    }
}
