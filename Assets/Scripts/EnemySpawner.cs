using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;  // Array para contener los prefabs de enemigos que queremos generar.
    public float spawnInterval = 2f;   // Intervalo de tiempo entre spawns.
    public Vector2 spawnRange;         // Rango en el cual los enemigos pueden aparecer.

    private float spawnTimer;          // Temporizador interno para el próximo spawn.

    private void Update()
    {
        // Incrementamos el temporizador.
        spawnTimer += Time.deltaTime;

        // Si el temporizador supera el intervalo de spawn, generamos un enemigo.
        if (spawnTimer > spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0;  // Reiniciamos el temporizador.
        }
    }

    private void SpawnEnemy()
    {
        // Seleccionamos un enemigo aleatorio del array.
        int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);

        // Definimos una posición aleatoria dentro del rango definido.
        Vector2 spawnPosition = new Vector2(transform.position.x + Random.Range(-spawnRange.x, spawnRange.x),
                                            transform.position.y + Random.Range(-spawnRange.y, spawnRange.y));

        // Instanciamos el enemigo en la escena.
        Instantiate(enemyPrefabs[randomEnemyIndex], spawnPosition, Quaternion.identity);
    }
}