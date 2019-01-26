using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int HP;
    public string Name;
    public float direction = 1;

    void Start()
    {
        HP = 3;
    }

    public void HPChange(int change)
    {
        HP += change;
    }

    void Update()
    {
        if (name == "Player1")
        {
            if (Input.GetAxis("DPad_Horizontal_P1") != 0)
            {
                direction = Input.GetAxis("DPad_Horizontal_P1");
            }
        }
        if (name == "Player2")
        {
            if (Input.GetAxis("DPad_Horizontal_P2") != 0)
            {
                direction = Input.GetAxis("DPad_Horizontal_P2");
            }
        }
    }
}
