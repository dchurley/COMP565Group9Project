using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossScript : MonoBehaviour
{
    public Sprite alternate;
    public bool activate;
    public GameObject bossBar;
    public GameObject projectile;
    public float coolDownTime = 2;
    public float attackTime = 1;
    public int maxHealth = 10;
    public float projectileSpeed = 3;

    int health;
    bool attacking;
    float attackTimer;
    float coolDownTimer;
    float phase;

    float getNextXPos(float delta)
    {
        float twopi = 2.0f * Mathf.PI;
        phase += delta;
        if(phase > twopi)
        {
            phase -= twopi;
        }
        float pos = Mathf.Sin(phase) * 7.0f;
        return pos;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //get the time delta for this frame
        float delta = Time.deltaTime;
        //move the boss the amount for this frame
        float x = getNextXPos(delta);
        var pos = gameObject.transform.position;
        pos.x = x;
        gameObject.transform.position = pos;

        //advance the cooldown timer and check it for shooting
        coolDownTimer += delta;
        if(coolDownTimer >= coolDownTime) {

            coolDownTimer = 0;
            shoot();

        }
        

        if (attacking)
        {
            attackTimer += Time.deltaTime;
            if(attackTimer >= attackTime)
            {
                attacking = false;
                Sprite tmp = gameObject.GetComponent<SpriteRenderer>().sprite;
                gameObject.GetComponent<SpriteRenderer>().sprite = alternate;
                alternate = tmp;
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }
    }

    void shoot()
    {
        attacking = true;
        attackTimer = 0;
        Sprite tmp = gameObject.GetComponent<SpriteRenderer>().sprite;
        gameObject.GetComponent<SpriteRenderer>().sprite = alternate;
        alternate = tmp;


        //for every i and j combo of -1, 0, 1
        //produce a projectile on the axis (not including 0, 0)
        for(int i = -1; i <= 1; i++)
        {
            for(int j = -1; j <= 1; j++)
            {
                if(i == 0 && j == 0) { continue; }
                var go = GameObject.Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(i * projectileSpeed, j * projectileSpeed);
            }
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Projectile"))
        {
            health--;
            bossBar.GetComponent<BossBar>().scale = (float)health / (float)maxHealth;
        }

        if(health == 0)
        {
            Destroy(gameObject);
            FindObjectOfType<mainBehavior>().WinLevel();
        }
    }
}
