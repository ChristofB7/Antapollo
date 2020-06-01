using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class VillageButton : MonoBehaviour
{
    TextMeshProUGUI tooltip;
    // Start is called before the first frame update
    void Start()
    {
        tooltip = gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        tooltip.gameObject.SetActive(false);
    }

    private void OnMouseOver()
    {
        tooltip.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        tooltip.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
