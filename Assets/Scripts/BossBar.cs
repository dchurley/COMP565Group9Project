using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    // Start is called before the first frame update
    public float scale = 1.0f;
    public Image i;

    void Start()
    {

    }

    void resizeBar()
    {
        i.fillAmount = scale;
    }

    // Update is called once per frame
    void Update()
    {
        resizeBar();
    }
}
