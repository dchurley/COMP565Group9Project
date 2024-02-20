using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject go;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Instantiate(go);
    }
}
