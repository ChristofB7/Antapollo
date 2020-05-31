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

        player.StartBattle();
    }

    public void EndTurn()
    {
        Deck playerDeck = player.GetDeckInstance();
        if(playerDeck.GetEndTurn())
        {
            EnemyChooseMove();
            PlayerRemoveArmor();

            playerDeck.DiscardRestOfHand();
            playerDeck.StartDrawCoroutine();
        }

    }

    public void EnemyChooseMove()
    {
        enemy.ChooseNDoMove();
        enemyArmorDisplay.UpdateDisplay();
    }

    public void PlayerAttack(int damage)
    {
        //if enemy loses all life - win
        enemyHealthDisplay.GetComponent<Animator>().SetTrigger("Damage Trigger");
        int totalDamage = Mathf.RoundToInt(damage * GetPlayerSatiation());
        enemy.TakeDamage(totalDamage);
        enemyHealthDisplay.UpdateDisplay();
        enemyArmorDisplay.UpdateDisplay();
    }
    public void EnemyAttack(int damage)
    {
        playerHealthDisplay.GetComponent<Animator>().SetTrigger("Damage Trigger");
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
        playerArmorDisplay.GetComponent<Animator>().SetTrigger("Armor Up Trigger");
        player.SetArmor(player.GetArmor()+armor);
        playerArmorDisplay.UpdateDisplay();
    }

    public float GetPlayerSatiation()
    {
        return player.GetSatiation();
    }
}
