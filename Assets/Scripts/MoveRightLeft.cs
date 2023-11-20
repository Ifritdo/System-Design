using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class MoveRightLeft : MonoBehaviour
{
    public float movespeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.x -= movespeed * Time.fixedDeltaTime;

        //if (pos.x < -2)
        //{
        //    Destroy(gameObject);
        //}

        transform.position = pos;
    }
}
