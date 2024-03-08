using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBar : MonoBehaviour
{
    // Start is called before the first frame update
    public float scale = 1.0f;
    private float sizeX;
    private float sizeY;

    void Start()
    {
        Transform orig = transform.GetChild(0);
        sizeX = orig.localScale.x;
        sizeY = orig.localScale.y;
    }

    void resizeBar()
    {
        gameObject.transform.GetChild(0).localScale = new Vector3(sizeX * scale, sizeY, 1);
    }

    // Update is called once per frame
    void Update()
    {
        resizeBar();
    }
}
