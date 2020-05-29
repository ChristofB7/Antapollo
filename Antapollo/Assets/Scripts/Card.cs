using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    Deck parentDeck = null;
    private void Start()
    {
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
        if (parentDeck)
        {
            //RUN CARD STUFF HERE
            parentDeck.DiscardCard(gameObject.GetComponent<Card>());
        }
        else
        {
            Debug.Log("No parent deck found");
        }
        
    }

}
