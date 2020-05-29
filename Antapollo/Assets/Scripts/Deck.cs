﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.XR;

public class Deck : MonoBehaviour {
    //Card Positions
    static private Vector2 CARD_POSITION1 = new Vector2(-1, 2);
    static private Vector2 CARD_POSITION2 = new Vector2(2, 2);
    static private Vector2 CARD_POSITION3 = new Vector2(5, 2);
    static private Vector2 CARD_POSITION4 = new Vector2(8, 2);
    static private Vector2 CARD_POSITION5 = new Vector2(11, 2);
    static private Vector2 DRAW_POSITION = new Vector2(0, 0);
    static private Vector2 DISCARD_POSITION = new Vector2(13, -2);

    //Lists of Cards
    List<Card> cardsInDeck = new List<Card>();
    List<Card> cardsInHand = new List<Card>();
    List<Card> cardsInDiscard = new List<Card>();
    int childCount;

    float offset = 0f;

    bool started = false;
    public void Start()
    {
        childCount = gameObject.transform.childCount;
        for (int i = 0; i < childCount; i++)
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
        Debug.Log("Drawing Cards");
        StartCoroutine(WaitThenDrawCoroutine());
    }

    public IEnumerator WaitThenDrawCoroutine()
    {
        yield return new WaitForSeconds(3);
        Draw5RandomCards();
        started = true;
    }

    //Method to end the turn
    public void EndTurn()
    {
        if (started)
        {
            DiscardRestOfHand();
            Draw5RandomCards();

            //TODO: Ememy turn here
        }
        else
        {
            Debug.Log("Please wait for the game to start");
        }
    }

    // Methods to Draw Cards
    public void Draw5RandomCards()
    {
        int cardsLeft = cardsInDeck.Count;

        if(cardsLeft < 5)
        {
          /*  CheckDeck();
            CheckDiscard();
            CheckHand();*/
            for (int i = 0; i < cardsLeft; i++)
            {
                Card card = PickARandomCard();
            }

                ShuffleCards();

            for (int j = cardsInHand.Count; j < 5; j++)
            {
                Debug.Log("j: " + j + "cardsInHand: " + cardsInHand.Count);
                Card card = PickARandomCard();
            }
         /*   CheckDeck();
            CheckDiscard();
            CheckHand();*/
        }

        else if (cardsInHand.Count == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                Card card = PickARandomCard();
            }
        }
        else
        {
            Debug.Log("You must first get rid of your hand");
        }
    }

    private void ShuffleCards()
    {
        offset = 0;
        foreach (Card cd in cardsInDiscard)
        {
            cardsInDeck.Add(cd);
            MoveCard(cd, DRAW_POSITION + new Vector2(-offset, 0));
            offset = offset + 0.1f;
        }
        offset = 0;
        cardsInDiscard = new List<Card>();
    }

    public Card PickARandomCard()
    {
            // pick a card from the deck
            Card grabbedCard = cardsInDeck[UnityEngine.Random.Range(0, cardsInDeck.Count - 1)];

            // add the card to the hand
            cardsInHand.Add(grabbedCard);

            //find the last added card in hand, move that card to the Target Position
            MoveCard(cardsInHand[cardsInHand.Count - 1].gameObject.GetComponent<Card>(),
                GetHandPosition());

            //Remove the grabbed card from the deck
            cardsInDeck.Remove(grabbedCard);

            return grabbedCard;
        }


    //Methods to discard cards
    public void DiscardCard(Card card)
    {
        cardsInDiscard.Add(card);
        cardsInHand.Remove(card);
        MoveCard(cardsInDiscard[cardsInDiscard.Count - 1].gameObject.GetComponent<Card>(),
            DISCARD_POSITION+new Vector2(0f,offset));
        offset = offset + 0.1f;
    }

    public void DiscardRestOfHand()
    {
        int numberOfDiscard = cardsInHand.Count;
        for(int i = 0; i < numberOfDiscard; i++)
        {
            DiscardCard(cardsInHand[0]);
        }
    }


    //Methods to move the card to specific postitions
    public Vector2 GetHandPosition()
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

    public void CheckDeck()
    {
        Debug.Log("Number of cards in Deck: " + cardsInDeck.Count);
        foreach (Card cd in cardsInDeck)
        {

            Debug.Log("Deck card: "+cd);
        }
    }
    public void CheckHand()
    {
        Debug.Log("Number of cards in Hand: " + cardsInHand.Count);
        foreach (Card cd in cardsInHand)
        {

            Debug.Log("Hand card: "+cd);
        }
    }
    public void CheckDiscard()
    {
        Debug.Log("Number of cards in Discard: " + cardsInDiscard.Count);
        foreach (Card cd in cardsInDiscard)
        {

            Debug.Log("Discard card: "+cd);
        }
    }


}
