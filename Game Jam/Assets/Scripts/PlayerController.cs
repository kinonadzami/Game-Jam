using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 0.1f;
    private string playerName;

    void Start()
    {      
        if (gameObject.name == "Player1")
        {
            playerName = "_P1";
        }
        if (gameObject.name == "Player2")
        {
            playerName = "_P2";
        }

    }

    void FixedUpdate()
    {
        gameObject.transform.Translate(Input.GetAxis("DPad_Horizontal" + playerName) * MovementSpeed, 0, 0);
    }
}
