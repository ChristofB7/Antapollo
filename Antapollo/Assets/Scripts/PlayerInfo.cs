using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {
    int maxHealth = 10;
    int health = 10;
    int armor = 0;
    float maxSatiation = 2.0f;
    float minSatiation = 0.1f;
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

    public void HealPlayer(int amount)
    {
        if(health + amount > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health = health + amount;
        }
    }

    public void IncreaseSatiation()
    {
        if (satiation >= maxSatiation)
        {
            satiation = maxSatiation;
        }
        else
        {
            Debug.Log("satiation: " + satiation);
            satiation = satiation + 0.1f;
            Debug.Log("satiation: " + satiation);
        }

    }
    public void LowerSatiation()
    {
        if (satiation <= minSatiation)
        {
            satiation = minSatiation;
        }
        else
        {
            Debug.Log("satiation: " + satiation);
            satiation = satiation - 0.1f;
            Debug.Log("satiation: " + satiation);
        }
    }
    public void AddCard(Card card)
    {
        deck.AddCardToDeck(card);
    }
    }
