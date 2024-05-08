using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainBehavior : MonoBehaviour, IDataPersistence
{
    public Animator animator;
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public GameObject player;
    public GameObject bossBar;
    public GameObject hudBar;
    public GameObject music;
    public GameObject deathText;
    public int winCoins;
    public int levelNum;

    private int playerCoins;
    private bool[] unlockedLevels;
    private int furthestL;

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    void Update()
    {
        // secret kill command
        if (Input.GetKeyDown(KeyCode.K))
        {
            EndGame();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            WinLevel();
        }
    }

    // when player is hit, check other object type and if deals damage end game
   

    public void WinLevel()
    {
        music.GetComponent<GameAudioManager>().PlayWinMusic();
        AddCoin(winCoins);
        unlockedLevels[levelNum] = true;
        if (furthestL <= levelNum)
        {
            furthestL++;
        }
        player.SetActive(false);
        bossBar.SetActive(false);
        hudBar.SetActive(false);
        winScreen.SetActive(true);
    }

    // kills player movement and plays death animation
    public void EndGame()
    {
        deathText.GetComponent<DeathCountText>().OnPlayerDeath();
        player.GetComponent<PlayerMovement>().Die();
        player.GetComponent<PlayerMovement>().enabled = false;
        animator.SetBool("isDead", true);
        gameOverScreen.SetActive(true);
    }

    // resets the active scene, player can try again
    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // loads the main menu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadShop()
    {
        
        SceneManager.LoadScene("Shop");
    }

    public void LoadData(GameData data)
    {
        this.furthestL = data.furthestLevel;
        this.playerCoins = data.currency;
        this.unlockedLevels = data.levels;
    }

    public void SaveData(ref GameData data)
    {
        data.currency = this.playerCoins;
        data.levels = this.unlockedLevels;
        data.furthestLevel = this.furthestL;
    }

    public void AddCoin(int num)
    {
        playerCoins = num;
    }
}
