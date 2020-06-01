﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    //Display winning and losing
    [SerializeField] Canvas winCanvas = null;
    [SerializeField]Canvas loseCanvas = null;
    bool gameOver = false;

    //Player Information
    PlayerInfo player;
    HealthDisplay playerHealthDisplay;
    ArmorDisplay playerArmorDisplay;

    //Enemy Information
    Enemy enemy;
    EnemyHealthDisplay enemyHealthDisplay;
    EnemyArmorDisplay enemyArmorDisplay;



    // Start is called before the first frame update
    void Start()
    {
        winCanvas.gameObject.SetActive(false);
        loseCanvas.gameObject.SetActive(false);
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
        if (!gameOver)
        {
            Deck playerDeck = player.GetDeckInstance();
            if (playerDeck.GetEndTurn())
            {
                EnemyChooseMove();
                PlayerRemoveArmor();

                playerDeck.DiscardRestOfHand();
                playerDeck.StartDrawCoroutine();
            }
        }
        else
        {
            Debug.Log("The game has ended");
        }

    }

    public int GetPlayerHealthArmor()
    {
        int totalHP = player.GetHealth() + player.GetArmor();
        return totalHP;
    }

    public void EnemyChooseMove()
    {
        enemy.ChooseNDoMove();
        enemyArmorDisplay.UpdateDisplay();
    }

    public int CalculateAttack(int damage)
    {
        return Mathf.RoundToInt(damage * player.GetSatiation());
    }

    public void PlayerAttack(int damage)
    {

        //if enemy loses all life - win
        enemyHealthDisplay.GetComponent<Animator>().SetTrigger("Damage Trigger");
        int totalDamage = Mathf.RoundToInt(damage * player.GetSatiation());

        if(enemy.GetArmor() + enemy.GetHealth() <= totalDamage)
        {
            WinGame();
        }

        enemy.TakeDamage(totalDamage);
        enemyHealthDisplay.UpdateDisplay();
        enemyArmorDisplay.UpdateDisplay();
    }

    private void WinGame()
    {
        gameOver = true;
        winCanvas.gameObject.SetActive(true);
        winCanvas.transform.position = new Vector3(5,3,1);
        Time.timeScale = 0f;
        Debug.Log("win the game");
        player.LowerSatiation();
    }

    public void LoseGame()
    {
        gameOver = true;
        loseCanvas.gameObject.SetActive(true);
        loseCanvas.transform.position = new Vector3(5, 3, 1);
        Time.timeScale = 0f;
        Debug.Log("You have lost");
        player.LowerSatiation();
        player.LowerSatiation();
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

    public void UpdateEnemyArmorDisplay()
    {
        enemyArmorDisplay.UpdateDisplay();
    }

    public void HealPlayer(int amount)
    {
        player.HealPlayer(amount);
        playerHealthDisplay.UpdateDisplay();
    }
}