using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemGrabDropScr : MonoBehaviour
{
    public float distractX;
    GameObject Player1;
    GameObject Player2;

    void Start()
    {
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Player1.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Player2.GetComponent<Collider2D>());
    }

    public IEnumerator Grab(GameObject player)
    {
        if (player == Player1)
        {
            yield return new WaitUntil(() => Input.GetButtonUp("AButton_P1"));
        }
        if(player == Player2)
        {
            yield return new WaitUntil(() => Input.GetButtonUp("AButton_P2"));
        }
        if (transform.position.x <= player.transform.position.x + distractX && transform.position.x >= player.transform.position.x)
        {
            player.GetComponent<PlayerGrabDropScr>().TakeItem(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }


    void Update()
    {
        if (transform.parent == null)
        {
            if (Input.GetButtonDown("AButton_P1"))
            {
                Debug.Log("Grab P1");
                StartCoroutine(Grab(Player1));
            }
            if (Input.GetButtonDown("AButton_P2"))
            {
                Debug.Log("Grab P2");
                StartCoroutine(Grab(Player2));
            }
        }
    }
}
