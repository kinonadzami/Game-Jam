using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHoldPlayer : MonoBehaviour
{
    public GameObject holdingItem = null;
    public float fall = 0;

    public void TakeItem(GameObject item)
    {
        if (holdingItem == null)
        {
            holdingItem = item;
            item.transform.SetParent(transform);
            item.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    public void DropItem()
    {
        if (holdingItem != null)
        {
            holdingItem.transform.SetParent(transform.parent);
            holdingItem.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - fall, -1);
            holdingItem = null;
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropItem();
        }
    }
}
