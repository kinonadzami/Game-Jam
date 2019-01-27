using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 0.1f;
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;
    [SerializeField] GameObject Left;
    [SerializeField] GameObject Right;
    [SerializeField] GameObject Top;
    [SerializeField] GameObject Bottom;
    private float distanceBetweenPlayers;

    void Start()
    {
        Physics2D.IgnoreCollision(Player1.GetComponent<Collider2D>(), Player2.GetComponent<Collider2D>());
    }

    void FixedUpdate()
    {
        float firstPlayerMovement = Input.GetAxis("DPad_Horizontal_P1");
        float secondPlayerMovement = Input.GetAxis("DPad_Horizontal_P2");

        if (firstPlayerMovement == 0)
        {
            firstPlayerMovement = (Input.GetKey(KeyCode.A)) ? -1 : 0;
            firstPlayerMovement = (Input.GetKey(KeyCode.D)) ? 1 : firstPlayerMovement;
        }

        if (secondPlayerMovement == 0)
        {
            secondPlayerMovement = (Input.GetKey(KeyCode.K)) ? -1 : 0;
            secondPlayerMovement = (Input.GetKey(KeyCode.Semicolon)) ? 1 : secondPlayerMovement;
        }

        Player1.GetComponent<Animator>().SetInteger("Move", (int) firstPlayerMovement);
        float p1NewPosition = Player1.transform.position.x + firstPlayerMovement * MovementSpeed;
        p1NewPosition = Player1.transform.position.x + firstPlayerMovement * MovementSpeed;

        Player2.GetComponent<Animator>().SetInteger("Move", (int) secondPlayerMovement);
        float p2NewPosition = Player2.transform.position.x + secondPlayerMovement * MovementSpeed;
        p2NewPosition = Player2.transform.position.x + secondPlayerMovement * MovementSpeed;

        if (IsDistanceBelowMax(p1NewPosition, p2NewPosition))
        {
            Player1.transform.Translate(firstPlayerMovement * MovementSpeed, 0, 0);
            Player2.transform.Translate(secondPlayerMovement * MovementSpeed, 0, 0);
        }
        SetCamera();
    }

    private float GetDistanceBetweenPlayers()
    {
        return Mathf.Abs(Player1.transform.position.x - Player2.transform.position.x);
    }

    private bool IsDistanceBelowMax()
    {
        if (Camera.main.orthographicSize * Camera.main.aspect * 2f > GetDistanceBetweenPlayers()) //TODO: include size of both heroes
        {
            return true;
        }
        return false;
    }

    private bool IsDistanceBelowMax(float x1, float x2)
    {
        if (Camera.main.orthographicSize * Camera.main.aspect * 2f > Mathf.Abs(x1 - x2)) //TODO: include size of both heroes
        {
            return true;
        }
        return false;
    }

    private void SetCamera()
    {
        SetCameraToPosition((Player1.transform.position.x + Player2.transform.position.x) / 2, (Player1.transform.position.y + Player2.transform.position.y) / 2);
        SetCameraMinHeight();
        SetCameraInBounds();
    }

    private void SetCameraToPosition(float x, float y)
    {
        Camera.main.transform.position = new Vector3(x, y, -10);
    }
    private void SetCameraToPosition(float y)
    {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, y, -10);
    }

    private void SetCameraMinHeight()
    {
        float minHeight = Mathf.Min(Player1.transform.position.y, Player2.transform.position.y, Camera.main.transform.position.y) + Camera.main.orthographicSize / 2;
        SetCameraToPosition(minHeight);
    }

    private void SetCameraInBounds()
    {
        float cameraX = Mathf.Clamp(Camera.main.transform.position.x, Left.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect, Right.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect);
        float cameraY = Mathf.Clamp(Camera.main.transform.position.y, Bottom.transform.position.y + Camera.main.orthographicSize, Top.transform.position.y - Camera.main.orthographicSize);
        SetCameraToPosition(cameraX, cameraY);
    }


    
}
