using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.XR;

public class Deck : MonoBehaviour {

    Battle battle;

    //Display used card variables
    CardsUsedDisplay cardsUsedDisplay;
    int usedCards = 0;
    int maxCardsPerTurn;

    //Card Positions
    static private Vector3 CARD_POSITION1 = new Vector3(-1, 2, 0);
    static private Vector3 CARD_POSITION2 = new Vector3(2, 2, 0);
    static private Vector3 CARD_POSITION3 = new Vector3(5, 2, 0);
    static private Vector3 CARD_POSITION4 = new Vector3(8, 2, 0);
    static private Vector3 CARD_POSITION5 = new Vector3(11, 2, 0);
    static private Vector3 DRAW_POSITION = new Vector3(0, -2, 0);
    static private Vector3 DISCARD_POSITION = new Vector3(13, -2 ,0);

    [SerializeField] float waitTime = 0.2f;

    //Lists of Cards
    List<Card> cardsInDeck = new List<Card>();
    List<Card> cardsInHand = new List<Card>();
    List<Card> cardsInDiscard = new List<Card>();
    int childCount;

    float offset = 0f;
    bool enableCardInHand = false;
    bool enableEndTurn = false;



    public void AddCardToDeck(Card card)
    {
        int childCountOffset = (gameObject.transform.childCount);
        var newCard = Instantiate(card, new Vector3(transform.position.x-15 + (childCountOffset), transform.position.y-5, transform.position.z+childCountOffset), Quaternion.identity);
        newCard.transform.parent = gameObject.transform;
    }
    public void StartBattle()
    {
        cardsUsedDisplay = FindObjectOfType<CardsUsedDisplay>();
        maxCardsPerTurn = FindObjectOfType<PlayerInfo>().GetMaxCardsPerTurn();
        cardsUsedDisplay.UpdateMaxDispaly(maxCardsPerTurn);
        cardsUsedDisplay.UpdateUsedDisplay(usedCards);

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
        battle = FindObjectOfType<Battle>();
        if (battle)
        {
            Debug.Log("Drawing Cards");
            StartCoroutine(WaitThenDrawCoroutine());
        }
    }

    public IEnumerator WaitThenDrawCoroutine()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(Draw5RandomCards());
    }

    //Method to end the turn
    public bool GetEndTurn()
    {
        return enableEndTurn;
    }

    // Methods to Draw Cards
    private void ShuffleCards()
    {
        offset = 0;
        foreach (Card cd in cardsInDiscard)
        {
            cardsInDeck.Add(cd);
            MoveCard(cd, DRAW_POSITION + new Vector3(-offset, 0, -offset));
            offset = offset + 0.1f;
        }
        offset = 0;
        cardsInDiscard = new List<Card>();
    }

    public void StartDrawCoroutine()
    {
        usedCards = 0;
        cardsUsedDisplay.UpdateUsedDisplay(usedCards);
        StartCoroutine(Draw5RandomCards());
    }

    public IEnumerator Draw5RandomCards()
    {
        enableCardInHand = false;
        enableEndTurn = false;
        int cardsLeft = cardsInDeck.Count;
        if (cardsLeft < 5)
        {
            for (int i = 0; i < cardsLeft; i++)
            {
               PickARandomCard();
               yield return new WaitForSecondsRealtime(waitTime);
            }

            ShuffleCards();

            for (int j = cardsInHand.Count; j < 5; j++)
            {
                PickARandomCard();
                yield return new WaitForSecondsRealtime(waitTime);
            }
        }

        else if (cardsInHand.Count == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                PickARandomCard();
                yield return new WaitForSecondsRealtime(waitTime);
            }
        }
        else
        {
            Debug.Log("You must first get rid of your hand");
        }
        enableEndTurn = true;
        enableCardInHand = true;
    }

    public void PickARandomCard()
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
        }


    //Methods to discard cards
    public void DiscardCard(Card card)
    {
        cardsInDiscard.Add(card);
        cardsInHand.Remove(card);
        MoveCard(cardsInDiscard[cardsInDiscard.Count - 1].gameObject.GetComponent<Card>(),
            DISCARD_POSITION+new Vector3(0f,offset,offset));
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

    public bool cardInHand(Card card)
    {
        if (enableCardInHand)
        {
            return cardsInHand.Contains(card);
        }
        else
        {
            return false;
        }
    }

    //Methods to move the card to specific postitions
    public Vector3 GetHandPosition()
    {
        Vector3 targetPosition = new Vector3();
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

    public void MoveCard(Card grabbedCard, Vector3 targetPosition)
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
    public void UsedCard()
    {
        usedCards = usedCards + 1;
        cardsUsedDisplay.UpdateUsedDisplay(usedCards);
    }
    public bool usedMaxCards()
    {
        return (usedCards >= maxCardsPerTurn);
    }

    public Battle GetBattle()
    {
        return battle;
    }
}
