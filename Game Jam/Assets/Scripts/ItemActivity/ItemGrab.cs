using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrab : MonoBehaviour
{
    public float distractX;
    public GameObject player;


    public void Grab(GameObject player)
    {
        if (transform.position.x <= player.transform.position.x + distractX && transform.position.x >= player.transform.position.x)
        {
            player.GetComponent<ItemHoldPlayer>().TakeItem(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Grab(player);
        }
    }
}
