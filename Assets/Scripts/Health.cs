using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    public float health = 100;
    public Image healthImg;
    public TextMeshProUGUI healthText;

    public void Damage(int damage)
    {
        health -= damage;

        if (healthImg)
            healthImg.fillAmount = health / 100;

        if (healthText)
            healthText.text = health.ToString("F0");
    }

    /*public void Heal(int heal)
    {
        health += heal; //heal the player

        if (healthImg)
            healthImg.fillAmount = health / 100;

        if (healthText)
            healthText.text = health.ToString("F0");
    }*/

    public void ResetHealth()
    {
        health = 100;

        if(healthImg)
            healthImg.fillAmount = 1;

        if(healthText)
            healthText.text = health.ToString("F0");
    }
}
