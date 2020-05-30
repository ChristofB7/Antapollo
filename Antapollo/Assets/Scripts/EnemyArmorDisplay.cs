using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyArmorDisplay : MonoBehaviour
{
    TextMeshProUGUI enemyArmorText;
    Enemy enemy;

    // Update is called once per frame
    private void Start()
    {
        enemyArmorText = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        enemy = FindObjectOfType<Enemy>();
        UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        enemyArmorText.text = enemy.GetArmor().ToString();
    }
}
