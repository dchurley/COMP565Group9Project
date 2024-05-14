using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    public Slider mSlider;
    // Start is called before the first frame update
    void Start()
    {
        mSlider.value = PlayerPrefs.GetFloat("volumeSlider", 0.75f);
    }

}
