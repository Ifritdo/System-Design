using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHomingMissile : MonoBehaviour
{
    public float missileSpeed = 6f;
    public float rotateSpeed = 1000f;

    private Transform playerTransform;  // Ahora será obtenido dinámicamente durante la ejecución.

    void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    void Update()
    {
        if (transform.name == "Boss_Homing_Left_Missile" || transform.name == "Boss_Homing_Right_Missile")
        {
            BossHomingMissileMovement();
        }
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    private void BossHomingMissileMovement()
    {
        // Obtener dinámicamente la referencia al jugador si aún no se ha obtenido.
        if (playerTransform == null)
        {
            GameObject playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                playerTransform = playerObject.transform;
            }
        }

        if (playerTransform != null)
        {
            // Mover el misil hacia el jugador.
            transform.Translate((playerTransform.position - transform.position).normalized * missileSpeed * Time.deltaTime);

            // Rotar el misil para apuntar al jugador.
            Quaternion rotateTarget = Quaternion.LookRotation(transform.forward, -(playerTransform.position - transform.position).normalized);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateTarget, rotateSpeed * Time.deltaTime);
        }
    }
}
