using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : Shop
{
    public override void getCards()
    {
        cardPreFab1 = encounter.getCard(3);
        cardPreFab2 = encounter.getCard(4);
        cardPreFab3 = encounter.getCard(5);
    }
}
