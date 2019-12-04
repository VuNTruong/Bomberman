using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add to the Create menu (makes it easier to create new instances)
[CreateAssetMenu(menuName = "MissileManagerPlayer2")]

public class MissileManagerPlayer2 : ScriptableObject
{
    int missile = 0;

    // Methods to allow other scripts to increment and access the count.
    public void incrementMissile()
    {
        missile++;
    }

    // Method to allow other scripts to decrement and access the count
    public void decrementMissile()
    {
        missile--;
    }

    // Method to get the current number of coins
    public int getMissile()
    {
        return missile;
    }

    // Method to set the number of coin
    public void setMissile(int numMissile)
    {
        this.missile = numMissile;
    }
}
