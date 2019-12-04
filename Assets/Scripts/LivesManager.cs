using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add to the Create menu (makes it easier to create new instances)
[CreateAssetMenu(menuName = "LivesManager")]

public class LivesManager : ScriptableObject
{
    int lives = 20;

    // Method to allow other script to decrement number of lives
    public void decrementLive()
    {
        // Decrement lives by 1
        lives--;
    }

    public void incrementLive()
    {
        // Increment lives by 1
        lives++;
    }

    // Method to get the current number of lives
    public int getLives()
    {
        return lives;
    }

    // Method to get the number of lives
    public void setLives(int numLives)
    {
        // Set the lives
        this.lives = numLives;
    }
}
