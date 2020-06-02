using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Encounter : MonoBehaviour
{
    //this info to be sent to battle handler and loader
    [SerializeField] string encounterName;
    [SerializeField] Sprite background;
    [SerializeField] AudioClip music;
    [SerializeField] Card card1, card2, card3;
    //[SerializeField] Artifact art1, art2, art3;

    //the UI panel that will be initialized by on selection
    [SerializeField] EncounterPanel panel;

    //the index of the encounter scene
    int sceneIndex;

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
        //hides the object and disables hitbox
        hideFlags = HideFlags.HideAndDontSave;

        loadScene();

        //links lauch method to sceneLoaded event (I have no Idea if I'm using the right terminology)
        SceneManager.sceneLoaded += launchScene;
    }

    //Launches the Battle Scene
    private void launchScene(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);
    }

    public void setSelected(bool sel)
    {
        selected = sel;
    }

    virtual public void loadScene()
    {
        //prepares battle stage
        SceneManager.LoadSceneAsync(sceneIndex);
    }
}
