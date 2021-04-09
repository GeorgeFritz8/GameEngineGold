using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int startingHealth = 100;
    private int health = 100;
    public Text healthText;

    private void Start()
    {
        health = startingHealth;
        healthText.text = "Health: " + health;
    }
    public void takeDamage (int damage)
    {
        health -= damage;
        healthText.text = "Health: " + health;

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
