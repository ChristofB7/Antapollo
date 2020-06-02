using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    EnemyArmorDisplay enemyArmorDisplay;
    Battle battle;
    [SerializeField] int damage = 3;
    [SerializeField] int armorUpAmount = 2;
    [SerializeField] int MAX_HEALTH = 5;
    [SerializeField] int health = 5;
    int armor = 0;
    int numberOfMoves = 2;
    //string name = "enemy";

    int nextMove;
    Canvas nextMoveCanvas;
    Image nextMoveImage;
    TextMeshProUGUI amountOfNextText;
    [SerializeField] Sprite attackSprite = null;
    [SerializeField] Sprite blockSprite = null;

    private void Start()
    {
        nextMoveCanvas = gameObject.transform.GetChild(0).GetComponent<Canvas>();
        nextMoveImage = nextMoveCanvas.transform.GetChild(0).GetComponent<Image>();
        amountOfNextText = nextMoveCanvas.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        nextMove = Random.Range(0, numberOfMoves);
        UpdateMoveDisplay();
        battle = FindObjectOfType<Battle>();
        enemyArmorDisplay = FindObjectOfType<EnemyArmorDisplay>();
    }

    public void move1()
    {
        if (damage>=battle.GetPlayerHealthArmor())
        {
            battle.LoseGame();
        }
        battle.EnemyAttack(damage);
        armor = 0;
        battle.UpdateEnemyArmorDisplay();
    }

    public void move2()
    {
        if (enemyArmorDisplay)
        {
            enemyArmorDisplay.GetComponent<Animator>().SetTrigger("Armor Up Trigger");
        }
        else
        {
            Debug.Log("display not found");
        }
        armor = armorUpAmount;
    }

    void move3()
    {

    }

    void move4()
    {

    }

    public void ChooseNDoMove()
    {

        switch (nextMove)
        {
            case 0:move1();break;
            case 1:move2();break;
            case 2:move3();break;
            case 3:move4();break;
            default: Debug.Log("Invalid enemy move :" + nextMove);break;
        }
        nextMove = Random.Range(0, numberOfMoves);
        UpdateMoveDisplay();
    }

    public void UpdateMoveDisplay()
    {
        switch (nextMove)
        {
            case 0: nextMoveImage.sprite = attackSprite; amountOfNextText.text = damage.ToString(); break;
            case 1: nextMoveImage.sprite = blockSprite; amountOfNextText.text = armorUpAmount.ToString(); break;
            case 2: move3(); break;
            case 3: move4(); break;
            default: Debug.Log("Invalid enemy move :" + nextMove); break;
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
