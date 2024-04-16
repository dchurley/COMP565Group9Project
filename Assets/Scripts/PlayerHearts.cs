using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHearts : MonoBehaviour
{

    public int hearts = 3;
    public Sprite empty;

    void takeDamage()
    {
        if(hearts == 3)
        {
            transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = empty;
        }
        if (hearts == 2)
        {
            transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = empty;
        }
        if (hearts == 1)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = empty;
        }


        hearts--;
    }

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            takeDamage();
        }
    }
}
