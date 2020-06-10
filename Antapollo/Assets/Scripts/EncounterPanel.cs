using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncounterPanel : MonoBehaviour
{
    Button confirm, cancel;
    Encounter encounter;

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
    public void setTarget(Encounter iEncounter)
    {
        encounter = iEncounter;
        transform.GetChild(6).gameObject.GetComponent<Image>().sprite = encounter.getCard(0).getSprite();
        transform.GetChild(6).gameObject.GetComponent<Image>().preserveAspect = true;
        transform.GetChild(7).gameObject.GetComponent<Image>().sprite = encounter.getEnemy(0).getSprite();
        transform.GetChild(7).gameObject.GetComponent<Image>().preserveAspect = true;
    }

    //closes the panel
    public void close()
    {
        Destroy(gameObject);
        encounter.setSelected(false);
    }
}
