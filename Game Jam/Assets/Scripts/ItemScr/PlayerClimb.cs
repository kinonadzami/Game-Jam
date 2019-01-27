using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    public bool Climbing = false;
    public float ClimbVelocity = 0;
    private const KeyCode keyCodeUpP1 = KeyCode.W;
    private const KeyCode keyCodeDownP1 = KeyCode.S;
    private const string axisP1 = "DPad_Vertical_P1";
    private const KeyCode keyCodeUpP2 = KeyCode.O;
    private const KeyCode keyCodeDownP2 = KeyCode.L;
    private const string axisP2 = "DPad_Vertical_P2";

    public void Climb(KeyCode keyCodeUp, KeyCode keyCodeDown, string DPad)
    {
        float climbTransform = Input.GetAxis(DPad);
        if (climbTransform == 0)
        {
            climbTransform = Input.GetKey(keyCodeUp) ? 1 : 0;
            climbTransform = Input.GetKey(keyCodeDown) ? -1 : climbTransform;
        }
        transform.Translate(0, climbTransform * ClimbVelocity, 0);
    }

    public void ClimbStart()
    {
        Climbing = true;
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    public void ClimbEnd()
    {
        Climbing = false;
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            Debug.Log(collision.gameObject.name);
            ClimbStart();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<RopeClimb>().Top.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
            Debug.Log("Stay");
            if (name == "Player1")
            {
                if (Input.GetAxis("DPad_Vertical_P1") == -1)
                {
                    Physics2D.IgnoreCollision(collision.gameObject.GetComponent<RopeClimb>().Top.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                }
            }
            if (name == "Player2")
            {
                if (Input.GetAxis("DPad_Vertical_P2") == -1)
                {
                    Physics2D.IgnoreCollision(collision.gameObject.GetComponent<RopeClimb>().Top.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            Debug.Log("Exit");
            ClimbEnd();
        }
    }

    void Update()
    {
        if (Climbing)
        {
            if (name == "Player1")
            {
                Climb(keyCodeUpP1, keyCodeDownP1, axisP1);
            }
            if (name == "Player2")
            {
                Climb(keyCodeUpP2, keyCodeDownP2, axisP2);
            }
        }
    }
}
