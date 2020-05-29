using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleEncounter : MonoBehaviour
{
    //this info to be sent to battle handler and loader
    [SerializeField] Enemy enemy1, enemy2, enemy3, enemy4;
    [SerializeField] Sprite background;
    [SerializeField] AudioClip music;
    [SerializeField] Card[] cardRewards;
    //[SerializeField] Artifact[] artifactRewards;

    private void OnMouseUpAsButton()
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
