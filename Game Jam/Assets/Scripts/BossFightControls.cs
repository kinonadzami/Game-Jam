using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightControls : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 0.1f;
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;
    [SerializeField] GameObject Left;
    [SerializeField] GameObject Right;
    [SerializeField] GameObject Top;
    [SerializeField] GameObject Bottom;
    private float distanceBetweenPlayers;

    [SerializeField] GameObject AButton;
    [SerializeField] GameObject BButton;
    [SerializeField] GameObject LeftButton;
    [SerializeField] GameObject RightButton;
    [SerializeField] float ActionStartTime = 25;
    [SerializeField] float ActionTime = 4;
    private string[] buttons = { "a", "b", "right", "left" };
    private float timer;
    private float buttonTimer;
    private bool action = false;
    string reqButton;

    void Start()
    {
        buttonTimer = ActionTime;
        Physics2D.IgnoreCollision(Player1.GetComponent<Collider2D>(), Player2.GetComponent<Collider2D>());
    }

    void FixedUpdate()
    {
        float firstPlayerMovement = Input.GetAxis("DPad_Horizontal_P1");
        //float secondPlayerMovement = Input.GetAxis("DPad_Horizontal_P2");

        if (firstPlayerMovement == 0)
        {
            firstPlayerMovement = (Input.GetKey(KeyCode.A)) ? -1 : 0;
            firstPlayerMovement = (Input.GetKey(KeyCode.D)) ? 1 : firstPlayerMovement;
        }

        //if (secondPlayerMovement == 0)
        //{
        //    secondPlayerMovement = (Input.GetKey(KeyCode.K)) ? -1 : 0;
        //    secondPlayerMovement = (Input.GetKey(KeyCode.Semicolon)) ? 1 : secondPlayerMovement;
        //}

        float p1NewPosition = Player1.transform.position.x + firstPlayerMovement * MovementSpeed;
        Player1.GetComponent<Animator>().SetInteger("Move", (int)Input.GetAxis("DPad_Horizontal_P1"));
        //float p2NewPosition = Player2.transform.position.x + secondPlayerMovement * MovementSpeed;
        Player2.GetComponent<Animator>().SetInteger("Move", (int)Input.GetAxis("DPad_Horizontal_P2"));

        //if (IsDistanceBelowMax(p1NewPosition, p2NewPosition))
        //{
            Player1.transform.Translate(firstPlayerMovement * MovementSpeed, 0, 0);
        //    Player2.transform.Translate(secondPlayerMovement * MovementSpeed, 0, 0);
        //}

        timer += Time.fixedDeltaTime;

        if (action)
        {
            buttonTimer -= Time.fixedDeltaTime;
            if (Input.GetButtonDown("AButton_P2"))
            {
                if (reqButton == "a")
                {
                    //throw food to witch & deal damage
                    //green glow on button
                }
                else
                {
                    //no damage, oops sound
                    //red glow on button
                }
                AButton.SetActive(false);
                action = false;
            }
            if (Input.GetButtonDown("BButton_P2"))
            {
                if (reqButton == "b")
                {
                    //throw food to witch & deal damage
                    //green glow on button
                }
                else
                {
                    //no damage, oops sound
                    //red glow on button
                }
                AButton.SetActive(false);
                action = false;
            }
            if (Input.GetAxis("DPad_Horizontal_P2") == 1)
            {
                if (reqButton == "right")
                {
                    //getting no damage aka dodged
                    //green glow on button
                }
                else
                {
                    //getting damage
                    //red glow on button
                }
                RightButton.SetActive(false);
                action = false;
            }
            if (Input.GetAxis("DPad_Horizontal_P2") == -1)
            {
                if (reqButton == "left")
                {
                    //getting no damage aka dodged
                    //green glow on button
                }
                else
                {
                    //getting damage
                    //red glow on button
                }
                LeftButton.SetActive(false);
                action = false;
            }
        }

        if (action && buttonTimer <= 0)
        {
            AButton.SetActive(false);
            BButton.SetActive(false);
            RightButton.SetActive(false);
            LeftButton.SetActive(false);
            action = false;
        }

        if (timer >= ActionStartTime)
        {
            reqButton = GetNewButton();
            switch (reqButton)
            {
                case "a":
                    AButton.SetActive(true);
                    break;
                case "b":
                    BButton.SetActive(true);
                    break;
                case "right":
                    RightButton.SetActive(true);
                    break;
                case "left":
                    LeftButton.SetActive(true);
                    break;
                default:
                    break;
            }
            action = true;
            buttonTimer = ActionTime;
        }

        SetCamera();
    }

    private void actionControls()
    {
        

    }    

    private string GetNewButton()
    {
        int index = (int)(Random.value * 4);
        return buttons[index];
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
