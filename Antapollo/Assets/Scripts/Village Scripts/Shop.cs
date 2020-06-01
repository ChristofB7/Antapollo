using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    PlayerInfo player;
    [SerializeField] Button returnToVillage = null;
    [SerializeField] Button sellButton = null;
    [SerializeField] Button backToWorldMapButton = null;

    public void Start()
    {
        player = FindObjectOfType<PlayerInfo>();
    }
    // Start is called before the first frame update
    public void GoBack()
    {
        SceneManager.LoadScene(2);
    }
    public void SellACard()
    {
        SceneManager.LoadScene(4);

    }

    public void RemoveAllBuyableCards()
    {
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).transform.position = new Vector3(-10, -10, 0);
                
        }
        if(returnToVillage && sellButton && backToWorldMapButton)
        {
            returnToVillage.transform.position = new Vector3(-10, -10, 0);
            sellButton.transform.position = new Vector3(-10, -10, 0);
            backToWorldMapButton.transform.position = new Vector3(1, 1, 0);
        }
        else
        {
            Debug.Log("Button not set");
        }
    }

    public void ReturnToWorldMap()
    {
        player.transform.position = new Vector3(-1, -1, -100);
        SceneManager.LoadScene(0);
    }
}
