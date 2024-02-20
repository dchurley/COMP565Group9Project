using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int speed = 3;

        var velocity = new Vector2(0, 0);

        if(Input.GetKey(KeyCode.D))
        {
            velocity += new Vector2(speed, 0);

        } 
        if (Input.GetKey(KeyCode.A))
        {
            velocity += new Vector2(-speed, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            velocity += new Vector2(0, speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            velocity += new Vector2(0, -speed);
        }

        GetComponent<Rigidbody2D>().velocity = velocity;

        //else if(Input.GetKeyDown(KeyCode.S))
        //{

        //} else if(Input.GetKeyDown(KeyCode.D))
        //{
        //    GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, speed);

        //} else if(Input.GetKeyDown(KeyCode.E))
        //{
        //    GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, -speed);

        //} else
        //{
        //    GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        //}

    }
}
