using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 0.1f;
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;
    private string playerName;

    void Start()
    {
        Physics2D.IgnoreCollision(Player1.GetComponent<Collider2D>(), Player2.GetComponent<Collider2D>());
    }

    void FixedUpdate()
    {
        Player1.transform.Translate(Input.GetAxis("DPad_Horizontal_P1") * MovementSpeed, 0, 0);
        Player2.transform.Translate(Input.GetAxis("DPad_Horizontal_P2") * MovementSpeed, 0, 0);
    }
}
