using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : MonoBehaviour
{
    //speed is our public mod for the direction input
    public float speed = 1f;
    Rigidbody2D myRB;
    Vector3 dir = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        dir = Direction();
        //Debug.Log("desired dir based off player input: " + dir);
        transform.Translate(dir*speed);
        
    }
//--------------------------------- THIS METHOD DOES INPUT CHECKS FOR WASD -----------------------------------------
//----------------------------------------------------------------------------------------------------------------
    Vector3 Direction()
    {
        //temp vector to hold our direction
        Vector3 v = Vector3.zero;
        //check our Up/Down axis
        //else if so there's only one valid direction at a time
        if(Input.GetKey(KeyCode.W))
            { v += Vector3.up; }
        else if(Input.GetKey(KeyCode.S))
            { v += Vector3.down; }

        //now do our left/right
        if(Input.GetKey(KeyCode.D))
            { v += Vector3.right; }
        else if(Input.GetKey(KeyCode.A))
            { v += Vector3.left; }

        //return our desired direction after all WASD checks  
        return v;
    }
}
