using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleEncounterPanel : MonoBehaviour
{
    Button confirm, cancel;
    BattleEncounter encounter;

    void Start()
    {
        confirm = transform.GetChild(5).gameObject.GetComponent<Button>();
        cancel = transform.GetChild(6).gameObject.GetComponent<Button>();

        confirm.onClick.AddListener(confirmClick);
        cancel.onClick.AddListener(cancelClick);
    }

    private void Update()
    {
        
    }

    void confirmClick()
    {
        encounter.loadEncounter();
    }

    void cancelClick()
    {
        Destroy(gameObject);
    }
    
    public void setTarget(BattleEncounter iEncounter)
    {
        encounter = iEncounter;
    }
}
