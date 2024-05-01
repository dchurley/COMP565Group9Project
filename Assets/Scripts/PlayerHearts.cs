using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHearts : MonoBehaviour
{

    public int hearts = 3;
    public Sprite empty;

    public void takeDamage()
    {
        if(hearts == 3)
        {
            transform.GetChild(2).GetComponent<Image>().sprite = empty;
        }
        if (hearts == 2)
        {
            transform.GetChild(1).GetComponent<Image>().sprite = empty;
        }
        if (hearts == 1)
        {
            transform.GetChild(0).GetComponent<Image>().sprite = empty;
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
    }
}
