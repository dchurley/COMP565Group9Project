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
    private int furthestL;
    private bool loaded;
    private bool lockD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        furthestL = gameData.furthestLevel + 1;
        loaded = true;
    }

    public void SaveData(ref GameData gameData)
    {

    }

    private void InitMenu()
    {
        for (int i = 0; i < 3; i++)
        {
            if (furthestL < i)
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
