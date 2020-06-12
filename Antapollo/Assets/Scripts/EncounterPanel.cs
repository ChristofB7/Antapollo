using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EncounterPanel : MonoBehaviour
{
    Button confirm, cancel;
    protected Encounter encounter;
    protected PlayerInfo player;

    //linked to confirm button, loads battle scene on click
    public void confirmClick()
    {
        encounter.loadEncounter();
    }

    //linked to cancel button, closes panel on click
    public void cancelClick()
    {
        close();
    }

    //sets the target encounter, is called on init
    public virtual void setTarget(Encounter iEncounter)
    {
        player = FindObjectOfType<PlayerInfo>();
        encounter = iEncounter;
        if (encounter.getLevel() > player.getLevel())
        {
            transform.GetChild(10).GetComponent<Image>().enabled = true;
        }
        transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().SetText(encounter.getEncounterName());
        transform.GetChild(6).gameObject.GetComponent<Image>().sprite = encounter.getCard(0).getSprite();
        transform.GetChild(6).gameObject.GetComponent<Image>().preserveAspect = true;
        transform.GetChild(6).gameObject.GetComponent<Image>().color = encounter.getCard(0).getColor();
        transform.GetChild(7).gameObject.GetComponent<Image>().sprite = encounter.getCard(1).getSprite();
        transform.GetChild(7).gameObject.GetComponent<Image>().preserveAspect = true;
        transform.GetChild(7).gameObject.GetComponent<Image>().color = encounter.getCard(1).getColor();
        transform.GetChild(8).gameObject.GetComponent<Image>().sprite = encounter.getCard(2).getSprite();
        transform.GetChild(8).gameObject.GetComponent<Image>().preserveAspect = true;
        transform.GetChild(8).gameObject.GetComponent<Image>().color = encounter.getCard(2).getColor();
        transform.GetChild(9).gameObject.GetComponent<Image>().sprite = encounter.getEnemy(0).getSprite();
        transform.GetChild(9).gameObject.GetComponent<Image>().preserveAspect = true;
    }

    //closes the panel
    public void close()
    {
        encounter.setSelected(false);
        Destroy(gameObject);
    }
}
