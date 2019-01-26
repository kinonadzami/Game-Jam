using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    public bool Climbing = false;
    public float ClimbVelocity = 0;

    public void Climb(string DPad)
    {
        transform.Translate(0, Input.GetAxis(DPad) * ClimbVelocity, 0);
    }

    public void ClimbStart()
    {
        Climbing = true;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().simulated = true;
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    public void ClimbEnd()
    {
        Climbing = false;
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        ClimbStart();
    }
    void OnTriggerStay2D(Collider2D collision)
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

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
        ClimbEnd();
    }

    void Update()
    {
        if (Climbing)
        {
            if(name == "Player1")
            {
                Climb("DPad_Vertical_P1");
            }
            if (name == "Player2")
            {
                Climb("DPad_Vertical_P2");
            }
        }
    }
}
