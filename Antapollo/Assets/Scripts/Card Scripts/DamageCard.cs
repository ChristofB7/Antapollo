using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageCard : MonoBehaviour
{
    [SerializeField] int damage = 3;
    [SerializeField] TextMeshProUGUI damageText = null;
    Deck parent;
    Battle battle;
    public int GetDamage()
    {
        return damage;
    }
    private void Start()
    {
        if (gameObject.transform.parent.GetComponent<Deck>())
        {
            parent = gameObject.transform.parent.GetComponent<Deck>();
            if (parent)
            {
                battle = parent.GetBattle();
                if (battle)
                {
                    damageText.text = battle.CalculateAttack(damage).ToString();
                }
            }
        }
        else
        {
            Debug.Log("Couldn't find the Deck or battle");
        }
       
    }
}
