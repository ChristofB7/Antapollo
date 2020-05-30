using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMapIcon : MonoBehaviour
{
    //player move speed
    const float SPEED = 0.2f;

    //is either 1 or the square root of 2. Used to ensure constant speed on diagonals
    private float diagonal = 1;

    //used to determine sign of movements, 0 if none
    private int horzAxis = 0;
    private int vertAxis = 0;

    //holds the rigid body component
    Rigidbody2D player;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
       //finds the sign of the horz axis
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            horzAxis = 1;
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            horzAxis = -1;
        }
        else
        {
            horzAxis = 0;
        }

        //finds the sign of the vert axis
        if(Input.GetAxisRaw("Vertical") > 0)
        {
            vertAxis = 1;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            vertAxis = -1;
        }
        else
        {
            vertAxis = 0;
        }

        //checks if movement is diagonal
        if(Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            diagonal = Mathf.Sqrt(2.0f);
        }
        else
        {
            diagonal = 1;
        }

        //moves player
        player.MovePosition(player.position + new Vector2(SPEED*horzAxis/diagonal, SPEED*vertAxis/diagonal));
    }

}
