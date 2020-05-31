using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {
    int maxHealth;
    int health = 10;
    int armor = 2;
    float satiation = 1.0f;
    [SerializeField] Deck deck;
    Deck deckInstance = null;
    int MaxCardsPerTurn = 2;

    private void Awake()
    {
        deck = gameObject.transform.GetChild(0).GetComponent<Deck>();
        //if there are more than 1 players destroy the newest one
        int playerCount = FindObjectsOfType<PlayerInfo>().Length;
        if (playerCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        //dont destroy this game object
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void StartBattle()
    {

        deckInstance = Instantiate(deck, new Vector3(-20, -20, -20), Quaternion.identity);
        deckInstance.StartBattle();
    }
    public int GetHealth()
    {
        return health;
    }
    public int GetArmor()
    {
        return armor;
    }

    public void SetArmor(int armorToSet)
    {
        armor = armorToSet;
    }
    public void TakeDamage(int damage)
    {
            if (damage > armor)
            {
                damage = damage - armor;
                armor = 0;
                health = health - damage;
            }
            else
            {
                armor = armor - damage;
            }
        }

    public float GetSatiation()
    {
        return satiation;
    }

    public Deck GetDeckInstance()
    {
        return deckInstance;
    }

    public Deck GetPlayerDeck()
    {
        return deck;
    }

    public int GetMaxCardsPerTurn()
    {
        return MaxCardsPerTurn;
    }

    public void LowerSatiation()
    {
        satiation = satiation - 0.1f;
    }
    }
