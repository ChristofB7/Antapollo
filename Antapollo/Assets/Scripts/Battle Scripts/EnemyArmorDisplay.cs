using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyArmorDisplay : MonoBehaviour
{
    TextMeshProUGUI enemyArmorText;
    Enemy enemy;
    Battle battle;

    // Run manually on initialization in order to ensure load order
    public void setUp()
    {
        battle = FindObjectOfType<Battle>();
        enemyArmorText = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        enemy = battle.getEnemy(0);
        UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        enemyArmorText.text = enemy.GetArmor().ToString();
    }
}
