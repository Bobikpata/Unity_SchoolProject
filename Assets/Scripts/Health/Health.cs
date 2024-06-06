using UnityEngine;
using System.IO;

public class Health : MonoBehaviour
{
    public float totalHealth;
    public float currentHealth;
    private Animator anim;
    public bool dead;
    public int addHealth;

    private void Awake()
    {
        totalHealth = ReadHealth();
        currentHealth = totalHealth;
        anim = GetComponent<Animator>();
        addHealth = 0;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, totalHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead) //animation occurs only once
            {
                GetComponent<PlayerMovement>().enabled = false;
                anim.SetTrigger("die");
                dead = true;
            }
        }
    }

    public void AddHealth(int _value)
    {
        addHealth += _value;
        WriteHealth(_value);
        currentHealth += _value;
        totalHealth = ReadHealth();
    }

    public float CheckHealth()
    {
        return currentHealth;
    }

    public int ReadHealth()
   {
       string file = Application.dataPath + "/StreamingAssets/HP.txt";
       //Read the text from directly from the test.txt file
       StreamReader reader = new StreamReader(file);
       string hp = (reader.ReadToEnd());
       reader.Close();
       return int.Parse(hp);
   }

   public void WriteHealth(int _value)
   {
        string file = Application.dataPath + "/StreamingAssets/HP.txt";
        int newhp = ReadHealth()+_value;
        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.WriteLine(newhp.ToString());
            writer.Close();
        }
   }
}
