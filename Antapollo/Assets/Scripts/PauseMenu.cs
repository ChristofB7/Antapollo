using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    PlayerMapIcon player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMapIcon>();
    }

    public void saveAndQuit()
    {
        FindObjectOfType<PlayerInfo>().save();
        FindObjectOfType<PlayerMapIcon>().save();
        Application.Quit();
    }
    public void cont()
    {
        player.setPaused(false);
        GetComponent<Canvas>().enabled = false;
    }
}
