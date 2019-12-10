using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add to the Create menu
[CreateAssetMenu(menuName = "BombAndExplosion")]

public class BombAndExplosion : ScriptableObject
{
    string thisBombBelongsTo = "";

    // Method to allow other script to change who does the bomb belongs to
    public void setOwner (string bombCreator)
    {
        this.thisBombBelongsTo = bombCreator;
    }

    // Method to allow other script to access to who created the bomb
    public string getOwner ()
    {
        return this.thisBombBelongsTo;
    }
}
