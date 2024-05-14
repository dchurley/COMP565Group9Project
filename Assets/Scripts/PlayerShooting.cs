using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject playerProjectile;
    public GameObject data;

    public GameObject shotgunProjectile;
    public GameObject smgProjectile;
    public GameObject rifleProjectile;

    private int equipped;
    private float coolDownTime = 0.3f;
    float coolDownTimer;
    private float scaleChange;
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
                scaleChange = 1.0f;
                break;
            case 1:
                coolDownTime = 0.9f;
                projectileSpeed = 6;
                scaleChange = 0.8f;
                break;
            case 2:
                coolDownTime = 0.15f;
                projectileSpeed = 9;
                scaleChange = 0.6f;
                break;
            case 3:
                coolDownTime = 0.25f;
                projectileSpeed = 7;
                scaleChange = 1.2f;
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

        //create object
        var go = GameObject.Instantiate(playerProjectile, playerPos, Quaternion.identity);

        //rotate sprite
        float degree = Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg;
        go.transform.rotation = Quaternion.AngleAxis(degree, Vector3.forward);

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

        angleInDegrees = -15f;
        rotation = Quaternion.Euler(0, 0, angleInDegrees);
        Vector2 rotatedVector2 = rotation * angle;

        var go = GameObject.Instantiate(shotgunProjectile, playerPos, Quaternion.identity);
        var go1 = GameObject.Instantiate(shotgunProjectile, playerPos, Quaternion.identity);
        var go2 = GameObject.Instantiate(shotgunProjectile, playerPos, Quaternion.identity);


        //set velocity of projectile
        go.GetComponent<Rigidbody2D>().velocity = angle;
        go1.GetComponent<Rigidbody2D>().velocity = rotatedVector1;
        go2.GetComponent<Rigidbody2D>().velocity = rotatedVector2;

        //rotate sprites
        float degree = Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg;
        go.transform.rotation = Quaternion.AngleAxis(degree, Vector3.forward);
        //rotate sprite 1
        float degree1 = Mathf.Atan2(rotatedVector1.y, rotatedVector1.x) * Mathf.Rad2Deg;
        go1.transform.rotation = Quaternion.AngleAxis(degree1, Vector3.forward);
        //rotate sprite 2
        float degree2 = Mathf.Atan2(rotatedVector2.y, rotatedVector2.x) * Mathf.Rad2Deg;
        go2.transform.rotation = Quaternion.AngleAxis(degree2, Vector3.forward);

        //scaleChange = new Vector3(0.35f, 0.35f, 0.35f);
        var newScale = go.transform.localScale * scaleChange;
        go.transform.localScale = newScale;
        go1.transform.localScale = newScale;
        go2.transform.localScale = newScale;
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

        var go = GameObject.Instantiate(smgProjectile, playerPos, Quaternion.identity);


        //rotate sprites
        float degree = Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg;
        go.transform.rotation = Quaternion.AngleAxis(degree, Vector3.forward);

        //set velocity of projectile
        go.GetComponent<Rigidbody2D>().velocity = angle;



        //scaleChange = new Vector3(0.18f, 0.18f, 0.18f);
        var newScale = go.transform.localScale * scaleChange;
        go.transform.localScale = newScale;
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

        var go = GameObject.Instantiate(rifleProjectile, playerPos, Quaternion.identity);

        //rotate sprites
        float degree = Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg;
        go.transform.rotation = Quaternion.AngleAxis(degree, Vector3.forward);

        //set velocity of projectile
        go.GetComponent<Rigidbody2D>().velocity = angle;
        //scaleChange = new Vector3(0.225f, 0.225f, 0.225f);
        var newScale = go.transform.localScale * scaleChange;
        go.transform.localScale = newScale;
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
