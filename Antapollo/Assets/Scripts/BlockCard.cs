using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCard : MonoBehaviour
{
    [SerializeField] int block = 3;

    public int GetBlock()
    {
        return block;
    }
}
