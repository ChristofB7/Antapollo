using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.XR;

public class Deck : MonoBehaviour {
    //Hand Positions
    static private Vector2 CARD_POSITION1 = new Vector2(-1, 2);
    static private Vector2 CARD_POSITION2 = new Vector2(2, 2);
    static private Vector2 CARD_POSITION3 = new Vector2(5, 2);
    static private Vector2 CARD_POSITION4 = new Vector2(8, 2);
    static private Vector2 CARD_POSITION5 = new Vector2(11, 2);

    //Lists of Cards
    List<Card> cardsInDeck = new List<Card>();
    List<Card> cardsInHand = new List<Card>();
    int countDeck;

    public void Start()
    {
        countDeck = gameObject.transform.childCount;
        for (int i = 0; i < countDeck; i++)
        {
            Card card = gameObject.transform.GetChild(i).gameObject.GetComponent<Card>();
            if (card)
            {
                cardsInDeck.Add(card);
            }
            else
            {
                Debug.Log("Card read error - skipping card");
            }
        }
    }



    // Methods to Draw Cards
    public void Pick5RandomCards()
    {
        for(int i = 0; i < 5; i++)
        {
            Card card = PickARandomCard();
        }
       // CheckDeck();
        CheckHand();
    }

    public Card PickARandomCard()
    {
        // pick a card from the deck
        Card grabbedCard = cardsInDeck[Random.Range(0, countDeck - 1)];
        // add the card to the hand
        cardsInHand.Add(grabbedCard);
        //find the last added card in hand, move that card to the Target Position
        MoveCard(cardsInHand[cardsInHand.Count - 1].gameObject.GetComponent<Card>(), GetTargetPosition());
        //Remove the grabbed card from the deck
        cardsInDeck.Remove(grabbedCard);
        //subtract 1 to the card count
        countDeck = countDeck - 1;


        return grabbedCard;
    }

    public Vector2 GetTargetPosition()
    {
        Vector2 targetPosition = new Vector2();
        switch (cardsInHand.Count)
        {
            case 1: targetPosition = CARD_POSITION1;break;
            case 2: targetPosition = CARD_POSITION2;break;
            case 3: targetPosition = CARD_POSITION3;break;
            case 4: targetPosition = CARD_POSITION4;break;
            case 5: targetPosition = CARD_POSITION5;break;
            default: Debug.Log("There are more than five cards in your hand" + cardsInHand.Count); break;


        }
        return targetPosition;
    }

    public void MoveCard(Card grabbedCard, Vector2 targetPosition)
    {
        grabbedCard.transform.position = targetPosition;
    }


    //Debugging Methods:
    public void CheckDeck()
    {
        Debug.Log("Number of cards in deck: " + cardsInDeck.Count);
        foreach(Card cd in cardsInDeck)
        {
            Debug.Log(cd);
        }
    }
    public void CheckHand()
    {
        Debug.Log("Number of cards in hand: " + cardsInHand.Count);
        foreach(Card cd in cardsInHand)
        {
            Debug.Log(cd);
        }
    }

    

}
