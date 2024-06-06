using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            WriteLevel();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }

    //Level Saves

    public void WriteLevel()
   {
        string file = Application.dataPath + "/StreamingAssets/Level.txt";
        int nextLevel = ReadLevel()+1;
        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.WriteLine(nextLevel.ToString());
            writer.Close();
        }
   }

   public static int ReadLevel()
   {
       string file = Application.dataPath + "/StreamingAssets/Level.txt";
       //Read the text from directly from the test.txt file
       StreamReader reader = new StreamReader(file);
       string level = (reader.ReadToEnd());
       reader.Close();
       return int.Parse(level);
   }
}
