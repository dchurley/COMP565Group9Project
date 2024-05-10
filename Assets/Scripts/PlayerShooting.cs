using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject playerProjectile;
    public GameObject data;

    private int equipped;
    private float coolDownTime = 0.3f;
    float coolDownTimer;
    private Vector3 scaleChange;
    private int projectileSpeed;

    // Start is called before the first frame update
    void Start()
    {
        equipped = data.GetComponent<mainBehavior>().SetWeapon();
        switch (equipped)
        {
            case 0:
                coolDownTime = 0.3f;
                projectileSpeed = 5;
                break;
            case 1:
                coolDownTime = 0.9f;
                projectileSpeed = 6;
                break;
            case 2:
                coolDownTime = 0.15f;
                projectileSpeed = 9;
                break;
            case 3:
                coolDownTime = 0.25f;
                projectileSpeed = 7;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime;
        if (coolDownTimer < coolDownTime)
        {
            coolDownTimer += delta;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (coolDownTimer >= coolDownTime)
            {
                shoot();
            }
        }
    }

    private void PistolShoot()
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
        angle *= projectileSpeed;

        var go = GameObject.Instantiate(playerProjectile, playerPos, Quaternion.identity);

        //set velocity of projectile
        go.GetComponent<Rigidbody2D>().velocity = angle;
    }

    private void ShotgunShoot()
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
        angle *= projectileSpeed;

        float angleInDegrees = 15f;
        Quaternion rotation = Quaternion.Euler(0, 0, angleInDegrees);
        Vector2 rotatedVector1 = rotation * angle;

        angleInDegrees = -20f;
        rotation = Quaternion.Euler(0, 0, angleInDegrees);
        Vector2 rotatedVector2 = rotation * angle;

        var go = GameObject.Instantiate(playerProjectile, playerPos, Quaternion.identity);
        var go1 = GameObject.Instantiate(playerProjectile, playerPos, Quaternion.identity);
        var go2 = GameObject.Instantiate(playerProjectile, playerPos, Quaternion.identity);

        //set velocity of projectile
        go.GetComponent<Rigidbody2D>().velocity = angle;
        go1.GetComponent<Rigidbody2D>().velocity = rotatedVector1;
        go2.GetComponent<Rigidbody2D>().velocity = rotatedVector2;
        scaleChange = new Vector3(0.35f, 0.35f, 0.35f);
        go.transform.localScale = scaleChange;
        go1.transform.localScale = scaleChange;
        go2.transform.localScale = scaleChange;
    }

    private void SMGShoot()
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
        angle *= projectileSpeed;

        var go = GameObject.Instantiate(playerProjectile, playerPos, Quaternion.identity);

        //set velocity of projectile
        go.GetComponent<Rigidbody2D>().velocity = angle;
        scaleChange = new Vector3(0.18f, 0.18f, 0.18f);
        go.transform.localScale = scaleChange;
    }

    private void RifleShoot()
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
        angle *= projectileSpeed;

        var go = GameObject.Instantiate(playerProjectile, playerPos, Quaternion.identity);

        //set velocity of projectile
        go.GetComponent<Rigidbody2D>().velocity = angle;
        scaleChange = new Vector3(0.225f, 0.225f, 0.225f);
        go.transform.localScale = scaleChange;
    }

    private void shoot()
    {
        switch(equipped)
        {
            case 0:
                PistolShoot();
                break;
            case 1:
                ShotgunShoot();
                break;
            case 2:
                SMGShoot();
                break;
            case 3:
                RifleShoot();
                break;
        }
    }
}
