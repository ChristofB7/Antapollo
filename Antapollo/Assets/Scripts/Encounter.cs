using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Encounter : MonoBehaviour
{
    [SerializeField] bool isTown = false;
    //used to determine if this encounter should be deleted from the map
    bool encounterDone = false;

    //this info to be sent to handler and loader
    [SerializeField] string encounterName;
    [SerializeField] Sprite background;
    [SerializeField] AudioClip music;
    [SerializeField] Card card1, card2, card3;
    [SerializeField] Enemy enemy1, enemy2, enemy3, enemy4;
    //[SerializeField] Artifact art1, art2, art3;

    //the UI panel that will be initialized by on selection
    [SerializeField] EncounterPanel panel;

    //variable to determine whether the player is in the hit box
    private bool playerIsOver = false;

    //variable to determine whether the player has selected this encounter 
    private bool selected = false;

    //the instanced object
    private EncounterPanel panelObject;

    //the hitbox
    BoxCollider2D box;

    private void Start()
    {
        //sets the hitbox
        box = GetComponent<BoxCollider2D>();
    }

    //reads whether the player is in the hitbox
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerIsOver = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerIsOver = false;
    }

    private void Update()
    {
        if (playerIsOver)
        {
            //On space open panel if the panel is not already open
            if (Input.GetAxisRaw("Jump") > 0)
            {
                if (selected == false)
                {
                    spawnPanel();
                    setSelected(true);
                }
            }//On escape destroy panel
            else if (Input.GetAxisRaw("Cancel") > 0)
            {
                if (selected == true)
                {
                    panelObject.close();
                    setSelected(false);
                }
            }
        }
    }

    //spawns the panel
    void spawnPanel()
    {
        panelObject = Instantiate(panel, new Vector3(this.transform.position.x + 5, this.transform.position.y + 5, 0), Quaternion.identity) as EncounterPanel;
        panelObject.setTarget(GetComponent<Encounter>());
    }

    public void loadEncounter()
    {
        DontDestroyOnLoad(this);


        loadScene();

        SceneManager.sceneLoaded += launchScene;
    }

    //Launches the Battle Scene and handles world scene load
    private void launchScene(Scene scene, LoadSceneMode mode)
    {
        transform.Translate(new Vector3(-50, -50, 0));
        //if scene is world map
        if (scene.buildIndex == 0)
        {
            if (encounterDone)
            {
                searchAndDestroy();
            }
            else
            {
                killListenter();
                Destroy(gameObject);
            }
        }
        else if(scene.buildIndex == 1 || scene.buildIndex == 2)
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
            SceneManager.LoadSceneAsync(2);
        }
        else
        {
            //load battle
            SceneManager.LoadSceneAsync(1);
        }
    }

    public Card getCard(int index)
    {
        return card1;
    }

    //Call this with true when wishing to delete encounter after completion
    public void setEncounterDone(bool done)
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

    //searches for other all instances of this object and destroys them, overriden in child classes to narrow search field.
    public void searchAndDestroy()
    {
        foreach (Encounter enc in FindObjectsOfType<Encounter>())
        {
            if (enc.name == gameObject.name)
            {
                enc.killListenter();
                Destroy(enc.gameObject);
            }
         }
    }
}
