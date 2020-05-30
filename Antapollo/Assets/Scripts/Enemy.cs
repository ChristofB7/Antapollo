using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Battle battle;
    [SerializeField] int damage = 3;
    const int MAX_HEALTH = 5;
    int health = 5;
    int armor = 0;
    int numberOfMoves = 2;
    //string name = "enemy";

    private void Start()
    {
        battle = FindObjectOfType<Battle>();
    }

    public void move1()
    {
        battle.EnemyAttack(damage);
    }

    public void move2()
    {
        armor = 3;
    }

    void move3()
    {

    }

    void move4()
    {

    }

    public void ChooseNDoMove()
    {
        int chosenMove = Random.Range(0, numberOfMoves);
        switch (chosenMove)
        {
            case 0:move1();break;
            case 1:move2();break;
            case 2:move3();break;
            case 3:move4();break;
            default: Debug.Log("Invalid enemy move :" + chosenMove);break;
        }
    }

 

    public void TakeDamage(int damage)
    {
        if (damage > armor)
        {
            damage = damage - armor;
            armor = 0;
            health = health - damage;
        }
        else
        {
            armor = armor - damage;
        }
    }
    public int GetHealth()
    {
        return health;
    }
    public int GetArmor()
    {
        return armor;
    }

    public void SetArmor(int armorToSet)
    {
        armor = armorToSet;
    }
}
