using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sell : MonoBehaviour
{
    PlayerInfo player;
    GameObject deck;
    int column = 0;
    int row = 0;
    public void GoBackToShop()
    {
        SceneManager.LoadScene(3);
    }

    private void MoveAllCards()
    {
        deck = player.gameObject.transform.GetChild(0).gameObject;
        for (int i = 0; i < deck.transform.childCount; i++)
        {
            GameObject card = deck.transform.GetChild(i).gameObject;
            card.transform.position = new Vector3(row, column, 0);
            row++;
            if ((i+1)%10==0)
            {
                column = column+2;
                row = 0;
            }

        }
    }

    public void Start()
    {
        player = FindObjectOfType<PlayerInfo>();
        player.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        MoveAllCards();
        //player.transform.position = new Vector3(3.17f, 9.3f, -1f);

    }
    public void MoveDeckBack()
    {
        player.transform.position = new Vector3(-100, -100, 0);
        player.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
