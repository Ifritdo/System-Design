using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab; // Prefab del Boss
    public Vector2 spawnPosition; // Posición de aparición del Boss

    private bool bossSpawned = false; // Para asegurarse de que solo se instancie un Boss
    private float tiempoParaAparecerBoss = 900f; // 15 minutos en segundos

    // Referencia al spawner de enemigos normales
    public EnemySpawner enemySpawner;

    private void Update()
    {
        // Verificar si el Boss no ha sido instanciado y activar el spawner del Boss
        if (!bossSpawned)
        {
            // Coloca aquí la condición para activar el spawner del Boss
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Q) || TimerLlegoAlTiempo())
            {
                MostrarBoss();
            }
        }
    }

    private bool TimerLlegoAlTiempo()
    {
        // Lógica para verificar si el tiempo ha llegado a 15:00
        if (Time.time >= tiempoParaAparecerBoss)
        {
            return true;
        }
        return false;
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
        Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
        // Configuraciones adicionales del Boss...

        bossSpawned = true; // Marcar que el Boss ha sido instanciado
    }
}
