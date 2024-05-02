using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements in scripts


public class ShopHandler : MonoBehaviour
{
    public Button gun1;
    public Button gun2;
    public Button gun3;
    public Button gun4;
    
    private int[] costs;

    private int currency;
    private int equipped;
    
    // Start is called before the first frame update
    void Start()
    {
        currency = 150;
        equipped = 0;
    }

    void InitShop()
    {
        costs[1] = 150;
        costs[2] = 500;
        costs[3] = 1000;

        gun1.interactable = false;
        gun1.GetComponentInChildren<Text>().text = "USING";
        
        for (int i = 0; i < 4; i++)
        {
            if (true)
            {
                
            }
        }

        if (currency < 150)
        {
            gun2.interactable = false;
            gun2.GetComponentInChildren<Text>().text = "X";
        }
        if (currency < 500)
        {
            gun3.interactable = false;
            gun3.GetComponentInChildren<Text>().text = "X";
        }
        if (currency < 1000)
        {
            gun4.interactable = false;
            gun4.GetComponentInChildren<Text>().text = "X";
        }
    }
    
    void BuyItem()
    {
        
    }

    void EquipItem()
    {

    }
}
