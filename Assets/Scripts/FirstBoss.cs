using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossScript : MonoBehaviour
{
    public Sprite alternate;
    public bool activate;
    public GameObject bossBar;
    public GameObject projectile;

    int totalHealth = 10;
    int health = 10;

    bool attacking;
    float attackTime;
    float totalAttack = 1;

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

    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime;
        float x = getNextXPos(delta);

        var pos = gameObject.transform.position;
        pos.x = x;
        gameObject.transform.position = pos;

        if (activate)
        {
            shoot();
            activate = false;
        }
        

        if (attacking)
        {
            attackTime += Time.deltaTime;
            if(attackTime >= totalAttack)
            {
                attacking = false;
                Sprite tmp = gameObject.GetComponent<SpriteRenderer>().sprite;
                gameObject.GetComponent<SpriteRenderer>().sprite = alternate;
                alternate = tmp;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            activate = true;
        }
    }

    void shoot()
    {
        attacking = true;
        attackTime = 0;
        Sprite tmp = gameObject.GetComponent<SpriteRenderer>().sprite;
        gameObject.GetComponent<SpriteRenderer>().sprite = alternate;
        alternate = tmp;



        for(int i = -1; i <= 1; i++)
        {
            for(int j = -1; j <= 1; j++)
            {
                if(i == 0 && j == 0) { continue; }
                var go = GameObject.Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(i * 3, j * 3);
            }
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Projectile"))
        {
            health--;
            bossBar.GetComponent<BossBar>().scale = (float)health / (float)totalHealth;
        }

        if(health == 0)
        {
            Destroy(gameObject);
            FindObjectOfType<mainBehavior>().WinLevel();
        }
    }
}
