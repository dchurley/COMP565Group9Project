using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainBehavior : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
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
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Targetable" || other.transform.tag == "EnemyProjectile")
        {
            EndGame();
        }
    }

    // kills player movement and plays death animation
    void EndGame()
    {
        GetComponent<PlayerMovement>().enabled = false;
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
