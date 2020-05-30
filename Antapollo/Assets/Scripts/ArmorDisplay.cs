using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArmorDisplay : MonoBehaviour
{
    TextMeshProUGUI armorText;
    PlayerInfo player;

    // Update is called once per frame
    private void Start()
    {
        armorText = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<PlayerInfo>();
        UpdateDisplay();
    }
    public void UpdateDisplay()
    {
       armorText.text = player.GetArmor().ToString();
    }
}
