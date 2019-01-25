using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrabScr : MonoBehaviour
{
    public float distractX;
    public GameObject player;


    public void Grab(GameObject player)
    {
        if (transform.position.x <= player.transform.position.x + distractX && transform.position.x >= player.transform.position.x)
        {
            player.GetComponent<PlayerGrabScr>().TakeItem(gameObject);
        }
    }
}
