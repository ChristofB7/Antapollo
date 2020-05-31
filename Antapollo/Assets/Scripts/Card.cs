using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    Battle battle;
    Deck parentDeck = null;
    private void Start() 
    { 
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
        if (parentDeck && parentDeck.cardInHand(gameObject.GetComponent<Card>()) && !parentDeck.usedMaxCards())
        {
            parentDeck.UsedCard();
            if (gameObject.GetComponent<DamageCard>())
            {
                battle.PlayerAttack(gameObject.GetComponent<DamageCard>().GetDamage());
            }
            else if (gameObject.GetComponent<BlockCard>())
            {
                battle.PlayerArmorUp(gameObject.GetComponent<BlockCard>().GetBlock());
            }

            parentDeck.DiscardCard(gameObject.GetComponent<Card>());
        }
        else
        {
            Debug.Log("Card is not in hand, reached max cards, or no parent object found");
        }
        
    }

}
