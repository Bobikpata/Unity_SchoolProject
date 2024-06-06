using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthbar;
    [SerializeField] private Image currentHealthbar;

    void Start()
    {
        currentHealthbar.fillAmount = playerHealth.currentHealth / 10;
        totalHealthbar.fillAmount = playerHealth.totalHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthbar.fillAmount = playerHealth.currentHealth / 10;
        totalHealthbar.fillAmount = playerHealth.totalHealth / 10;
    }
}
