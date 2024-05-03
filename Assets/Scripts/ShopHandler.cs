using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // required when using UI elements in scripts


public class ShopHandler : MonoBehaviour, IDataPersistence
{
    public Transform buyButtons;
    public Transform equipButtons;
    public TextMeshProUGUI coinCounter;

    private int[] costs;
    private bool[] unlocks;

    private int currency;
    private int equipped;
    private int nextLevel;
    
    // Start is called before the first frame update
    void Awake()
    {
        InitShop();
    }

    public void LoadData(GameData gameData)
    {
        currency = gameData.currency;
        equipped = gameData.equippedWeapon;
        unlocks = new bool[4];
        nextLevel = gameData.furthestLevel + 1;
        unlocks[0] = gameData.hasPistol;
        unlocks[1] = gameData.hasShotgun;
        unlocks[2] = gameData.hasSMG;
        unlocks[3] = gameData.hasRifle;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.currency = currency;
        equipped = gameData.equippedWeapon;
        gameData.hasPistol = unlocks[0];
        gameData.hasShotgun = unlocks[1];
        gameData.hasSMG = unlocks[2];
        gameData.hasRifle = unlocks[3];
    }

    private void InitShop()
    {
        costs = new int[4];
        costs[0] = 0;
        costs[1] = 150;
        costs[2] = 500;
        costs[3] = 1000;
        coinCounter.text = currency.ToString();

        for (int i = 0; i < 4; i++)
        {
            if (currency >= costs[i] && !unlocks[i])
            {
                LockItem(i);
            }
            else if (unlocks[i])
            {
                buyButtons.GetChild(i).gameObject.SetActive(false);
                equipButtons.GetChild(i).gameObject.SetActive(true);
                if (equipped == i)
                {
                    equipButtons.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = "EQUIPPED";
                }
            }
        }
    }

    private void LockItem(int item)
    {
        buyButtons.GetChild(item).GetComponentInChildren<Button>().interactable = false;
        buyButtons.GetChild(item).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = "X";
    }
    
    public void BuyItem(int item)
    {
        currency -= costs[item];
        coinCounter.text = currency.ToString();
        unlocks[item] = true;
        buyButtons.GetChild(item).gameObject.SetActive(false);
        equipButtons.GetChild(item).gameObject.SetActive(true);
    }

    public void EquipItem(int item)
    {
        equipButtons.GetChild(equipped).GetChild(0).GetComponent<TextMeshProUGUI>().text = "EQUIP";
        equipped = item;
        equipButtons.GetChild(item).GetChild(0).GetComponent<TextMeshProUGUI>().text = "EQUIPPED";
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(1);
    }
}
