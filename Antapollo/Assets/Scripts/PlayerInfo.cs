using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    int maxHealth;
    int health;
    int satiation = 0;
    Deck deck;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
