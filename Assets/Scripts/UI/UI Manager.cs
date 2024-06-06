using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] public Health playerHealth;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
    }

    public void GameOver() //Activates Game Over screen
    {
        if (!gameOverScreen.active) //only show and play audio once
        {
            gameOverScreen.SetActive(true);
            SoundManager.instance.PlaySound(gameOverSound);
        }
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
