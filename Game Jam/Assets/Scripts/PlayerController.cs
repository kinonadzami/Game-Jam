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

        float p1NewPosition = Player1.transform.localPosition.x + Input.GetAxis("DPad_Horizontal_P1") * MovementSpeed;
        float p2NewPosition = Player2.transform.localPosition.x + Input.GetAxis("DPad_Horizontal_P2") * MovementSpeed;

        if (IsDistanceBelowMax(p1NewPosition, p2NewPosition))
        {
            Player1.transform.Translate(Input.GetAxis("DPad_Horizontal_P1") * MovementSpeed, 0, 0);
            Player2.transform.Translate(Input.GetAxis("DPad_Horizontal_P2") * MovementSpeed, 0, 0);
        }
        SetCamera();
    }

    private float GetDistanceBetweenPlayers()
    {
        return Mathf.Abs(Player1.transform.localPosition.x - Player2.transform.localPosition.x);
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
        SetCameraToPosition((Player1.transform.localPosition.x + Player2.transform.localPosition.x) / 2, (Player1.transform.localPosition.y + Player2.transform.localPosition.y) / 2);
        SetCameraMinHeight();
        SetCameraInBounds();
    }

    private void SetCameraToPosition(float x, float y)
    {
        Camera.main.transform.localPosition = new Vector3(x, y, -10);
    }
    private void SetCameraToPosition(float y)
    {
        Camera.main.transform.localPosition = new Vector3(Camera.main.transform.localPosition.x, y, -10);
    }

    private void SetCameraMinHeight()
    {
        float minHeight = Mathf.Min(Player1.transform.localPosition.y, Player2.transform.localPosition.y, Camera.main.transform.localPosition.y) + Camera.main.orthographicSize / 2;
        SetCameraToPosition(minHeight);
    }

    private void SetCameraInBounds()
    {
        float cameraX = Mathf.Clamp(Camera.main.transform.localPosition.x, Left.transform.localPosition.x + Camera.main.orthographicSize * Camera.main.aspect, Right.transform.localPosition.x - Camera.main.orthographicSize * Camera.main.aspect);
        float cameraY = Mathf.Clamp(Camera.main.transform.localPosition.y, Bottom.transform.localPosition.y + Camera.main.orthographicSize, Top.transform.localPosition.y - Camera.main.orthographicSize);
        SetCameraToPosition(cameraX, cameraY);
    }
}
