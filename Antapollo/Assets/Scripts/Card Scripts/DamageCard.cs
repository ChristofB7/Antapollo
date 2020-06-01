using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCard : MonoBehaviour
{
    [SerializeField] int damage = 3;

    public int GetDamage()
    {
        return damage;
    }
}
