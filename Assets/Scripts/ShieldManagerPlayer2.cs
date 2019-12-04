using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add to the Create menu (makes it easier to create new instances)
[CreateAssetMenu(menuName = "ShieldManagerPlayer2")]

// This is a separate object that stores and provides methods for a counter.

// Note this is an instance of a ScriptableObject, not a MonoBehaviour
public class ShieldManagerPlayer2 : ScriptableObject
{
    int shield = 0;

    // Methods to allow other scripts to increment and access the count.
    public void incrementshield()
    {
        shield++;
    }

    // Method to allow other scripts to decrement and access the count
    public void decrementshield()
    {
        shield--;
    }

    // Method to get the current number of coins
    public int getshield()
    {
        return shield;
    }

    // Method to set the number of coin
    public void setshield(int numshield)
    {
        this.shield = numshield;
    }
}
