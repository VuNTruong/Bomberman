using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MissileCounterPlayer2 : MonoBehaviour
{
    // Link to Coin Manager in inspector
    public MissileManagerPlayer2 missileData;

    // Text component of the GameObject
    Text missileCount;

    // Start is called before the first frame update
    void Start()
    {
        missileData.setMissile(10);

        // Get the Text component of this object
        missileCount = GetComponent<Text>();

        // Give a start value
        missileCount.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        // Get the number of coin
        missileCount.text = missileData.getMissile().ToString();
    }
}
