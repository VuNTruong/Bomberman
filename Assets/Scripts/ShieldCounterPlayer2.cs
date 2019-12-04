using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShieldCounterPlayer2 : MonoBehaviour
{
    // Link to Coin Manager in inspector
    public ShieldManagerPlayer2 shieldData;

    // Text component of the GameObject
    Text shieldCount;

    // Start is called before the first frame update
    void Start()
    {
        shieldData.setshield(0);

        // Get the Text component of this object
        shieldCount = GetComponent<Text>();

        // Give a start value
        shieldCount.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        // Get the number of coin
        shieldCount.text = shieldData.getshield().ToString();
    }
}
