using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrab : MonoBehaviour
{
    public float distractX;


    public void Grab(GameObject player)
    {
        if(transform.position.x <= player.transform.position.x + distractX && transform.position.x >= player.transform.position.x)
        {

        }
    }





    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
