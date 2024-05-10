using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstBossScript : MonoBehaviour
{
    public Sprite alternate;
    public bool activate;
    public GameObject bossBar;
    public GameObject projectile;
    public float coolDownTime = 2.0f;
    public float attackTime = 1.0f;
    public int maxHealth = 10;
    public float projectileSpeed = 3.0f;

    int health;
    bool attacking;
    float attackTimer;
    float coolDownTimer;
    float phaseX;
    float phaseY;

    float getNextXPos(float delta)
    {
        float twopi = 2.0f * Mathf.PI;
        phaseX += delta;
        if(phaseX > twopi)
        {
            phaseX -= twopi;
        }
        float pos = Mathf.Sin(phaseX) * 7.0f;
        return pos;
    }

    float getNextYPos(float delta)
    {
        float twopi = 2.0f * Mathf.PI;
        phaseY += delta * 0.5f;
        if (phaseY > twopi)
        {
            phaseY -= twopi;
        }
        float pos = Mathf.Sin(phaseY) * 2.0f;
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
        float y = getNextYPos(delta);
        var pos = gameObject.transform.position;
        pos.x = x;
        pos.y = y;
        gameObject.transform.position = pos;

        //advance the cooldown timer and check it for shooting
        coolDownTimer += delta;
        if(coolDownTimer >= coolDownTime) {

            coolDownTimer = 0;
            setupAttack();
            spawnAttack1();

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
    }

    void setupAttack()
    {
        attacking = true;
        attackTimer = 0;
        Sprite tmp = gameObject.GetComponent<SpriteRenderer>().sprite;
        gameObject.GetComponent<SpriteRenderer>().sprite = alternate;
        alternate = tmp;
    }



    void spawnAttack2()
    {
        //attack to send a projectile straight at the player


        //get mouse postion on the screne
        var bossPos = gameObject.transform.position;
        var playerPos = GameObject.Find("Player").transform.position;

            //calculate the angle between the marker object and the center of the boss
            var angle = new Vector2(bossPos.x, bossPos.y) - new Vector2(playerPos.x, playerPos.y);
            //normalize and multiply (set the standard velocity)
            angle.Normalize();
        //fix it going backward for some reason
        //make it faster since its just one projectile
            angle *= projectileSpeed * -2;
            //create the new projectile and set it's velocity
            var go = GameObject.Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = angle;

        
    }

    void spawnAttack3()
    {

        int projectileCount = 8;

        //get mouse postion on the screne
        var bossPos = gameObject.transform.position;
        var attackMarker = gameObject.transform.GetChild(1);

        //for every i and j combo of -1, 0, 1
        //produce a projectile on the axis (not including 0, 0)
        for (int i = 0; i < projectileCount; i++)
        {
            //get the ith child (marker object)
            //get the position
            var marker = attackMarker.GetChild(i).position;
            //calculate the angle between the marker object and the center of the boss
            var angle = new Vector2(bossPos.x, bossPos.y) - new Vector2(marker.x, marker.y);
            //normalize and multiply (set the standard velocity)
            angle.Normalize();
            angle *= projectileSpeed;
            //create the new projectile and set it's velocity
            var go = GameObject.Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = angle;

        }
    }

    void spawnAttack1()
    {

        int projectileCount = 7;

        //get mouse postion on the screne
        var bossPos = gameObject.transform.position;
        var attackMarker = gameObject.transform.GetChild(0);

        //for every i and j combo of -1, 0, 1
        //produce a projectile on the axis (not including 0, 0)
        for (int i = 0; i < projectileCount; i++)
        {
            //get the ith child (marker object)
            //get the position
            var marker = attackMarker.GetChild(i).position;
            //calculate the angle between the marker object and the center of the boss
            var angle = new Vector2(bossPos.x, bossPos.y) - new Vector2(marker.x, marker.y);
            //normalize and multiply (set the standard velocity)
            angle.Normalize();
            angle *= projectileSpeed;
            //create the new projectile and set it's velocity
            var go = GameObject.Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = angle;
            
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
