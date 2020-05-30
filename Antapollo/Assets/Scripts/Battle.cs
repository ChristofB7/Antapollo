using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    PlayerInfo player;
    Enemy enemy;
    HealthDisplay playerHealthDisplay;
    ArmorDisplay playerArmorDisplay;
    EnemyHealthDisplay enemyHealthDisplay;
    EnemyArmorDisplay enemyArmorDisplay;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerInfo>();
        enemy = FindObjectOfType<Enemy>();
        playerHealthDisplay = FindObjectOfType<HealthDisplay>();
        playerArmorDisplay = FindObjectOfType<ArmorDisplay>();
        enemyHealthDisplay = FindObjectOfType<EnemyHealthDisplay>();
        enemyArmorDisplay = FindObjectOfType<EnemyArmorDisplay>();
    }

    public void EnemyChooseMove()
    {
        enemy.ChooseNDoMove();
        enemyArmorDisplay.UpdateDisplay();
    }

    public void PlayerAttack(int damage)
    {
        //if enemy loses all life - win

        int totalDamage = Mathf.RoundToInt(damage * GetPlayerSatiation());
        enemy.TakeDamage(totalDamage);
        enemyHealthDisplay.UpdateDisplay();
        enemyArmorDisplay.UpdateDisplay();
    }
    public void EnemyAttack(int damage)
    {
        //if player loses all life - lose
        player.TakeDamage(damage);
        playerHealthDisplay.UpdateDisplay();
        playerArmorDisplay.UpdateDisplay();
    }

    public void EnemyRemoveArmor()
    {
        enemy.SetArmor(0);
    }

    public void PlayerRemoveArmor()
    {
        player.SetArmor(0);
        playerArmorDisplay.UpdateDisplay();
    }
    public void PlayerArmorUp(int armor)
    {
        player.SetArmor(player.GetArmor()+armor);
        playerArmorDisplay.UpdateDisplay();
    }

    public float GetPlayerSatiation()
    {
        return player.GetSatiation();
    }
}
