using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabDropScr : MonoBehaviour
{
    public GameObject holdingItem = null;
    public float fall = 0;

    public void TakeItem(GameObject item)
    {
        if (holdingItem == null)
        {
            holdingItem = item;
            item.transform.SetParent(transform);
            item.transform.localPosition = new Vector3(0, 0, -1);
            item.GetComponent<Rigidbody2D>().simulated = false;
        }
    }

    public void DropItem()
    {
        if (holdingItem != null)
        {
            holdingItem.transform.SetParent(transform.parent);
            holdingItem.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - fall, -1);
            holdingItem.GetComponent<Rigidbody2D>().simulated = true;
            holdingItem = null;
        }
    }

    void Update()
    {
        if(name == "Player1")
        {
            if (Input.GetButtonUp("AButton_P1") && holdingItem != null)
            {
                Debug.Log("Drop P1");
                DropItem();
            }
        }
        if (name == "Player2")
        {
            if (Input.GetButtonUp("AButton_P2") && holdingItem != null)
            {
                Debug.Log("Drop P2");
                DropItem();
            }
        }
    }
}
