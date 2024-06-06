using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject continueObject;

    //make continue active only if alr started a new game
    private void Awake()
    {
        if (ReadLevel() == 0)
            {
                continueObject.SetActive(false);
            }  
        else
        {
            continueObject.SetActive(true);
        }
    }

    //Main Menu functions
    public void NewGame()
    {
        WriteLevel();
        WriteHealth(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    //wont do anything 'til someone started a new game
    public void Continue()
    {
        if (ReadLevel() != 0)
        {
            SceneManager.LoadScene(ReadLevel());
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0); //First scene is Main Menu
    }

    public void Quit()
    {
        Application.Quit();
    }

    //Level Saves

    public static int ReadLevel()
   {
       string file = Application.dataPath + "/StreamingAssets/Level.txt";
       //Read the text from directly from the test.txt file
       StreamReader reader = new StreamReader(file);
       string level = (reader.ReadToEnd());
       reader.Close();
       return int.Parse(level);
   }

    public void WriteLevel()
    {
        string file = Application.dataPath + "/StreamingAssets/Level.txt";
        int nextLevel = 1;
        using (StreamWriter writer = File.CreateText(file))
        {
            writer.WriteLine(nextLevel.ToString());
            writer.Close();
        }
    }

    public void WriteHealth(int _value)
   {
        string file = Application.dataPath + "/StreamingAssets/HP.txt";
        int newhp = _value;
        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.WriteLine(newhp.ToString());
            writer.Close();
        }
   }
}
