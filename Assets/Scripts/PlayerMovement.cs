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
    bool invuln = false;

    private float playerSizeX;
    private float playerSizeY;

    void Start()
    {
        playerSizeX = GetComponent<BoxCollider2D>().size.x;
        playerSizeY = GetComponent<BoxCollider2D>().size.y;
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

        clampPlayerMovement();

        float delta = Time.deltaTime;
        if(coolDownTimer < coolDownTime)
        {
            coolDownTimer += delta;
        }

        if (invuln)
        {
            invulnTimer += delta;
        }

        if (invulnTimer >= invulnTime) {
            invulnTimer = 0;
            invuln = false;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

    }

    void clampPlayerMovement()
    {
        var mainCamera = Camera.main;

        // Get the object's current position
        Vector3 currentPosition = transform.position;

        // Get the world coordinates of the screen borders
        Vector3 leftBottom = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 rightTop = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        // Calculate the clamped position
        currentPosition.x = Mathf.Clamp(currentPosition.x, leftBottom.x + playerSizeX, rightTop.x - playerSizeX);
        currentPosition.y = Mathf.Clamp(currentPosition.y, leftBottom.y + playerSizeY, rightTop.y - playerSizeY);

        // Update the object's position
        transform.position = currentPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Targetable") || other.CompareTag("EnemyProjectile"))
        {
            if (!invuln)
            {
                takeDamage();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag.Equals("Targetable") || other.transform.tag.Equals("EnemyProjectile"))
        {
            if(!invuln)
            {
                takeDamage();
            }
        }
    }

    public void takeDamage()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        invulnTimer = 0;
        invuln = true;
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
