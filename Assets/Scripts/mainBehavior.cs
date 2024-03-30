using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainBehavior : MonoBehaviour
{
    public Animator animator;
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public GameObject player;
    public GameObject bossBar;
    public GameObject hudBar;
    public GameObject music;

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
    }

    // when player is hit, check other object type and if deals damage end game
   

    public void WinLevel()
    {
        music.GetComponent<GameAudioManager>().PlayWinMusic();
        player.SetActive(false);
        bossBar.SetActive(false);
        hudBar.SetActive(false);
        winScreen.SetActive(true);
    }

    // kills player movement and plays death animation
    public void EndGame()
    {
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
}
