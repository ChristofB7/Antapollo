using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealthDisplay : MonoBehaviour
{
    TextMeshProUGUI enemyHealthText;
    Enemy enemy;
    Battle battle;

    // Run manually on initialization in order to ensure load order
    public void setUp()
    {
        battle = FindObjectOfType<Battle>();
        enemyHealthText = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        enemy = battle.getEnemy(0);
        UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        enemyHealthText.text = enemy.GetHealth().ToString();
    }
}
