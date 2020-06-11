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

    //card spawn location
    Vector3 INVENTORY_POSITION1 = new Vector3(4.5f, 3.25f, 0);
    Vector3 INVENTORY_POSITION2 = new Vector3(1.5f, 3.25f, 0);
    Vector3 INVENTORY_POSITION3 = new Vector3(7.5f, 3.25f, 0);
    Encounter encounter;
    Card cardPreFab1;
    Card cardPreFab2;
    Card cardPreFab3;
    Card card1;
    Card card2;
    Card card3;


    public void Start()
    {
        encounter = FindObjectOfType<Encounter>();
        cardPreFab1 = encounter.getCard(0);
        cardPreFab2 = encounter.getCard(1);
        cardPreFab3 = encounter.getCard(2);

        card1 = Instantiate(cardPreFab1, INVENTORY_POSITION1, Quaternion.identity, gameObject.transform);
        card2 = Instantiate(cardPreFab2, INVENTORY_POSITION2, Quaternion.identity, gameObject.transform);
        card3 = Instantiate(cardPreFab3, INVENTORY_POSITION3, Quaternion.identity, gameObject.transform);
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
        encounter.setEncounterDone(1);
        SceneManager.LoadScene(0);
    }

}
