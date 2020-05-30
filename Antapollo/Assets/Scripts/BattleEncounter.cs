using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BattleEncounter : MonoBehaviour
{
    //this info to be sent to battle handler and loader
    [SerializeField] string battleName;
    [SerializeField] Enemy enemy1, enemy2, enemy3, enemy4;
    [SerializeField] Sprite background;
    [SerializeField] AudioClip music;
    [SerializeField] Card[] cardRewards;
    //[SerializeField] Artifact[] artifactRewards;

    [SerializeField] BattleEncounterPanel panel;

    private bool playerIsOver = false;

    private bool selected = false;

    private BattleEncounterPanel panelObject;

    BoxCollider2D box;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        panel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = battleName;

    }

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
            if (Input.GetAxisRaw("Jump") > 0)
            {
                if (selected == false)
                {
                    spawnPanel();
                    selected = true;
                }
            }
            if (Input.GetAxisRaw("Cancel") > 0)
            {
                if (selected == true)
                {
                    Destroy(panelObject);
                    selected = false;
                }
            }
        }
    }

    void spawnPanel()
    {
       panelObject = Instantiate(panel, new Vector3(this.transform.position.x + 5, this.transform.position.y + 5, 0), Quaternion.identity) as BattleEncounterPanel;
       panelObject.setTarget(GetComponent<BattleEncounter>());
    }

    public void loadEncounter()
    {
        //hides the object and disables hitbox
        hideFlags = HideFlags.HideAndDontSave;

        //prepares battle stage
        SceneManager.LoadSceneAsync(1);

        //links lauch method to sceneLoaded event (I have no Idea if I'm using the right terminology)
        SceneManager.sceneLoaded += launchScene;
    }

    //Launches the Battle Scene
    private void launchScene(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);
    }
}
