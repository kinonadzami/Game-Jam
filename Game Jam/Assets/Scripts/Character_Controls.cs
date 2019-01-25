using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controls : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 0.1f;
    private string playerName;

    void Start()
    {
        if (gameObject.name == "Player1")
        {
            playerName = "_P1";
        }
        else
        {
            playerName = "_P2";
        }

    }

    void Update()
    {
        gameObject.transform.Translate(Input.GetAxis("DPad_Horizontal" + playerName) * MovementSpeed, 0, 0);
    }
}
