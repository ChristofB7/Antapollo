﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //used for loading and saving, set to position in cards folder
    [SerializeField] int ID = 0;
    Shop shop;
    Sell sell;
    Battle battle;
    Deck parentDeck = null;
    private void Start() 
    {
        sell = FindObjectOfType<Sell>();
        shop = FindObjectOfType<Shop>();
        battle = FindObjectOfType<Battle>();
        if (gameObject.transform.parent)
        {
            parentDeck = gameObject.transform.parent.GetComponent<Deck>();
        }
        else
        {
            Debug.Log("This Object has no parent");
        }
    }
    private void OnMouseDown()
    {

        if (shop)
        {
            FindObjectOfType<PlayerInfo>().AddCard(gameObject.GetComponent<Card>());
            shop.RemoveAllBuyableCards();
        }
        else if (parentDeck && parentDeck.cardInHand(gameObject.GetComponent<Card>()) && !parentDeck.usedMaxCards())
        {
            parentDeck.UsedCard();
            if (gameObject.GetComponent<DamageCard>())
            {
                battle.PlayerAttack(gameObject.GetComponent<DamageCard>().GetDamage());
            }
            if (gameObject.GetComponent<BlockCard>())
            {
                battle.PlayerArmorUp(gameObject.GetComponent<BlockCard>().GetBlock());
            }
            if (gameObject.GetComponent<HealCard>())
            {
                battle.HealPlayer(gameObject.GetComponent<HealCard>().GetHealAmount());
            }
            parentDeck.DiscardCard(gameObject.GetComponent<Card>());
        }
        else
        {
            sell = FindObjectOfType<Sell>();
            if (sell)
            {
                Destroy(gameObject);
                sell.MoveDeckBack();
                sell.RemoveGoBackButton();
            }
            else
            {
                Debug.Log("Card is not in hand, reached max cards, or no parent object found");
            }

        }
    }

    public int getID()
    {
        return ID;
    }

    public Sprite getSprite()
    {
        return GetComponent<SpriteRenderer>().sprite;
    }
    public Color getColor()
    {
        return GetComponent<SpriteRenderer>().color;
    }
}
