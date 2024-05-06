using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public string sceneToLoad;
    public Transform saveSlots;
    public AudioMixer audioMixer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync(sceneToLoad);

        // SceneManager.LoadScene(sceneToLoad);
    }

    public void ContinueGame()
    {
        SceneManager.LoadSceneAsync(sceneToLoad);
    }

    public void QuitGame()
    {
        Debug.Log("You Have Quit The Game");
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void InitSaveSlots()
    {
        Dictionary<string, GameData> saves = DataPersistenceManager.instance.GetAllProfilesGameData();
        for (int i = 0; i < 3; i++)
        {
            saveSlots.GetChild(i).GetComponent<SaveSlot>().SetData(saves[i.ToString()]);
        }
    }

    public void PlaySlot()
    {
        DataPersistenceManager.instance.LoadGame();
        int levelToLoad = DataPersistenceManager.instance.CurrentLevel();
        SceneManager.LoadScene(levelToLoad+1);
    }
}
