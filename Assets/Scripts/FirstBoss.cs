using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossScript : MonoBehaviour
{
    int totalHealth = 10;
    int health = 10;
    public Sprite alternate;
    public bool activate;
    public GameObject bossBar;
    bool attacking;
    float attackTime;
    float totalAttack = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    void shoot()
    {
        attacking = true;
        attackTime = 0;
        Sprite tmp = gameObject.GetComponent<SpriteRenderer>().sprite;
        gameObject.GetComponent<SpriteRenderer>().sprite = alternate;
        alternate = tmp;
        
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
        }
    }
}
