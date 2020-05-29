using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMapIcon : MonoBehaviour
{
    const int SPEED = 5;

    private float diagonal = 1;
    private int horzAxis = 0;
    private int vertAxis = 0;

    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            horzAxis = 1;
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            horzAxis = -1;
        }
        else
        {
            horzAxis = 0;
        }

        if(Input.GetAxis("Vertical") > 0)
        {
            vertAxis = 1;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            vertAxis = -1;
        }
        else
        {
            vertAxis = 0;
        }

        if(Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
        {
            diagonal = 1;
        }
        else
        {
            diagonal = Mathf.Sqrt(2.0f);
        }

        transform.Translate(new Vector3(SPEED*horzAxis/diagonal, 0, SPEED*vertAxis/diagonal));



    }
}
