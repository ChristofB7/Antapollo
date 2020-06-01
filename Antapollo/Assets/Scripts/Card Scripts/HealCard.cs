using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCard : MonoBehaviour
{
    [SerializeField] int heal = 1;
    public int GetHealAmount()
    {
        return heal;
    }
}
