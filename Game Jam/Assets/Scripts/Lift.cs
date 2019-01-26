using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] float Range;
    [SerializeField] int Type = 0;
    private float defaultPosition;
    private bool movingUpwards = true;
    private bool activated = false;

    void Start()
    {
        defaultPosition = gameObject.transform.localPosition.y;
    }

    void Update()
    {
        
        if (gameObject.transform.localPosition.y >= defaultPosition + Range)
        {
            movingUpwards = false;
        }
        if (gameObject.transform.localPosition.y <= defaultPosition)
        {
            movingUpwards = true;
        }
        if (Type == 0)
        {
            if (movingUpwards)
            {
                gameObject.transform.Translate(Vector2.up * 0.02f);
            }
            else
            {
                gameObject.transform.Translate(Vector2.down * 0.02f);
            }
        }
        if (Type == 1)
        {
            if (activated && movingUpwards)
            {
                gameObject.transform.Translate(Vector2.up * 0.02f);
            }
            if (!activated && !movingUpwards)
            {
                gameObject.transform.Translate(Vector2.down * 0.02f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody.tag == "Player")
        {
            collision.transform.parent = transform;
            if (Type == 1)
            {
                activated = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.rigidbody.tag == "Player")
        {
            collision.transform.parent = null;
            if (Type == 1)
            {
                activated = false;
                movingUpwards = false;
            }

        }
    }

}
