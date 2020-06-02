using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TownEncounter : Encounter
{
    int sceneIndex = 2;

    //this info to be sent to town handler and loader
    [SerializeField] BattleEncounter fight;

    override public void loadScene()
    {
        //prepares battle stage
        SceneManager.LoadSceneAsync(sceneIndex);
    }
}
