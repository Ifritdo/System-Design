using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    public float moveSpeed = 5;
    private float originalX;

    void Start()
    {
        originalX = transform.position.x;
    }

    void FixedUpdate()
    {
        MoveLoop();
    }

    void MoveLoop()
    {
        Vector2 pos = transform.position;

        // Mueve el objeto en la dirección negativa (izquierda)
        pos.x -= moveSpeed * Time.fixedDeltaTime;

        // Si el objeto se ha movido más allá de su posición original menos la mitad de su longitud,
        // entonces vuelve a su posición original.
        if (pos.x < originalX - GetComponent<SpriteRenderer>().bounds.size.x / 2)
        {
            pos.x = originalX;
        }

        transform.position = pos;
    }
}