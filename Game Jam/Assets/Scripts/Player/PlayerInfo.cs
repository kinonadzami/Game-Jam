using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int HP;
    public string Name;

    void Start()
    {
        HP = 3;
    }

    public void HPChange(int change)
    {
        HP += change;
    }
}
