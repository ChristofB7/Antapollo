using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    PlayerMapIcon player;
    PlayerInfo playerInfo;
    Button continueButton;
    Button quitButton;
    Button resetButton;
    [SerializeField] Canvas resetCheck;

    private void Start()
    {
        playerInfo = FindObjectOfType<PlayerInfo>();
        player = FindObjectOfType<PlayerMapIcon>();
        continueButton = transform.GetChild(1).GetComponent<Button>();
        quitButton = transform.GetChild(2).GetComponent<Button>();
        resetButton = transform.GetChild(3).GetComponent<Button>();
    }

    public void saveAndQuit()
    {
        playerInfo.save();
        player.save();
        Destroy(playerInfo.gameObject);
        SceneManager.LoadScene(3);
    }
    public void cont()
    {
        player.setPaused(false);
        GetComponent<Canvas>().enabled = false;
    }

    public void resetPress()
    {
        resetCheck.GetComponent<Canvas>().enabled = true;
        continueButton.enabled = false;
        quitButton.enabled = false;
        resetButton.enabled = false;
        player.setResetting(true);
    }

    public void resetCancel()
    {
        resetCheck.GetComponent<Canvas>().enabled = false;
        continueButton.enabled = true;
        quitButton.enabled = true;
        resetButton.enabled = true;
        player.setResetting(false);
    }

    public void resetSave()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Destroy(playerInfo.gameObject);
        SceneManager.LoadScene(3);
    }
}
