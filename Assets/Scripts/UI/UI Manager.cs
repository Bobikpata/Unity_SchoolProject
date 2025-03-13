using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] public Health playerHealth;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private GameObject pauseScreen;

    private void Awake()
    {
        Time.timeScale = 1;
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScreen.activeInHierarchy)
            {
                Pause(false);
            }
            else
            {
                Pause(true);
            }
        }
    }

    public void GameOver() //Activates Game Over screen
    {
        if (!gameOverScreen.active) //only show and play audio once
        {
            gameOverScreen.SetActive(true);
            SoundManager.instance.PlaySound(gameOverSound);
        }
    }

    public void Pause(bool status)
    {
        pauseScreen.SetActive(status);

        if (status)
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
            Time.timeScale = 0;
        }
        else
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
            Time.timeScale = 1;
        }
    }

    public void Continue()
    {
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    //Game Over functions
    public void Restart()
    {
        playerHealth.WriteHealth(-playerHealth.addHealth);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0); //First scene is Main Menu
    }

    public void Quit()
    {
        Application.Quit();
    }
}
