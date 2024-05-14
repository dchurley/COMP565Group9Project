using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelHandler : MonoBehaviour, IDataPersistence
{
    public GameObject thisThing;
    public Transform levelSlots;
    private bool[] unlockedLevels;
    private bool loaded;
    private bool lockD;


    // Update is called once per frame
    void Update()
    {
        if (!lockD && loaded)
        {
            InitMenu();
            loaded = false;
            thisThing.SetActive(false);
        }
    }

    public void LoadData(GameData gameData)
    {
        unlockedLevels = gameData.levels;
        loaded = true;
    }

    public void SaveData(ref GameData gameData)
    {

    }

    private void InitMenu()
    {
        for (int i = 0; i < 3; i++)
        {
            if (!unlockedLevels[i])
            {
                levelSlots.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = "LOCKED";
                levelSlots.GetChild(i).GetComponent<Button>().interactable = false;
            }
        }
        loaded = false;
    }

    public void LoadLevel(int num)
    {
        SceneManager.LoadScene(num);
    }
}
