using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TownEncounterPanel : EncounterPanel
{
    public override void setTarget(Encounter iEncounter)
    {
        player = FindObjectOfType<PlayerInfo>();
        encounter = iEncounter;
        if (encounter.getLevel() > player.getLevel())
        {
            transform.GetChild(14).GetComponent<Image>().enabled = true;
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

        transform.GetChild(11).gameObject.GetComponent<Image>().sprite = encounter.getCard(3).getSprite();
        transform.GetChild(11).gameObject.GetComponent<Image>().preserveAspect = true;
        transform.GetChild(11).gameObject.GetComponent<Image>().color = encounter.getCard(3).getColor();

        transform.GetChild(12).gameObject.GetComponent<Image>().sprite = encounter.getCard(4).getSprite();
        transform.GetChild(12).gameObject.GetComponent<Image>().preserveAspect = true;
        transform.GetChild(12).gameObject.GetComponent<Image>().color = encounter.getCard(4).getColor();

        transform.GetChild(13).gameObject.GetComponent<Image>().sprite = encounter.getCard(5).getSprite();
        transform.GetChild(13).gameObject.GetComponent<Image>().preserveAspect = true;
        transform.GetChild(13).gameObject.GetComponent<Image>().color = encounter.getCard(5).getColor();
    }
}
