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

    private void Awake()
    {
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

    }
