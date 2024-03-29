using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossScript : MonoBehaviour
{
    public Sprite alternate;
    public bool activate;
    public GameObject bossBar;
    public GameObject projectile;
    public GameObject winScreen;
    public GameObject player;
    public GameObject hudBar;
    public GameObject music;

    int totalHealth = 10;
    int health = 10;

    bool attacking;
    float attackTime;
    float totalAttack = 1;

    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
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

        var go = GameObject.Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);


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
            EndLevel();
        }
    }

    void EndLevel()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<mainBehavior>().enabled = false;
        music.GetComponent<GameAudioManager>().PlayWinMusic();
        bossBar.SetActive(false);
        hudBar.SetActive(false);
        winScreen.SetActive(true);
    }
}
