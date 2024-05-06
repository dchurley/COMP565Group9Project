using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public GameObject ui;
    // Start is called before the first frame update
    void Awake()
    {
        ui.GetComponent<UIManager>().InitSaveSlots();
    }
}
