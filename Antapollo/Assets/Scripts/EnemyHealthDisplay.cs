using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealthDisplay : MonoBehaviour
{
    TextMeshProUGUI enemyHealthText;
    Enemy enemy;

    // Update is called once per frame
    private void Start()
    {
        enemyHealthText = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        enemy = FindObjectOfType<Enemy>();
        UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        enemyHealthText.text = enemy.GetHealth().ToString();
    }
}
