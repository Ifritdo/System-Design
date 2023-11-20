// BulletSpawner.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    enum SpawnerType { Straight, Spin }

    [Header("Bullet Attributes")]
    public float bulletLife = 1f;
    public float speed = 1f;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);
        if (timer >= firingRate)
        {
            Fire();
            timer = 0;
        }
    }

    private void Fire()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        if (bullet)
        {
            bullet.transform.position = transform.position;
            bullet.GetComponent<BulletBoss>().speed = speed;

            // Invertir la direcci�n de las balas ajustando la rotaci�n en el eje Y
            bullet.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

            bullet.GetComponent<BulletBoss>().bulletLife = bulletLife;
            bullet.SetActive(true);
        }
    }
}
