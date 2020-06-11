using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    TextMeshProUGUI healthText;
    TextMeshProUGUI satText;
    PlayerInfo player;

    private void Awake()
    {
        healthText = transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        satText = transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<PlayerInfo>();
        updateMeters(player.GetHealth(), player.GetSatiation());
    }

    public void updateMeters(int health, float satiation)
    {
        float satShifted = satiation - 1;
        healthText.text = health.ToString();
        satText.text = satShifted.ToString();
    }
}
