using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardsUsedDisplay : MonoBehaviour
{
    TextMeshProUGUI cardsUsed;
    TextMeshProUGUI maxUsableCards;
    PlayerInfo player;
    // Start is called before the first frame update
    void Start()
    {
        cardsUsed = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        maxUsableCards = gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<PlayerInfo>();
    }

    public void UpdateUsedDisplay(int numberOfCardsUsed)
    {
        cardsUsed.text = numberOfCardsUsed.ToString();
    }
    public void UpdateMaxDispaly(int maxCards)
    {
        maxUsableCards.text = maxCards.ToString();
    }

}
