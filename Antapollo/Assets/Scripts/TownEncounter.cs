using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TownEncounter : Encounter
{
    //this info to be sent to town handler and loader
    [SerializeField] BattleEncounter fight;

    override public void loadScene()
    {
        //prepares the towns stage
        SceneManager.LoadSceneAsync(2);
    }
}
