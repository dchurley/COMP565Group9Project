using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public Animator animator;
    public GameObject playerProjectile;
    public GameObject health;

    public float coolDownTime = 0.3f;
    float coolDownTimer;

    public float invulnTime = 1.0f;
    float invulnTimer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

        float delta = Time.deltaTime;
        if(coolDownTimer < coolDownTime)
        {
            coolDownTimer += delta;
        }
        if(invulnTimer < invulnTime)
        {
            invulnTimer += delta;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(coolDownTimer >= coolDownTime)
            {
                shoot();
            }
        }

    }

    private void shoot()
    {
        coolDownTimer = 0;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Targetable") || other.CompareTag("EnemyProjectile"))
        {
            if (invulnTimer >= invulnTime)
            {
                takeDamage();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag.Equals("Targetable") || other.transform.tag.Equals("EnemyProjectile"))
        {
            if(invulnTimer >= invulnTime)
            {
                takeDamage();
            }
        }
    }

    public void takeDamage()
    {
        invulnTimer = 0;
        var ph = health.GetComponent<PlayerHearts>();
        ph.takeDamage();

        if(ph.hearts == 0)
        {
            FindObjectOfType<mainBehavior>().EndGame();
        }
    }

    public void Die()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        
    }
}
