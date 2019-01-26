using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeClimb : MonoBehaviour
{
    public float enterRegion;
    public float exitRegion;
    GameObject Player1;
    GameObject Player2;
    public GameObject Top;

    void Start()
    {
    }
    
    public void ClimbStart(GameObject player)
    {
        player.GetComponent<PlayerClimb>().ClimbStart();
    }

    public void ClimbEnd(GameObject player)
    {
        player.GetComponent<PlayerClimb>().ClimbEnd();
    }



    void Update()
    {
        
    }
}
