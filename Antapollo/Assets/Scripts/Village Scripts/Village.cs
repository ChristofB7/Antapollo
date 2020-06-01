using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Village : MonoBehaviour
{
    PlayerInfo player;

    public void Start()
    {
        player = FindObjectOfType<PlayerInfo>();
    }
    public void Battle()
    {
        SceneManager.LoadScene(1);
    }

    public void Rest()
    {
        Debug.Log("player health: " + player.GetHealth());
        player.HealPlayer(30);
        Debug.Log("player health: " + player.GetHealth());
    }

    public void Feast()
    {
        player.IncreaseSatiation();
        player.IncreaseSatiation();
        player.IncreaseSatiation();
    }

    public void ShopScene()
    {
        SceneManager.LoadScene(3);
    }

}
