using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Village : MonoBehaviour
{
    PlayerInfo player;
    [SerializeField] Button battleButton = null;
    [SerializeField] Button restButton = null;
    [SerializeField] Button feastButton = null;
    [SerializeField] Button shopButton = null;
    [SerializeField] Button worldMapButton = null;


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
        RemoveAllButtons();
    }

    public void Feast()
    {
        player.IncreaseSatiation();
        player.IncreaseSatiation();
        player.IncreaseSatiation();
        RemoveAllButtons();
    }

    public void ShopScene()
    {
        SceneManager.LoadScene(3);
    }

    private void RemoveAllButtons()
    {
        if (battleButton && restButton && feastButton && shopButton && worldMapButton)
        {

            battleButton.gameObject.transform.position = new Vector3(-10, -10, 0);
            restButton.gameObject.transform.position = new Vector3(-10, -10, 0);
            feastButton.gameObject.transform.position = new Vector3(-10, -10, 0);
            shopButton.gameObject.transform.position = new Vector3(-10, -10, 0);

            worldMapButton.gameObject.transform.position = new Vector3(1, 1, 0);
            player.gameObject.transform.position = new Vector3(0, 0, -100);
        }
        else
        {
            Debug.Log("buttons are not set");
        }
    }
    public void BackToWorldMap()
    {
        SceneManager.LoadScene(0);
    }

}
