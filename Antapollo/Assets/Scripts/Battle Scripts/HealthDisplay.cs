using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    TextMeshProUGUI healthText;
    PlayerInfo player;

    // Update is called once per frame
    private void Start()
    {
        healthText = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<PlayerInfo>();
        UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        healthText.text = player.GetHealth().ToString();
    }
}
