using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int coinCount = 0; // To track the number of coins collected
    public int levelCount = 0; // To track the number of levels 

    public TextMeshProUGUI coinText; // Reference to the UI Text for coins
    public TextMeshProUGUI levelText; // Reference to the UI Text for levels

    [Header("Audio")]
    public AudioSource sfx;
    public AudioClip coin, level;

    void Start()
    {
        UpdateUI(); // Update the UI when the game starts
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the "Coin" tag
        if (other.CompareTag("Coin"))
        {
            other.enabled = false; // Disable the coin's collider temporarily
            coinCount++; // Increment the coin count
            sfx.clip = coin;
            sfx.Play();
            Debug.Log("Coins Collected: " + coinCount);
            Destroy(other.gameObject); // Remove the coin from the scene
            UpdateUI(); // Update the UI after collecting a coin
        }

        // Check if the collided object has the "Trigger" tag (level advancement)
        if (other.CompareTag("Trigger"))
        {
            other.enabled = false; // Disable the coin's collider temporarily
            levelCount++; // Increment the level count
            sfx.clip = level;
            sfx.Play();
            Debug.Log("Level: " + levelCount);
            Destroy(other.gameObject); // Remove the trigger from the scene
            UpdateUI(); // Update the UI after completing a level
        }
    }

    // Update the UI text elements with the current values
    void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinCount; // Update the coin count on the UI
        }
        if (levelText != null)
        {
            levelText.text = "Level: " + levelCount; // Update the level count on the UI
        }
    }


}
