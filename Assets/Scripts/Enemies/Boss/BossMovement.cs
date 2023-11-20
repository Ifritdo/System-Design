// BossMovement.cs

using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float bossSpeed = 5f; // Ajusta la velocidad del Boss
    public float upperPosition = 3.21f; // Ajusta la posición superior
    public float lowerPosition = -3.12f; // Ajusta la posición inferior

    private void Start()
    {
        // Inicializar la posición inicial del spam
        transform.position = new Vector3(6.61285591f, 0.0590000004f, 0f);
    }

    private void Update()
    {
        // Implementa la lógica de movimiento aquí
        MoveBoss();
    }

    private void MoveBoss()
    {
        // Mueve el Boss verticalmente de arriba a abajo en un loop
        float newY = Mathf.PingPong(Time.time * bossSpeed, upperPosition - lowerPosition) + lowerPosition;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
