using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {
    int level = 0;
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

        //sets data if there is a save
        if (PlayerPrefs.HasKey("deckSize"))
        {

            //contains all of the cards in the game
            Card[] availableCards = new Card[7];

            availableCards[0] = Resources.Load<Card>("Cards/Bite Card");
            availableCards[1] = Resources.Load<Card>("Cards/Block Card");
            availableCards[2] = Resources.Load<Card>("Cards/Bone Crush Card");
            availableCards[3] = Resources.Load<Card>("Cards/Claw Card");
            availableCards[4] = Resources.Load<Card>("Cards/Fade Card");
            availableCards[5] = Resources.Load<Card>("Cards/Grip Heart Card");
            availableCards[6] = Resources.Load<Card>("Cards/Parry Card");

            //Clears default deck
            for (int x = 0; x < deck.transform.childCount; x++)
            {
                Destroy(deck.transform.GetChild(x).gameObject);
            }

            //sets deck based on save file
            for (int x = 0; x < PlayerPrefs.GetInt("deckSize"); x++)
            {
                for (int y = 0; y < availableCards.Length; y++)
                {
                    if(availableCards[y].getID() == PlayerPrefs.GetInt("c" + x.ToString()))
                    {
                        deck.AddCardToDeck(availableCards[y]);
                    }
                }
            }

            //sets health and satiation
            health = PlayerPrefs.GetInt("health");
            satiation = PlayerPrefs.GetFloat("satiation");
            level = PlayerPrefs.GetInt("level");
        }

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

    public float GetMaxSatiation()
    {
        return maxSatiation;
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

    public void save()
    {
        PlayerPrefs.SetInt("health", health);
        PlayerPrefs.SetFloat("satiation", satiation);
        PlayerPrefs.SetInt("deckSize", deck.transform.childCount);
        PlayerPrefs.SetInt("level", level);
        for (int x = 0; x < deck.transform.childCount; x++)
        {
            PlayerPrefs.SetInt("c" + x.ToString(), deck.transform.GetChild(x).GetComponent<Card>().getID());
        }
        PlayerPrefs.Save();
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int getLevel()
    {
        return level;
    }

    public void increaseLevel()
    {
        level += 1;
    }

}
