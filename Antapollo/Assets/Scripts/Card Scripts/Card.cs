using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    Shop shop;
    Battle battle;
    Deck parentDeck = null;
    private void Start() 
    {
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
            Debug.Log("Card is not in hand, reached max cards, or no parent object found");
        }
        
    }

}
