using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePad : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("AButton"))
        {
            Debug.Log("a down");
        };
        if (Input.GetButtonDown("BButton"))
        {
            Debug.Log("b down");
        };
        if (Input.GetButtonDown("BackButton"))
        {
            Debug.Log("back down");
        };
        if (Input.GetButtonDown("StartButton"))
        {
            Debug.Log("start down");
        };
        if (Input.GetAxis("DPad_Horizontal") != 0)
        {
            Debug.Log("horizontal " + Input.GetAxis("DPad_Horizontal"));
        }
        if (Input.GetAxis("DPad_Vertical") != 0)
        {
            Debug.Log("vertical " + Input.GetAxis("DPad_Vertical"));
        }
    }
}
