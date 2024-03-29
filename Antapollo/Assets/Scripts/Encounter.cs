﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Encounter : MonoBehaviour
{
    [SerializeField] int level = 0;

    [SerializeField] bool isTown = false;
    //used to determine if this encounter should be deleted from the map
    int encounterDone = 0;
    [SerializeField] bool isHidden = false; 

    //this info to be sent to handler and loader
    [SerializeField] string encounterName;
    [SerializeField] Sprite background;
    [SerializeField] AudioClip music;
    [SerializeField] Card card1, card2, card3, shopCard1, shopCard2, shopCard3;
    [SerializeField] Enemy enemy1, enemy2, enemy3, enemy4;
    //[SerializeField] Artifact art1, art2, art3;

    //the UI panel that will be initialized by on selection
    [SerializeField] EncounterPanel panel;


    //variable to determine whether the player has selected this encounter 
    private bool selected = false;

    //the instanced object
    private EncounterPanel panelObject;

    //the hitbox
    BoxCollider2D box;

    UI ui;

    PlayerMapIcon player;

    PlayerInfo playerInfo;

    private void Awake()
    {
        if (isHidden)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void Start()
    {
        playerInfo = FindObjectOfType<PlayerInfo>();
        player = FindObjectOfType<PlayerMapIcon>();

        //sets the hitbox
        box = GetComponent<BoxCollider2D>();

        //if the encounter is done
        if (PlayerPrefs.GetInt(encounterName) == 1)
        {
            killListenter();
            Destroy(gameObject);
        }
        ui = FindObjectOfType<UI>();
    }

    //reads whether the player is in the hitbox
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (selected == false)
        {
            spawnPanel();
            setSelected(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (selected)
        {
            panelObject.close();
            setSelected(false);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (isHidden)
            {
                if (Vector3.Distance(transform.position, player.transform.position) < 3)
                {
                    GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }
    }

    //spawns the panel
    void spawnPanel()
    {
        panelObject = Instantiate(panel, new Vector3(this.transform.position.x + 3, this.transform.position.y + 3, 0), Quaternion.identity) as EncounterPanel;
        panelObject.setTarget(GetComponent<Encounter>());
    }

    public void loadEncounter()
    {

        if(level <= playerInfo.getLevel())
        {
            DontDestroyOnLoad(this);

            save();
            FindObjectOfType<PlayerInfo>().save();
            FindObjectOfType<PlayerMapIcon>().save();

            loadScene();

            SceneManager.sceneLoaded += launchScene;
        }
    }

    //Launches the Battle Scene and handles world scene load
    private void launchScene(Scene scene, LoadSceneMode mode)
    {
        transform.Translate(new Vector3(-50, -50, 0));
        //if scene is world map
        if (scene.buildIndex == 4)
        {
            if (PlayerPrefs.HasKey("posX"))
            {
                FindObjectOfType<PlayerMapIcon>().transform.position = new Vector3(PlayerPrefs.GetFloat("posX"), PlayerPrefs.GetFloat("posY"), 0);
            }

            save();
            if (PlayerPrefs.GetInt(encounterName) == 1)
            {
                playerInfo.increaseLevel();
            }
            FindObjectOfType<PlayerInfo>().save();
            FindObjectOfType<PlayerMapIcon>().save();

            ui.updateMeters(PlayerPrefs.GetInt("health"), PlayerPrefs.GetFloat("satiation"));

            //if the encounter is done
            if (PlayerPrefs.GetInt(encounterName) == 1)
            {
                killListenter();
                Destroy(gameObject);
            }
        }
        else if(scene.buildIndex == 5 || scene.buildIndex == 6)
        {
            SceneManager.SetActiveScene(scene);
        }
    }

    public void setSelected(bool sel)
    {
        selected = sel;
    }

    public void loadScene()
    {
        if (isTown)
        {
            //load town
            SceneManager.LoadSceneAsync(6);
        }
        else
        {
            //load battle
            SceneManager.LoadSceneAsync(5);
        }
    }

    public Card getCard(int index)
    {
        switch (index){
            case 0:
                return card1;
            case 1:
                return card2;
            case 2:
                return card3;
            case 3:
                return shopCard1;
            case 4:
                return shopCard2;
            case 5:
                return shopCard3;
            default:
                return card1;
        }
    }

    //Call this with true when wishing to delete encounter after completion
    public void setEncounterDone(int done)
    {
        encounterDone = done;
    }

    //used to unlink the load event from the function
    public void killListenter()
    {
        SceneManager.sceneLoaded -= launchScene;
    }

    public Enemy getEnemy(int index)
    {
        return enemy1;
    }

    //saves whether the encounter is done or not
    private void save()
    {
        PlayerPrefs.SetInt(encounterName, encounterDone);
        PlayerPrefs.Save();
    }

    public string getEncounterName()
    {
        return encounterName;
    }

    public Sprite getBackground()
    {
        return background;
    }

    public int getLevel()
    {
        return level;
    }
}
