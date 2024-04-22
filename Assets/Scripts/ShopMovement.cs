using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMovement : MonoBehaviour
{
    public float speed = 3f;
    public Animator animator;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var velocity = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.D))
        {
            velocity += new Vector2(speed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity += new Vector2(-speed, 0);
        }

        if (velocity.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        animator.SetFloat("Horizontal", velocity.x);
        animator.SetFloat("Vertical", velocity.y);
        animator.SetFloat("Speed", velocity.sqrMagnitude);

        GetComponent<Rigidbody2D>().velocity = velocity;
    }

}
