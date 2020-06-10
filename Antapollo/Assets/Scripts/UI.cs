using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    Image satiationBar;
    Transform satiationBlood;
    Image healthBar;
    PlayerInfo player;
    float percentSatLost = 1f;
    Vector3 bloodStartingScale;

    private void Awake()
    {
        satiationBar = transform.GetChild(1).GetComponent<Image>();
        satiationBlood = satiationBar.transform.GetChild(0).GetComponent<Transform>();
        bloodStartingScale = satiationBar.transform.GetChild(0).transform.localScale;
        healthBar = transform.GetChild(0).GetComponent<Image>();
        player = FindObjectOfType<PlayerInfo>();
    }

    private void Update()
    {
        percentSatLost = player.GetSatiation() / player.GetMaxSatiation();
        satiationBlood.transform.localScale = new Vector3(bloodStartingScale.x, bloodStartingScale.y * percentSatLost, bloodStartingScale.z);
    }
}
