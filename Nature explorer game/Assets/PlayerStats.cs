using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int birdInteractionCount { get; private set; }
    public TMPro.TextMeshProUGUI countText;
    
    void Awake()
    {
        birdInteractionCount = 0;
    }

    public void IncreaseBirdCount()
    {
        birdInteractionCount++;
        UpdateUI();
        Debug.Log("Increased bird count");
    }

    void UpdateUI()
    {
        countText.text = "#Birds interacted with: " + birdInteractionCount;
    }
}
