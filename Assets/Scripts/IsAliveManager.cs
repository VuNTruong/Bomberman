using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add to the Create menu (makes it easier to create new instances)
[CreateAssetMenu(menuName = "IsAliveManager")]

public class IsAliveManager : ScriptableObject
{
    bool isAlive = true;

    // Method to allow other script to change the status to true
    public void changeToFalse ()
    {
        this.isAlive = false;
    }

    // Method to allow other script to change the status to false
    public void changeToTrue ()
    {
        this.isAlive = true;
    }

    // Method to allow other scipt to access the current status
    public bool getStatus ()
    {
        return this.isAlive;
    }
}
