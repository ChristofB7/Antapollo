using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BattleEncounter : Encounter
{
    //this info to be sent to battle handler and loader
    [SerializeField] Enemy enemy1, enemy2, enemy3, enemy4;

    override public void loadScene()
    {
        //prepares battle stage
        SceneManager.LoadSceneAsync(1);
    }

    public Enemy getEnemy(int index)
    {
        return enemy1;
    }
}
