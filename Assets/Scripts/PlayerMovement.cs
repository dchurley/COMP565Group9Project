using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerProjectile;
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

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //get mouse postion on the screne
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //get mouse x and y
            float mx = mouseWorldPos.x;
            float my = mouseWorldPos.y;

            //get player x and y
            var playerPos = GetComponent<Rigidbody2D>().position;

            var angle = new Vector2(mx, my) - playerPos;
            //normalize so that the dist between player and mouse isnt considered
            angle.Normalize();
            angle *= 5;

            var go = GameObject.Instantiate(playerProjectile, playerPos, Quaternion.identity);

            //set velocity of projectile
            go.GetComponent<Rigidbody2D>().velocity = angle;



        }

    }
}
